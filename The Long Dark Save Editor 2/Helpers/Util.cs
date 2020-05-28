using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using The_Long_Dark_Save_Editor_2.Game_data;

namespace The_Long_Dark_Save_Editor_2.Helpers
{

    public class SlotDataDisplayNameProxy
    {
        public string m_DisplayName { get; set; }
    }

    public static class Util
    {
        private static readonly object IsDebug;

        public static T DeserializeObject<T>(string json) where T : class
        {

            if (json == null)
                return null;

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T DeserializeObjectOrDefault<T>(string json) where T : class, new()
        {
            if (json == null)
                return new T();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeObject(object o)
        {
            if (o == null)
                return null;
            return JsonConvert.SerializeObject(o);
        }

        public static ObservableCollection<EnumerationMember> GetSaveFiles(string folder)
        {

            Regex reg = new Regex("^(ep[0-9])?(sandbox|challenge|story|relentless)[0-9]+$");
            var saves = new List<string>();
            if (Directory.Exists(folder))
                saves.AddRange((from f in Directory.GetFiles(folder) orderby new FileInfo(f).LastWriteTime descending where reg.IsMatch(Path.GetFileName(f)) select f).ToList<string>());

            var result = new ObservableCollection<EnumerationMember>();
            foreach (string saveFile in saves)
            {
                try
                {
                    var member = CreateSaveEnumerationMember(saveFile, Path.GetFileName(saveFile));
                    result.Add(member);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    continue;
                }
            }

            return result;
        }

        private static EnumerationMember CreateSaveEnumerationMember(string file, string name)
        {
            var member = new EnumerationMember();
            member.Value = file;

            var slotJson = EncryptString.Decompress(File.ReadAllBytes(file));
            var slotData = JsonConvert.DeserializeObject<SlotDataDisplayNameProxy>(slotJson);

            member.Description = slotData.m_DisplayName + " (" + name + ")";

            return member;
        }

        public static string GetLocalPath()
        {
            Guid localLowId = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
            return GetKnownFolderPath(localLowId).Replace("LocalLow", "Local");
        }

        private static string GetKnownFolderPath(Guid knownFolderId)
        {
            IntPtr pszPath = IntPtr.Zero;
            try
            {
                int hr = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);
                if (hr >= 0)
                    return Marshal.PtrToStringAuto(pszPath);
                throw Marshal.GetExceptionForHR(hr);
            }
            finally
            {
                if (pszPath != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pszPath);
            }
        }

        [DllImport("shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);
    }
}
