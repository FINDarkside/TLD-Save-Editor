using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2
{

	public partial class MapWindow : Window
	{
		private double pixelsPerCoordinate;

		private GameSave gameSave;
		private bool mouseDown;
		private Point origo;
		private Point clickPosition;
		private Point lastMousePosition;
		public Point playerPosition;

		public MapWindow(GameSave currentSave)
		{
			gameSave = currentSave;
			InitializeComponent();
			string region = currentSave.Boot.m_SceneName;
			var mapInfo = MapDictionary.GetMapInfo(region);
			pixelsPerCoordinate = mapInfo.pixelsPerCoordinate;
			mapImage.Source = ((Image)Resources[region]).Source;
			origo = mapInfo.origo;
			mapImage.Height = mapInfo.height;
			mapImage.Width = mapInfo.width;

			playerPosition.X = currentSave.Global.PlayerManager.m_SaveGamePosition[0];
			playerPosition.Y = currentSave.Global.PlayerManager.m_SaveGamePosition[2];

			SetPosition(0, 0);
		}

		private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			mouseDown = true;
			clickPosition = e.GetPosition(canvas);
			lastMousePosition = clickPosition;
		}

		private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			mouseDown = false;
			canvas.ReleaseMouseCapture();
			if (e.GetPosition(canvas) == clickPosition)
			{
				var x = e.GetPosition(mapImage).X;
				var y = e.GetPosition(mapImage).Y;

				playerPosition.X = (x - origo.X) / pixelsPerCoordinate;
				playerPosition.Y = (y - origo.Y) / -pixelsPerCoordinate;

				SetPosition(Canvas.GetLeft(mapImage), Canvas.GetTop(mapImage));
			}
		}

		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				canvas.CaptureMouse();
				var mousePos = e.GetPosition(canvas);

				var x = Canvas.GetLeft(mapImage) - (lastMousePosition.X - mousePos.X);
				var y = Canvas.GetTop(mapImage) - (lastMousePosition.Y - mousePos.Y);
				SetPosition(x, y);
				lastMousePosition = mousePos;
			}
		}

		private void canvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
		{
			double zoom = e.Delta > 0 ? .1 * scale.ScaleX : -.1 * scale.ScaleX;

			var centerX = (-Canvas.GetLeft(mapImage) + canvas.ActualWidth / 2) / scale.ScaleX;
			var centerY = (-Canvas.GetTop(mapImage) + canvas.ActualHeight / 2) / scale.ScaleY;

			scale.ScaleX += zoom;
			scale.ScaleY += zoom;

			var x = -centerX * scale.ScaleX + canvas.ActualWidth / 2;
			var y = -centerY * scale.ScaleY + canvas.ActualHeight / 2;
			SetPosition(x, y);
		}

		private void SetPosition(double x, double y)
		{
			Canvas.SetLeft(mapImage, x);
			Canvas.SetTop(mapImage, y);

			var playerCanvasX = (playerPosition.X * pixelsPerCoordinate + origo.X) * scale.ScaleX + x;
			var playerCanvasY = (playerPosition.Y * -pixelsPerCoordinate + origo.Y) * scale.ScaleY + y;

			Canvas.SetLeft(player, playerCanvasX);
			Canvas.SetTop(player, playerCanvasY);

			gameSave.Global.PlayerManager.m_SaveGamePosition[0] = (float)playerPosition.X;
			gameSave.Global.PlayerManager.m_SaveGamePosition[2] = (float)playerPosition.Y;
		}
	}
}
