using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using WForms = System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;
using The_Long_Dark_Save_Editor_2.ViewModels;

namespace The_Long_Dark_Save_Editor_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public static MainWindow Instance { get; set; }
		public static VersionData Version { get { return new VersionData() { version = "2.6" }; } }

		private GameSave currentSave;
		public GameSave CurrentSave { get { return currentSave; } set { SetPropertyField(ref currentSave, value); } }

		private Profile currentProfile;
		public Profile CurrentProfile
		{
			get { return currentProfile; }
			set { SetPropertyField(ref currentProfile, value); }
		}

		private bool testBranch;
		public bool TestBranch
		{
			get { return testBranch; }
			set
			{
				testBranch = value;
				UpdateSaves();
				Properties.Settings.Default.TestBranch = value;
			}
		}

		public bool IsDebug { get; set; }

		private ObservableCollection<EnumerationMember> saves;

		public ObservableCollection<EnumerationMember> Saves
		{
			get { return saves; }
			set { SetPropertyField(ref saves, value); }
		}

		public MainWindow()
		{
#if DEBUG
			IsDebug = true;

			foreach (var e in Enum.GetValues(typeof(ItemCategory)))
			{
				Debug.WriteLine(e.ToString());

			}
			Debug.WriteLine(System.Threading.Thread.CurrentThread.CurrentUICulture);
			//System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");


#endif

			Instance = this;
			testBranch = Properties.Settings.Default.TestBranch;

			InitializeComponent();
			this.DataContext = this;

			Title += " " + Version.ToString();

			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				//MissingMemberHandling = MissingMemberHandling.Error,
				FloatFormatHandling = FloatFormatHandling.Symbol,
			};

			UpdateSaves();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
#if !DEBUG
			if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
			{
				try
				{
					CheckForUpdates();
				}
				catch (Exception ex)
				{
					dialogHost.IsOpen = false;
					ErrorDialog.Show("Failed to check for new versions", ex != null ? (ex.Message + "\n" + e.ToString()) : null);
				}

			}

			if (!Properties.Settings.Default.BugReportWarningShown)
			{
				System.Windows.MessageBox.Show("Do NOT report any in-game bugs to Hinterland if you have edited your save. Bugs might be caused by the save editor. Only report bugs if you are able to reproduce them in fresh unedited save.");
				//System.Windows.MessageBox.Show("If you don't have test branch version of the game, untick the toggle button at top right corner.");

				Properties.Settings.Default.BugReportWarningShown = true;
				Properties.Settings.Default.Save();
			}
#endif
		}

		private void UpdateSaves()
		{
			var path = Path.Combine(Util.GetLocalPath(), testBranch ? "HinterlandTest1" : "Hinterland", "TheLongDark");
			Debug.WriteLine(path);

			Saves = Util.GetSaveFiles(path);
			if (Saves.Count == 0)
				CurrentSave = null;
			else
				ccSaves.SelectedIndex = 0;

			var profile = Path.Combine(path, "user001");
			if (File.Exists(profile) && (CurrentProfile == null || !Equals(profile, CurrentProfile.path)))
			{
				try
				{
					CurrentProfile = new Profile(profile);
				}
				catch (Exception ex)
				{
					WForms.MessageBox.Show(ex.Message + "\nFailed to load profile", "Failed to load profile", WForms.MessageBoxButtons.OK, WForms.MessageBoxIcon.Exclamation);
				}
			}

		}

		public void CheckForUpdates()
		{
			WebClient webClient = new WebClient();
			webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler)((sender, e) =>
			{

				try
				{
					string json = e.Result;
					List<VersionData> versions = JsonConvert.DeserializeObject<List<VersionData>>(json);
					if (versions[versions.Count - 1] > Version)
					{
						var newerVersions = versions.Where(version => version > Version).ToList();
						var viewModel = new NewVersionDialogViewModel() { Versions = newerVersions, Url = newerVersions[newerVersions.Count - 1].url };
						dialogHost.DialogContent = viewModel;
						dialogHost.IsOpen = true;
					}
				}
				catch (Exception ex)
				{
					dialogHost.IsOpen = false;
					ErrorDialog.Show("Failed to check for new versions", ex != null ? (ex.Message + "\n" + e.ToString()) : null);

				}
			});
			webClient.DownloadStringTaskAsync("https://tld-save-editor-2.firebaseio.com/Changelog.json");

		}

		protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, newValue))
			{
				field = newValue;
				PropertyChangedEventHandler handler = PropertyChanged;
				if (handler != null)
					handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			var scope = FocusManager.GetFocusScope(tabPanel);
			FocusManager.SetFocusedElement(scope, null);
			Keyboard.ClearFocus();

			if (CurrentSave != null)
				CurrentSave.Save();
			if (CurrentProfile != null)
				CurrentProfile.Save();
		}

		private void AddItemClicked(object sender, RoutedEventArgs e)
		{
			var prefabName = (string)cbItem.SelectedValue;

			if (prefabName == null)
				return;

			var itemInfo = ItemDictionary.itemInfo[prefabName];

			var inventoryItem = Util.DeserializeObject<InventoryItem>(itemInfo.defaultSerialized);
			inventoryItem.PrefabName = prefabName;
			inventoryItem.HoursPlayed = CurrentSave.Global.TimeOfDay.m_HoursPlayedNotPausedProxy;

			CurrentSave.Global.Inventory.Items.Add(inventoryItem);
			ItemList.SelectedItem = inventoryItem;
		}

		private void DeleteItemClicked(object sender, RoutedEventArgs e)
		{
			var index = ItemList.SelectedIndex;
			CurrentSave.Global.Inventory.Items.Remove((InventoryItem)ItemList.SelectedValue);
			if (ItemList.Items.Count <= index)
				ItemList.SelectedIndex = index - 1;
			else
				ItemList.SelectedIndex = index;
		}

		private void cbItem_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (cbItem.SelectedItem == null && cbItem.Items.Count > 0)
				cbItem.SelectedIndex = 0;
		}

		private void RepairAllClicked(object sender, RoutedEventArgs e)
		{
			foreach (var item in CurrentSave.Global.Inventory.Items)
			{
				item.NormalizedCondition = 1;
				item.WornOut = false;

				if (item.FlareItem != null)
					item.FlareItem.m_StateProxy = FlareState.Fresh;
				if (item.TorchItem != null)
					item.TorchItem.m_StateProxy = TorchState.Fresh;
			}
		}

		private void CurrentSaveSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ccSaves == null && ccSaves.SelectedValue == null)
				return;

			if (ccSaves.SelectedValue != null)
			{
				var path = ccSaves.SelectedValue.ToString();
				try
				{
					var save = new GameSave();
					save.LoadSave(path);
					CurrentSave = save;
				}
				catch (Exception ex)
				{
					ErrorDialog.Show("Failed to load save", ex != null ? (ex.Message + "\n" + ex.ToString()) : null);
					tabPanel.IsEnabled = false;
				}
				tabPanel.IsEnabled = true;
			}
		}

		private void PrintJsonClicked(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine(((InventoryItem)ItemList.SelectedValue).Serialize().m_SerializedGear);
		}

		private void RefreshClicked(object sender, RoutedEventArgs e)
		{
			CurrentSaveSelectionChanged(null, null);
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void RemoveAllClicked(object sender, RoutedEventArgs e)
		{
			CurrentSave.Global.Inventory.Items.Clear();
		}
	}

}
