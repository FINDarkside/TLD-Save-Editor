using Newtonsoft.Json;
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
            mainWindow = MainWindow.Instance;

        }

        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            var prefabName = (string)cbItem.SelectedValue;

            if (prefabName == null)
                return;

            var itemInfo = ItemDictionary.itemInfo[prefabName];

            var item = new InventoryItemSaveData();
            var gear = GearItemSaveDataProxy.Create();
            JsonConvert.PopulateObject(itemInfo.defaultSerialized, gear);
            item.m_PrefabName = prefabName;
            item.Gear = gear;
            gear.m_HoursPlayed = mainWindow.CurrentSave.Global.TimeOfDay.m_HoursPlayedNotPausedProxy;
            mainWindow.CurrentSave.Global.Inventory.Items.Add(item);
            ItemList.SelectedItem = item;
        }

        private void DeleteItemClicked(object sender, RoutedEventArgs e)
        {
            var index = ItemList.SelectedIndex;
            mainWindow.CurrentSave.Global.Inventory.Items.Remove((InventoryItemSaveData)ItemList.SelectedValue);
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
                var gear = item.Gear;
                gear.NormalizedCondition = 1;
                gear.m_WornOut = false;

                if (gear.FlareItem != null)
                    gear.FlareItem.m_StateProxy.SetValue(FlareState.Fresh);
                if (gear.TorchItem != null)
                    gear.TorchItem.m_StateProxy.SetValue(TorchState.Fresh);
            }
        }

        private void cbItem_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbItem.SelectedItem == null && cbItem.Items.Count > 0)
                cbItem.SelectedIndex = 0;
        }

        private void PrintJsonClicked(object sender, RoutedEventArgs e)
        {
            // TODO!!
        }
    }
}
