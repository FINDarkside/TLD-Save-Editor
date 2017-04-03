using System.Diagnostics;
using System.IO;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2
{
	public class GameSave
	{
		public BootSaveGameFormat Boot { get; set; }
		public GlobalSaveGameData Global { get; set; }
		public string OriginalRegion { get; set; }

		private string path;

		public void LoadSave(string path)
		{
			this.path = path;

			var bootLocation = Path.Combine(path, "boot");
			Boot = Util.DeserializeObject<BootSaveGameFormat>(LoadFile(bootLocation));
			OriginalRegion = Boot.m_SceneName;

			var globalLocation = Path.Combine(path, "global");
			Global = new GlobalSaveGameData(LoadFile(globalLocation));
			Global.PlayerManager.m_SaveGamePosition.CollectionChanged += (sender, e) => {
				if(Global.PlayerManager.m_SaveGamePosition[1] != 10000000)
					Global.PlayerManager.m_SaveGamePosition[1] = 10000000;
			};

		}

		public void Save()
		{
			var bootSerialized = Util.SerializeObject(Boot);
			File.WriteAllBytes(Path.Combine(path, "boot"), EncryptString.CompressStringToBytes(bootSerialized));

			var globalSerialized = Global.Serialize();
			File.WriteAllBytes(Path.Combine(path, "global"), EncryptString.CompressStringToBytes(globalSerialized));

		}

		private string LoadFile(string path)
		{
			var bytes = File.ReadAllBytes(path);
			var json = EncryptString.DecompressBytesToString(bytes);

			return json;
		}
	}
}
