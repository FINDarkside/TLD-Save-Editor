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
                saves.AddRange((from f in Directory.GetFiles(folder) where reg.IsMatch(Path.GetFileName(f)) select f).ToList<string>());

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

        public static ObservableCollection<EnumerationMember> GetUWPSaveFiles()
        {
            // Ugly code, maybe fix
            var result = new ObservableCollection<EnumerationMember>();
            var saveFolder = GetUWPPath();
            if (saveFolder == null)
                return result;

            foreach (string file in Directory.GetFiles(saveFolder))
            {
                if (Path.GetFileName(file).StartsWith("container"))
                    continue;
                try
                {
                    var member = CreateSaveEnumerationMember(file, "UWP");
                    result.Add(member);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return result;
        }


        private static EnumerationMember CreateSaveEnumerationMember(string file, string name)
        {
            var member = new EnumerationMember();
            member.Value = file;

            var slotJson = EncryptString.DecompressBytes(File.ReadAllBytes(file));
            var slotData = new DynamicSerializable<SlotData>(slotJson).Obj;

            member.Description = slotData.m_DisplayName + " (" + name + ")";

            return member;
        }

        public static string GetUWPPath()
        {
            try
            {
                var packages = Path.Combine(GetLocalPath(), "packages");
                string hinterlandFolder = Directory.EnumerateDirectories(packages).First(
                    dir => Path.GetFileName(dir).StartsWith("27620HinterlandStudio.")
                );
                hinterlandFolder = Path.Combine(hinterlandFolder, "SystemAppData", "wgs");
                string saveFolder = Directory.GetDirectories(Directory.GetDirectories(hinterlandFolder)[0])[0];
                if (!Directory.Exists(saveFolder))
                    return null;

                return saveFolder;

            }
            catch (Exception)
            {
                return null;
            }
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
