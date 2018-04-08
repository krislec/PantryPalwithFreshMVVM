using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PantryPalwithFreshMVVM.Droid.Services
{
    class FileAccessHelper
    {
        /// <summary>
        ///     Get a full file path.
        /// </summary>
        /// <param name="filename">Name of the file.</param>
        /// <returns>File with the path prepended.</returns>
        public static string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}