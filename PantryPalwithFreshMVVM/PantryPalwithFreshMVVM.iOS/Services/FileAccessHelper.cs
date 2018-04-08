using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Foundation;
using UIKit;

namespace PantryPalwithFreshMVVM.iOS.Services
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
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "..", "Library");

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return Path.Combine(path, filename);
        }
    }
}
}