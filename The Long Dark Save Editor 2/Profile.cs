using System;
using System.Collections.Generic;
using System.IO;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;
using System.Diagnostics;

namespace The_Long_Dark_Save_Editor_2
{
    public class Profile
    {
        public string path;

        public ProfileState proxy { get; set; }
        public string FeatsSerialized { get; set; }

        public FeatsManager Feats { get; set; }

        public Profile(string path)
        {
            this.path = path;

            var bytes = File.ReadAllBytes(path);
            var json = EncryptString.DecompressBytesToString(bytes);

            int currentIndex = 0;

            #region Fix m_StatsDictionary
            // m_StatsDictionary is invalid json so we'll fix it
            // There's multiple instances of m_StatsDictionary
            // Ugly as f but works... for now
            while (true)
            {
                int statsDictStartIndex = json.IndexOf("m_StatsDictionary", currentIndex);
                if (statsDictStartIndex == -1)
                    break;
                statsDictStartIndex = json.IndexOf('{', statsDictStartIndex);
                currentIndex = statsDictStartIndex;

                int statsDictEndIndex = json.IndexOf('}', statsDictStartIndex);

                // Save files contain json that has been serialized multiple times and not all m_StatsDictionarys are on the same depth
                var newStats = json.Substring(statsDictStartIndex, statsDictEndIndex - statsDictStartIndex);
                if (newStats.Length <= 2)
                    continue;
                int depth = 0;
                int quoteIndex = newStats.IndexOf("\"");
                for (int i = quoteIndex - 1; newStats[i] == '\\'; i--, depth++) { }
                string escapes = new String('\\', depth);

                for (var i = 0; i < newStats.Length; i++)
                {
                    var c = newStats[i];

                    if ((c == '-' || char.IsDigit(c)))
                    {
                        if (newStats[i - 1] != '"' && newStats[i - 1] != '.')
                        {
                            newStats = newStats.Insert(i, escapes + "\"");
                            i += 2 + depth;

                            while (char.IsDigit(newStats[i]) || newStats[i] == '-') { i++; }
                            newStats = newStats.Insert(i, escapes + "\"");
                            i += 1 + depth;
                        }
                        else
                        {
                            while (char.IsDigit(newStats[i]) || newStats[i] == '.' || newStats[i] == 'E' || newStats[i] == '-') { i++; }
                        }

                    }
                }

                json = json.Substring(0, statsDictStartIndex) + newStats + json.Substring(statsDictEndIndex);
            }

            #endregion

            var proxy = Util.DeserializeObject<ProfileState>(json);
            if (proxy == null)
                return;

            Feats = new FeatsManager(proxy.m_FeatsSerialized);
        }

        public void Save()
        {
            var proxy = new ProfileState();
            proxy.m_FeatsSerialized = Feats.Serialize();

            string json = Util.SerializeObject(proxy);

            #region Break m_StatsDictionary

            // And of course the game can't read that valid json so we have to fuck it up again

            int currentIndex = 0;
            while (true)
            {
                int statsDictStartIndex = json.IndexOf("m_StatsDictionary", currentIndex);
                if (statsDictStartIndex == -1)
                    break;
                statsDictStartIndex = json.IndexOf('{', statsDictStartIndex);
                currentIndex = statsDictStartIndex;

                int statsDictEndIndex = json.IndexOf('}', statsDictStartIndex);

                var newStats = json.Substring(statsDictStartIndex, statsDictEndIndex - statsDictStartIndex);
                if (newStats.Length <= 2)
                    continue;

                int currentIndex2 = 0;
                while (true)
                {
                    int colonIndex = newStats.IndexOf(':', currentIndex2);
                    if (colonIndex == -1)
                        break;
                    currentIndex2 = colonIndex + 1;

                    int i = colonIndex;
                    while (newStats[i] != '{' && newStats[i] != ',')
                    {
                        if (newStats[i] == '\\' || newStats[i] == '\"')
                            newStats = newStats.Remove(i, 1);
                        i--;
                    }
                }

                json = json.Substring(0, statsDictStartIndex) + newStats + json.Substring(statsDictEndIndex);
            }

            #endregion

            File.WriteAllBytes(path, EncryptString.CompressStringToBytes(json));

        }
    }
}
