using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Tabs
{
	/// <summary>
	/// Interaction logic for InventoryTab.xaml
	/// </summary>
	public partial class InventoryTab : UserControl
	{
		private MainWindow mainWindow;

		public InventoryTab()
		{
			InitializeComponent();
			mainWindow = (MainWindow)DataContext;
		}

		private void AddItemClicked(object sender, RoutedEventArgs e)
		{
			var prefabName = (string)cbItem.SelectedValue;

			if (prefabName == null)
				return;

			var itemInfo = ItemDictionary.itemInfo[prefabName];

			var inventoryItem = Util.DeserializeObject<InventoryItem>(itemInfo.defaultSerialized);
			inventoryItem.PrefabName = prefabName;
			
			inventoryItem.HoursPlayed = mainWindow.CurrentSave.Global.TimeOfDay.m_HoursPlayedNotPausedProxy;

			mainWindow.CurrentSave.Global.Inventory.Items.Add(inventoryItem);
			ItemList.SelectedItem = inventoryItem;
		}

		private void DeleteItemClicked(object sender, RoutedEventArgs e)
		{
			var index = ItemList.SelectedIndex;
			mainWindow.CurrentSave.Global.Inventory.Items.Remove((InventoryItem)ItemList.SelectedValue);
			if (ItemList.Items.Count <= index)
				ItemList.SelectedIndex = index - 1;
			else
				ItemList.SelectedIndex = index;
		}

		private void RemoveAllClicked(object sender, RoutedEventArgs e)
		{
			mainWindow.CurrentSave.Global.Inventory.Items.Clear();
		}

		private void RepairAllClicked(object sender, RoutedEventArgs e)
		{
			foreach (var item in mainWindow.CurrentSave.Global.Inventory.Items)
			{
				item.NormalizedCondition = 1;
				item.WornOut = false;

				if (item.FlareItem != null)
					item.FlareItem.m_StateProxy = FlareState.Fresh;
				if (item.TorchItem != null)
					item.TorchItem.m_StateProxy = TorchState.Fresh;
			}
		}

		private void cbItem_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (cbItem.SelectedItem == null && cbItem.Items.Count > 0)
				cbItem.SelectedIndex = 0;
		}

		private void PrintJsonClicked(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine(((InventoryItem)ItemList.SelectedValue).Serialize().m_SerializedGear);
		}
	}
}
