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

		private string path;

		public void LoadSave(string path)
		{
			this.path = path;

			var bootLocation = Path.Combine(path, "boot");
			Debug.WriteLine(LoadFile(bootLocation));

			Boot = Util.DeserializeObject<BootSaveGameFormat>(LoadFile(bootLocation));

			var globalLocation = Path.Combine(path, "global");
			Global = new GlobalSaveGameData(LoadFile(globalLocation));
		}

		public void Save()
		{
			//Global.Afflictions.Negative.Add(new BloodLoss() { AfflictionType = AfflictionType.BloodLoss, CauseLocID = "asd", DurationHours = 10, Location = 2 });
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
