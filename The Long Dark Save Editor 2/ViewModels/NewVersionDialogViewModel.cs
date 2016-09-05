using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Helpers.Helpers;

namespace The_Long_Dark_Save_Editor_2.ViewModels
{

	public class VersionData
	{
		public decimal version { get; set; }
		public string url { get; set; }
		public string changes { get; set; }
	}

	public class NewVersionDialogViewModel
	{
		public List<VersionData> Versions { get; set; }
		public string Url { get; set; }
		public ICommand DownloadCommand { get; set; }

		public NewVersionDialogViewModel()
		{
			DownloadCommand = new CommandHandler(() =>
			{
				try
				{
					Uri uri = new Uri(Url);
					if (string.Equals(uri.Host, "www.moddb.com", StringComparison.OrdinalIgnoreCase))
					{
						Process.Start(Url);
					}
				}
				catch (Exception ex)
				{

				}

			});

		}
	}
}
