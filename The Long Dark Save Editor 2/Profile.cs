using System;
using System.IO;
using System.Text.RegularExpressions;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2
{
    public class Profile
    {
        public string path;

        private DynamicSerializable<ProfileState> dynamicState;
        public ProfileState State { get { return dynamicState.Obj; } }

        private string rawAllTimeStats;
        private string rawSandboxRecords;

        public Profile(string path)
        {
            this.path = path;

            var json = EncryptString.Decompress(File.ReadAllBytes(path));
            //Temporary cut raw data from json cause m_StatsDictionary doesn`t fit JSON format.
            json = Regex.Replace(json, @"\""m_SandboxRecords\"":\[([^\]]*\]){10}", delegate (Match match)
            {
                rawSandboxRecords = match.ToString();
                return @"""m_SandboxRecords"":""""";
            });

            dynamicState = new DynamicSerializable<ProfileState>(json);
        }

        public void Save()
        {
            string json = dynamicState.Serialize();
            //Turn back cutted raw data.
            json = Regex.Replace(json, @"\""m_SandboxRecords\"":\""\""", rawSandboxRecords);

            File.WriteAllBytes(path, EncryptString.Compress(json));
        }
    }
}
