using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using Xamarin.Forms;
using PantryPalwithFreshMVVM.PageModels;

namespace PantryPalwithFreshMVVM
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<PantryAddPageModel>();
            MainPage = new FreshNavigationContainer(page);
            
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
