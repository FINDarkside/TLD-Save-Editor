using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace The_Long_Dark_Save_Editor_2
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App() : base()
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((object sender, UnhandledExceptionEventArgs args) =>
			{
				string codeBase = System.Reflection.Assembly.GetExecutingAssembly().Location;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				path = Path.Combine(Path.GetDirectoryName(path), "crash.txt");

				File.WriteAllText(path, args.ExceptionObject.ToString());

				Environment.Exit(-1);
			});
		}

	}
}
