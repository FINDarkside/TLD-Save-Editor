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

        public Profile(string path)
        {
            this.path = path;

            var json = EncryptString.Decompress(File.ReadAllBytes(path));

            // m_StatsDictionary is invalid json (unquoted keys), so fix it
            json = Regex.Replace(json, @"(\\*\""m_StatsDictionary\\*\"":\{)((?:[-0-9\.]+:\\*\""[-0-9eE\.]+\\*\""\,?)+)(\})", delegate (Match match)
            {
                string jsonSubStr = Regex.Replace(match.Groups[2].ToString(), @"([-0-9]+):(\\*\"")", delegate (Match matchSub)
                {
                    var escapeStr = matchSub.Groups[2].ToString();
                    return escapeStr + matchSub.Groups[1].ToString() + escapeStr + @":" + escapeStr;
                });
                return match.Groups[1].ToString() + jsonSubStr + match.Groups[3].ToString();
            });

            dynamicState = new DynamicSerializable<ProfileState>(json);
        }

        public void Save()
        {
            string json = dynamicState.Serialize();

            // Game cannot read valid json for m_StatsDictionary so remove quotes from keys
            json = Regex.Replace(json, @"(\\*\""m_StatsDictionary\\*\"":\{)((?:\\*\""[-0-9\.]+\\*\"":\\*\""[-0-9eE\.]+\\*\""\,?)+)(\})", delegate (Match match)
            {
                string jsonSubStr = Regex.Replace(match.Groups[2].ToString(), @"\\*\""([-0-9]+)\\*\"":", delegate (Match matchSub)
                {
                    return matchSub.Groups[1].ToString() + @":";
                });
                return match.Groups[1].ToString() + jsonSubStr + match.Groups[3].ToString();
            });

            File.WriteAllBytes(path, EncryptString.Compress(json));
        }
    }
}
