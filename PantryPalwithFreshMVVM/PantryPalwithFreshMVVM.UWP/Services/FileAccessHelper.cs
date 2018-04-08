using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;


namespace PantryPalwithFreshMVVM.UWP.Services
{
    public class FileAccessHelper
    {
        /// <summary>
        ///     Get a full file path.
        /// </summary>
        /// <param name="filename">Name of the file.</param>
        /// <returns>File with the path prepended.</returns>
        public static string GetLocalFilePath(string filename)
        {
            var path = ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(path, filename);
        }
    }
}
