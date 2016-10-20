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
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
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

		public static decimal Version { get { return 2.4m; } }

		private GameSave currentSave;
		public GameSave CurrentSave
		{
			get { return currentSave; }
			set
			{
				SetPropertyField(ref currentSave, value);
			}
		}

		private Profile currentProfile;
		public Profile CurrentProfile
		{
			get { return currentProfile; }
			set
			{
				SetPropertyField(ref currentProfile, value);
			}
		}

		public bool IsDebug { get; set; }

		public ObservableCollection<EnumerationMember> Saves { get; set; }



		public MainWindow()
		{

#if DEBUG
			IsDebug = true;
#endif

			InitializeComponent();
			Saves = GetSaveFiles();
			if (Saves.Count > 0)
			{
				var profile = Path.Combine(Directory.GetParent(Saves[0].Value.ToString()).FullName, "user001");
				if (File.Exists(profile))
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
			this.DataContext = this;

			Title += " " + Version.ToString(CultureInfo.InvariantCulture.NumberFormat); ;

			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				//MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error,
				FloatFormatHandling = FloatFormatHandling.Symbol
			};


			//File.WriteAllBytes(@"C:\Users\Jesse\AppData\Local\Hinterland\TheLongDark\save001\global", EncryptString.CompressStringToBytes(save.Global.Serialize()));

		}

		public ObservableCollection<EnumerationMember> GetSaveFiles()
		{

			Guid localLowId = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
			string localLow = GetKnownFolderPath(localLowId) + "\\Hinterland\\TheLongDark\\";
			// TODO fix
			string local = localLow.Replace("LocalLow", "Local");

			Regex reg = new Regex(".*save[0-9]+");
			Regex reg2 = new Regex(".*chall[0-9]+");
			var saves = new List<string>();
			if (Directory.Exists(local))
				saves.AddRange((from f in Directory.GetDirectories(local) where reg.IsMatch(f) || reg2.IsMatch(f) select f).ToList<string>());

			var result = new ObservableCollection<EnumerationMember>();
			foreach (string saveFolder in saves)
			{
				if (Directory.GetFiles(saveFolder).Length == 0)
					continue;
				var member = new EnumerationMember();

				try
				{
					var globalFile = Path.Combine(saveFolder, "global");
					if (!File.Exists(globalFile))
						continue;
					var bytes = File.ReadAllBytes(globalFile);
					var json = EncryptString.DecompressBytesToString(bytes);
					var globalData = JsonConvert.DeserializeObject<GlobalSaveGameFormat>(json);
					member.Description = globalData.m_UserDefinedSaveSlotName + " (" + Path.GetFileName(saveFolder) + ")";
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
					continue;
				}
				member.Value = saveFolder;
				result.Add(member);
			}

			return result;
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
					if (versions[versions.Count - 1].version > Version)
					{
						var newerVersions = versions.Where(version => version.version > Version).ToList();
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

			System.Uri uri = new System.Uri("http://www.moddb.com/mods/umod-tld/downloads/the-long-dark-save-editor1");
			Debug.WriteLine(uri.Host);
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
			var scope = FocusManager.GetFocusScope(tabPanel); // elem is the UIElement to unfocus
			FocusManager.SetFocusedElement(scope, null); // remove logical focus
			Keyboard.ClearFocus(); // remove keyboard focus

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

			inventoryItem.Rotation = new float[4];
			inventoryItem.Position = new float[3];
			inventoryItem.BeenInPlayerInventory = true;
			inventoryItem.NormalizedCondition = 1;
			inventoryItem.WornOut = false;
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

		private void OpenClicked(object sender, RoutedEventArgs e)
		{

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
				Properties.Settings.Default.BugReportWarningShown = true;
				Properties.Settings.Default.Save();
			}
#endif
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
			var path = ccSaves.SelectedValue.ToString();
			try
			{
				var save = new GameSave();
				save.LoadSave(path);
				CurrentSave = save;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ASDASD");

				ErrorDialog.Show("Failed to load save", ex != null ? (ex.Message + "\n" + ex.ToString()) : null);
				tabPanel.IsEnabled = false;
			}
			tabPanel.IsEnabled = true;
		}

		private void PrintJsonClicked(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine(((InventoryItem)ItemList.SelectedValue).Serialize().m_SerializedGear);
		}

		string GetKnownFolderPath(Guid knownFolderId)
		{
			IntPtr pszPath = IntPtr.Zero;
			try
			{
				int hr = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);
				if (hr >= 0)
					return Marshal.PtrToStringAuto(pszPath);
				throw Marshal.GetExceptionForHR(hr);
			}
			finally
			{
				if (pszPath != IntPtr.Zero)
					Marshal.FreeCoTaskMem(pszPath);
			}
		}

		[DllImport("shell32.dll")]
		static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

		private void RefreshClicked(object sender, RoutedEventArgs e)
		{
			CurrentSaveSelectionChanged(null, null);
		}
	}

}
