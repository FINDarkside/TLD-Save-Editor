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

			/*Debug.WriteLine(Global.SprainedAnkle.m_Active);
			Debug.WriteLine(string.Join(", ", Global.SprainedAnkle.m_CausesLocIDs));
			Debug.WriteLine(Global.SprainedAnkle.m_DurationHours);
			Debug.WriteLine(string.Join(", ", Global.SprainedAnkle.m_DurationHoursList));
			Debug.WriteLine(Global.SprainedAnkle.m_ElapsedHours);
			Debug.WriteLine(string.Join(", ", Global.SprainedAnkle.m_ElapsedHoursList));
			Debug.WriteLine(Global.SprainedAnkle.m_ElapsedRest);
			Debug.WriteLine(string.Join(", ", Global.SprainedAnkle.m_ElapsedRestList));
			Debug.WriteLine(string.Join(", ", Global.SprainedAnkle.m_Locations));
			Debug.WriteLine(Global.SprainedAnkle.m_PainKillersTaken);
			Debug.WriteLine(Global.SprainedAnkle.m_SecondsSinceLastPainAudio);
			Debug.WriteLine(Global.SprainedAnkle.m_SecondsSinceSprain);
			Debug.WriteLine(Global.SprainedAnkle.m_SecondsUntilNextPainAudio);*/

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
