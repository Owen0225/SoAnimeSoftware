using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using SoAnimeSoftware.Hack.Misc.MovementRecorder;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Hack.Misc.MovementRecorder
{
    unsafe class Replays : List<Record>
    {
        private readonly string _path;

        public Replays(string path = null)
        {
            _path = string.IsNullOrEmpty(path) ? _path : path;
        }
        

        public void Save(Record record, string path = null)
        {
            try
            {
                string regexSearch =
                    new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

                Directory.CreateDirectory(_path);
                path = string.IsNullOrEmpty(path) ? _path : Path.Combine(_path, path);
                
                Directory.CreateDirectory(path);
                path = Path.Combine(path, r.Replace(record.Title, "_") + ".mr");

                int size = Marshal.SizeOf(record);
                byte[] arr = new byte[size];

                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(record, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                File.WriteAllBytes(path, arr);

                Marshal.FreeHGlobal(ptr);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public void Delete(Record record)
        {
            try
            {
                Save(record, "Deleted");
                string regexSearch =
                    new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                File.Delete(Path.Combine(_path, r.Replace(record.Title, "_") + ".mr"));
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public void Load()
        {
            try
            {
                Directory.CreateDirectory(_path);
                foreach (var fileName in Directory.GetFiles(_path))
                {
                    var path = Path.Combine(_path, fileName);
                    if (Path.GetExtension(Path.Combine(path, fileName)) == ".mr")
                    {
                        var record = new Record();
                        int size = Marshal.SizeOf(record);
                        IntPtr ptr = Marshal.AllocHGlobal(size);

                        Marshal.Copy(File.ReadAllBytes(path), 0, ptr, size);

                        record = (Record) Marshal.PtrToStructure(ptr, record.GetType());
                        Marshal.FreeHGlobal(ptr);

                        record.Title = Path.GetFileNameWithoutExtension(path);
                        record.LevelName = record.LevelName.Replace("_scrimmagemap", string.Empty);
                        base.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public void Refresh()
        {
            base.Clear();
            Load();
        }
    }
}