using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using The_Long_Dark_Save_Editor_2.Game_data;

namespace The_Long_Dark_Save_Editor_2.Helpers
{

    public class SaveInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime Timestamp { get; set; }
        public uint GameId { get; set; }
        public string SlotType { get; set; }
        public List<SaveInfo> SecondaryFiles { get; set; }
    }

    public class SaveFileManager
    {

        private class SaveSlotIdentifier
        {
            public string SlotType { get; set; }
            public uint Id { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || obj.GetType() != typeof(SaveSlotIdentifier))
                    return false;
                var slotIdentifier = (SaveSlotIdentifier)obj;
                return SlotType == slotIdentifier.SlotType && Id == slotIdentifier.Id;

            }

            public override int GetHashCode()
            {
                return SlotType.GetHashCode() * 17 + Id.GetHashCode();
            }
        }

        public ObservableCollection<SaveInfo> Saves { get; set; } = new ObservableCollection<SaveInfo>();

        public void UpdateSaves(string folder, string uwpFolder)
        {
            if (Directory.Exists(folder))
            {
                GetSaves(folder).ForEach(i => Saves.Add(i));
            }
            if (Directory.Exists(uwpFolder))
            {
                GetSaves(uwpFolder, "UWP").ForEach(i => Saves.Add(i));
            }
        }

        private List<SaveInfo> GetSaves(string folder, string name = null)
        {
            var saves = new Dictionary<SaveSlotIdentifier, List<SaveInfo>>();
            foreach (string file in Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories))
            {
                if (!File.Exists(file))
                    throw new Exception();
                try
                {
                    var saveInfo = LoadSlotData(file, name ?? Path.GetFileName(file));
                    var identifier = new SaveSlotIdentifier()
                    {
                        Id = saveInfo.GameId,
                        SlotType = saveInfo.SlotType,
                    };
                    if (!saves.ContainsKey(identifier))
                        saves.Add(identifier, new List<SaveInfo>());
                    saves[identifier].Add(saveInfo);
                }
                catch (Exception ex)
                {
                    // TODO: log
                    Console.WriteLine("Failed to load " + file);
                }
            }
            foreach (var kvp in saves)
            {
                kvp.Value.Sort((a, b) => (int)(b.Timestamp.Ticks - a.Timestamp.Ticks));
                kvp.Value[0].SecondaryFiles = kvp.Value.GetRange(0, kvp.Value.Count - 1).ToList();
            }
            return saves.Values.Select(v => v[0]).ToList();
        }

        private SaveInfo LoadSlotData(string file, string name)
        {
            string json = EncryptString.Decompress(File.ReadAllBytes(file));
            var slotData = new DynamicSerializable<SlotData>(json).Obj;
            if (slotData.m_GameMode.Value == "CHECKPOINT")
                slotData.m_GameMode.Value = "STORY";
            return new SaveInfo()
            {
                Name = slotData.m_Name + " (" + name + ")",
                Path = file,
                GameId = slotData.m_GameId,
                Timestamp = slotData.m_Timestamp,
                SlotType = slotData.m_GameMode.Value,
            };
        }
    }
}
