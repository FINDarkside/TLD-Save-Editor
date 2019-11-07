using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Tabs
{

    public partial class MapTab : UserControl
    {

        private MapInfo mapInfo;
        private bool mouseDown;
        private Point clickPosition;
        private Point lastMousePosition;

        private Point playerPosition;

        private string region;

        public MapTab()
        {
            InitializeComponent();

            MainWindow.Instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(MainWindow.Instance.CurrentSave))
                {
                    Debug.WriteLine("Currentsave changed");
                    if (MainWindow.Instance.CurrentSave == null)
                    {
                        region = null;
                        UpdateMap();
                        return;
                    }
                    region = MainWindow.Instance.CurrentSave.Boot.m_SceneName.Value;
                    playerPosition = new Point(MainWindow.Instance.CurrentSave.Global.PlayerManager.m_SaveGamePosition[0], MainWindow.Instance.CurrentSave.Global.PlayerManager.m_SaveGamePosition[2]);
                    UpdateMap();
                    var saveGamePosition = MainWindow.Instance.CurrentSave.Global.PlayerManager.m_SaveGamePosition;
                    saveGamePosition.CollectionChanged += (sender2, e2) =>
                    {

                        if ((e2.NewStartingIndex == 0 && saveGamePosition[0] != (float)playerPosition.X) || (e2.NewStartingIndex == 2 && saveGamePosition[2] != (float)playerPosition.Y))
                        {
                            playerPosition.X = saveGamePosition[0];
                            playerPosition.Y = saveGamePosition[2];
                            UpdatePlayerPosition();
                        }
                    };
                    MainWindow.Instance.CurrentSave.Boot.m_SceneName.PropertyChanged += (sender2, e2) =>
                    {
                        if (e2.PropertyName == "Value")
                        {
                            region = MainWindow.Instance.CurrentSave.Boot.m_SceneName.Value;
                            Debug.WriteLine("New region: " + region);
                            UpdateMap();
                        }
                    };
                }
            };

        }

        private void UpdateMap()
        {
            if (!IsLoaded)
                return;
            if (region == null)
            {
                mapImage.Source = null;
                mapInfo = null;
                player.Visibility = Visibility.Hidden;
                canvasLabel.Text = "";
                canvasLabel.Visibility = Visibility.Visible;
                return;
            }
            if (!MapDictionary.MapExists(region))
            {
                mapImage.Source = null;
                mapInfo = null;
                player.Visibility = Visibility.Hidden;
                canvasLabel.Text = "No map found for current region";
                canvasLabel.Visibility = Visibility.Visible;
                return;
            }
            player.Visibility = Visibility.Visible;
            canvasLabel.Visibility = Visibility.Hidden;

            mapInfo = MapDictionary.GetMapInfo(region);
            mapImage.Source = ((Image)Resources[region]).Source;
            mapImage.Width = mapInfo.width;
            mapImage.Height = mapInfo.height;

            double wScale = canvas.ActualWidth / mapInfo.width;
            double hScale = canvas.ActualHeight / mapInfo.height;
            scaleMap.ScaleX = Math.Max(Math.Min(wScale, hScale), 0.5);
            scaleMap.ScaleY = Math.Max(Math.Min(wScale, hScale), 0.5);

            UpdatePlayerPosition();
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mapInfo == null) return;

            mouseDown = true;
            clickPosition = e.GetPosition(canvas);
            lastMousePosition = clickPosition;
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mapInfo == null) return;

            mouseDown = false;
            canvas.ReleaseMouseCapture();
            if (e.GetPosition(canvas) == clickPosition)
            {
                playerPosition = mapInfo.ToRegion(e.GetPosition(mapImage));
                UpdatePlayerPosition();

                MainWindow.Instance.CurrentSave.Global.PlayerManager.m_SaveGamePosition[0] = (float)playerPosition.X;
                MainWindow.Instance.CurrentSave.Global.PlayerManager.m_SaveGamePosition[2] = (float)playerPosition.Y;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mapInfo == null) return;

            if (mouseDown)
            {
                canvas.CaptureMouse();
                var mousePos = e.GetPosition(canvas);

                translateMap.X += (mousePos.X - lastMousePosition.X);
                translateMap.Y += (mousePos.Y - lastMousePosition.Y);
                lastMousePosition = mousePos;
            }
        }

        private void canvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (mapInfo == null) return;

            double zoom = e.Delta > 0 ? .3 * scaleMap.ScaleX : -.3 * scaleMap.ScaleX;
            
            var x = e.GetPosition(mapLayer).X / mapLayer.ActualWidth;
            var y = e.GetPosition(mapLayer).Y / mapLayer.ActualHeight;
            x = Math.Max(Math.Min(x, 1), 0);
            y = Math.Max(Math.Min(y, 1), 0);
            var dX = (x - mapLayer.RenderTransformOrigin.X) * mapLayer.ActualWidth * (1 - scaleMap.ScaleX);
            var dY = (y - mapLayer.RenderTransformOrigin.Y) * mapLayer.ActualHeight * (1 - scaleMap.ScaleY);

            translateMap.X -= dX;
            translateMap.Y -= dY;
            mapLayer.RenderTransformOrigin = new Point(x, y);
            
            scaleMap.ScaleX += zoom;
            scaleMap.ScaleY += zoom;
        }

        private void UpdatePlayerPosition()
        {
            UpdatePlayerPosition(mapInfo.ToLayer(playerPosition));
        }

        private void UpdatePlayerPosition(Point layerPoint)
        {
            Canvas.SetLeft(player, layerPoint.X);
            Canvas.SetTop(player, layerPoint.Y);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMap();
        }
    }
}
