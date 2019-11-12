using The_Long_Dark_Save_Editor_2.Serialization;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
    public class BootSaveGameFormat
    {
        public EnumWrapper<RegionsWithMap> m_SceneName { get; set; }
        public int m_Version { get; set; }
    }
}
