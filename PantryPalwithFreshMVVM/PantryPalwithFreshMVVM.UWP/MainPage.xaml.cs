using FreshMvvm;
using PantryPalwithFreshMVVM.Data;
using PantryPalwithFreshMVVM.UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PantryPalwithFreshMVVM.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var repository = new PantryPalDatabase(FileAccessHelper.GetLocalFilePath("PantryPal.db3"));
            FreshIOC.Container.Register(repository);

            LoadApplication(new PantryPalwithFreshMVVM.App());

        }
    }
}
