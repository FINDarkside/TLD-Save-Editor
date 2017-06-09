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
        public SlotData SlotData { get; set; }
        public string OriginalRegion { get; set; }
        private float[] originalPosition;

        private string path;

        public void LoadSave(string path)
        {
            this.path = path;
            SlotData = Util.DeserializeObject<SlotData>(EncryptString.DecompressBytesToString(File.ReadAllBytes(path)));

            Boot = Util.DeserializeObject<BootSaveGameFormat>(EncryptString.DecompressBytesToString(SlotData.m_Dict["boot"]));
            OriginalRegion = Boot.m_SceneName;

            Global = new GlobalSaveGameData(EncryptString.DecompressBytesToString(SlotData.m_Dict["global"]));
            var pos = Global.PlayerManager.m_SaveGamePosition;
            originalPosition = new float[] { pos[0], pos[1], pos[2] };
        }

        public void Save()
        {
            var bootSerialized = Util.SerializeObject(Boot);
            SlotData.m_Dict["boot"] = EncryptString.CompressStringToBytes(bootSerialized);

            // If position is changed, set z coordinate to float.infinity to avoid going under terrain
            var pos = Global.PlayerManager.m_SaveGamePosition;
            if (OriginalRegion != Boot.m_SceneName || pos[0] != originalPosition[0] || pos[1] != originalPosition[1] || pos[2] != originalPosition[2])
            {
                pos[1] = 9999999;
            }

            var globalSerialized = Global.Serialize();
            SlotData.m_Dict["global"] = EncryptString.CompressStringToBytes(globalSerialized);

            var slotDataSerialized = Util.SerializeObject(SlotData);
            File.WriteAllBytes(path, EncryptString.CompressStringToBytes(slotDataSerialized));
        }
    }
}
