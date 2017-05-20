using System.Collections.ObjectModel;
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
        private float[] originalPosition;

		private string path;

		public void LoadSave(string path)
		{
			this.path = path;

			var bootLocation = Path.Combine(path, "boot");
			Boot = Util.DeserializeObject<BootSaveGameFormat>(LoadFile(bootLocation));
			OriginalRegion = Boot.m_SceneName;

			var globalLocation = Path.Combine(path, "global");
			Global = new GlobalSaveGameData(LoadFile(globalLocation));
			var pos = Global.PlayerManager.m_SaveGamePosition;
			originalPosition = new float[] { pos[0], pos[1], pos[2]};
		}

		public void Save()
		{
			var bootSerialized = Util.SerializeObject(Boot);
			File.WriteAllBytes(Path.Combine(path, "boot"), EncryptString.CompressStringToBytes(bootSerialized));

            // If position is changed, set z coordinate to float.infinity to avoid going under terrain
            var pos = Global.PlayerManager.m_SaveGamePosition;
            if(OriginalRegion != Boot.m_SceneName || pos[0] != originalPosition[0] ||pos[1] != originalPosition[1] || pos[2] != originalPosition[2])
            {
                pos[1] = 10000;
            }

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
