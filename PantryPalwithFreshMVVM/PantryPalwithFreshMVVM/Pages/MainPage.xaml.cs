using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PantryPalwithFreshMVVM.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : FreshBaseContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}
	}
}