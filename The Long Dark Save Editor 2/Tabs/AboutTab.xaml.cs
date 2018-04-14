using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace The_Long_Dark_Save_Editor_2.Tabs
{
    public partial class AboutTab : UserControl
    {
        public AboutTab()
        {
            InitializeComponent();
        }

        private void ViewOnGithubClicked(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/FINDarkside/TLD-Save-Editor");
        }
    }
}
