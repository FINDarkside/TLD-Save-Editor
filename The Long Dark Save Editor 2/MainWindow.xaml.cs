using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using WForms = System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Helpers;
using The_Long_Dark_Save_Editor_2.ViewModels;
using The_Long_Dark_Save_Editor_2.Serialization;

namespace The_Long_Dark_Save_Editor_2
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static MainWindow Instance { get; set; }
        public static VersionData Version { get { return new VersionData() { version = "2.19" }; } }

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
                Properties.Settings.Default.TestBranch = value;
                SetPropertyField(ref testBranch, value);
                UpdateSaves();
            }
        }

        public bool IsDebug { get; set; }

        private ObservableCollection<EnumerationMember> saves;

        public ObservableCollection<EnumerationMember> Saves
        {
            get { return saves; }
            set { SetPropertyField(ref saves, value); }
        }

        private FileSystemWatcher appDataFileWatcher;

        private bool currentSaveChanged = false;

        public MainWindow()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                //MissingMemberHandling = MissingMemberHandling.Error,
                FloatFormatHandling = FloatFormatHandling.Symbol,
                // Serialize byte arrays as arrays of numbers instead of base64
                Converters = new List<JsonConverter> { new ByteArrayConverter() },
            };

#if DEBUG
            IsDebug = true;
            Debug.WriteLine(System.Threading.Thread.CurrentThread.CurrentUICulture);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");
#endif

            appDataFileWatcher = new FileSystemWatcher();
            appDataFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            appDataFileWatcher.Changed += new FileSystemEventHandler(SaveFileChanged);

            this.DataContext = this;
            Instance = this;
            InitializeComponent();

            TestBranch = Properties.Settings.Default.TestBranch;
            Title += " " + Version.ToString();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Window loaded");
#if !DEBUG
            
            CheckForUpdates();
            LogOpen();

            if (!Properties.Settings.Default.BugReportWarningShown)
            {
                System.Windows.MessageBox.Show("DO NOT report any in-game bugs to Hinterland if you have edited your save. Bugs might be caused by the save editor. Only report bugs if you are able to reproduce them in fresh unedited save.");
                //System.Windows.MessageBox.Show("If you don't have test branch version of the game, untick the toggle button at top right corner.");

                Properties.Settings.Default.BugReportWarningShown = true;
                Properties.Settings.Default.Save();
            }
#endif
        }

        private void SaveFileChanged(object source, FileSystemEventArgs e)
        {
            Debug.WriteLine(e.FullPath);
            if (e.FullPath == null || CurrentSave == null)
                return;
            if (Path.Equals(e.FullPath, CurrentSave.path))
            {
                // 3 seconds
                if (DateTime.Now.Ticks - CurrentSave.LastSaved > 30000000)
                {
                    Debug.WriteLine("SAVE UPDATED");
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        if (this.IsActive)
                        {
                            dialogHost.DialogContent = new SaveFileUpdatedViewModel();
                            dialogHost.IsOpen = true;
                            this.currentSaveChanged = false;
                        }
                        else
                        {
                            // If window is not active, don't show dialog right away since it takes focus from the game
                            this.currentSaveChanged = true;
                        }
                    }));
                }
            }
        }

        private void UpdateSaves()
        {
            var path = Path.Combine(Util.GetLocalPath(), testBranch ? "HinterlandTest2" : "Hinterland", "TheLongDark", "Survival");
            Debug.WriteLine(path);

            if (Directory.Exists(path))
            {
                appDataFileWatcher.Path = path;
                appDataFileWatcher.EnableRaisingEvents = true;
            }

            Saves = Util.GetSaveFiles(path);

            if (CurrentSave != null)
            {
                var save = Saves.FirstOrDefault(s => s.Value.ToString() == CurrentSave.path);
                if (save != null)
                    ccSaves.SelectedItem = save;
            }
            else if (Saves.Count == 0)
                CurrentSave = null;
            else
                ccSaves.SelectedIndex = 0;

            if (Directory.Exists(path))
            {
                var profile = Directory.GetFiles(path, "user001.*")
                                .Select(file => new FileInfo(file))
                                .OrderByDescending(file => file.LastWriteTime)
                                .FirstOrDefault()?.FullName;
                if (profile != null)
                {
                    try
                    {
                        CurrentProfile = new Profile(profile);
                    }
                    catch (Exception ex)
                    {
                        WForms.MessageBox.Show(ex.Message + "\nFailed to load profile\n" + ex.ToString(), "Failed to load profile", WForms.MessageBoxButtons.OK, WForms.MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

        async public void CheckForUpdates()
        {

            try
            {
                WebClient webClient = new WebClient();
                string json = await webClient.DownloadStringTaskAsync("https://tld-save-editor-2.firebaseio.com/Changelog.json");

                List<VersionData> versions = JsonConvert.DeserializeObject<List<VersionData>>(json);
                if (versions[versions.Count - 1] > Version)
                {
                    var newerVersions = versions.Where(version => version > Version).ToList();

                    SnackBar.MessageQueue.Enqueue("New version available", "Download", () =>
                    {
                        try
                        {
                            string url = newerVersions[newerVersions.Count - 1].url;
                            Uri uri = new Uri(url);
                            if (string.Equals(uri.Host, "www.moddb.com", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(uri.Host, "github.com", StringComparison.OrdinalIgnoreCase))
                            {
                                Process.Start(url);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    });
                }
            }
            catch (Exception ex)
            {
                SnackBar.MessageQueue.Enqueue("Failed to check for new versions: " + ex.GetType().FullName);
            }
        }

        async public void LogOpen()
        {
            try
            {
                WebClient webClient = new WebClient();
                await webClient.DownloadStringTaskAsync("https://us-central1-tld-save-editor-2.cloudfunctions.net/editorOpened?version=" + Version);
            }
            catch (Exception ex)
            {

            }
        }

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

        public void CurrentSaveSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ccSaves == null && ccSaves.SelectedValue == null)
                return;

            if (ccSaves.SelectedValue != null)
            {
                var path = ccSaves.SelectedValue.ToString();
                SetSave(path);
            }
        }

        private void SetSave(string path)
        {
            try
            {
                var save = new GameSave();
                save.LoadSave(path);
                CurrentSave = save;
            }
            catch (Exception ex)
            {
                ErrorDialog.Show("Failed to load save", ex != null ? (ex.Message + "\n" + ex.ToString()) : null);
            }
        }

        private void RefreshClicked(object sender, RoutedEventArgs e)
        {
            if (CurrentSave != null)
                SetSave(CurrentSave.path);
            UpdateSaves();
        }

        private void JoinDiscordClicked(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/evYPhQm");
        }

        private void ViewOnGitHubClicked(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/FINDarkside/TLD-Save-Editor");
        }

        private void OpenBackupsClicked(object sender, RoutedEventArgs e)
        {
            var path = Path.Combine(Util.GetLocalPath(), testBranch ? "HinterlandTest2" : "Hinterland", "TheLongDark", "Survival", "backups");
            Process.Start(path);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TheWindow_Activated(object sender, EventArgs e)
        {
            if (this.currentSaveChanged)
            {
                dialogHost.DialogContent = new SaveFileUpdatedViewModel();
                dialogHost.IsOpen = true;
                this.currentSaveChanged = false;
            }
        }
    }

}
