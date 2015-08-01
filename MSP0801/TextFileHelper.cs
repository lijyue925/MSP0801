using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;

namespace MSP0801
{
    public class TextFileHelper
    {
        async public static Task<bool> SaveTextFileAsync(string filename, string data)
        {
            byte[] filebytes = Encoding.UTF8.GetBytes(data);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            var file = await localfolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            try
            {
                using (var stream = await file.OpenStreamForWriteAsync())
                { await stream.WriteAsync(filebytes, 0, filebytes.Length); }
                return true;
            }
            catch
            { return false; }
        }

        async public static Task<string> LoadTextFileAsync(string filename)
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            string result = string.Empty;
            try
            {
                using (var stream = await localfolder.OpenStreamForReadAsync(filename))
                {
                    byte[] filebytes = new byte[stream.Length];
                    await stream.ReadAsync(filebytes, 0, filebytes.Length);
                    result = Encoding.UTF8.GetString(filebytes, 0, filebytes.Length);
                }
                return result;
            }
            catch
            { return result; }
        }
    }
}
