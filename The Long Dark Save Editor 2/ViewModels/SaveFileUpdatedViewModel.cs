using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Helpers.Helpers;

namespace The_Long_Dark_Save_Editor_2.ViewModels
{
    public class SaveFileUpdatedViewModel
    {
        public ICommand RefreshCommand { get; set; }

        public SaveFileUpdatedViewModel()
        {
            RefreshCommand = new CommandHandler(() =>
            {
                MainWindow.Instance.CurrentSaveSelectionChanged(null, null);
                DialogHost.CloseDialogCommand.Execute(null, null);
            });
        }
    }
}
