using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
	/// <summary>
	/// Interaction logic for ErrorDialog.xaml
	/// </summary>
	public partial class ErrorDialog : Window
	{
		public ErrorDialog()
			: this("", "")
		{
		}


		public ErrorDialog(string header, string content)
		{
			InitializeComponent();

			//Hidden icon
			this.Icon = BitmapImage.Create(2, 2, 96, 96, PixelFormats.Indexed1, new BitmapPalette(new List<System.Windows.Media.Color> { Colors.Transparent }), new byte[] { 0, 0, 0, 0 }, 1);

			SystemSounds.Hand.Play();

			tbHeader.Text = header;
			if (content == null)
				bCopyToClipBoard.Visibility = System.Windows.Visibility.Hidden;
			else
				tbContent.Text = content;

			try
			{

				var temp = SystemIcons.Error.ToBitmap();
				BitmapImage bitmapImage = new BitmapImage();
				using (MemoryStream memory = new MemoryStream())
				{
					temp.Save(memory, ImageFormat.Png);
					memory.Position = 0;
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = memory;
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.EndInit();
				}
				iErrorIcon.Source = bitmapImage;
			}
			catch (Exception)
			{
			}
		}

		public static void Show(string header)
		{
			Show(header, null);
		}

		public static void Show(string header, string content)
		{
			Application.Current.Dispatcher.BeginInvoke((Action)delegate
			{
				var dialog = new ErrorDialog(header, content);
				try
				{
					dialog.Owner = Application.Current.MainWindow;
					dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				}
				catch { }

				dialog.ShowDialog();
			});
		}

		private void OkClicked(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void CopyToClipBoardClicked(object sender, RoutedEventArgs e)
		{
			Clipboard.SetText("`" + tbContent.Text + "`");
		}

	}
}
