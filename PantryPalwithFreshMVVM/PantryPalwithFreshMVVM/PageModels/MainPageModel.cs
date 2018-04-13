using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using PantryPalwithFreshMVVM.Models;
using PantryPalwithFreshMVVM.Data;
using System.Windows.Input;
using Xamarin.Forms;




namespace PantryPalwithFreshMVVM.PageModels
{
    public class MainPageModel : FreshBasePageModel
    {
        public ICommand PantryCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<PantryDetailPageModel>();
                });
            }
        }

        //public ICommand RecipeCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //       {
        //           await CoreMethods.PushPageModel<RecipePageModel>();
        //       });
        //    }
        //}

        //public ICommand ShoppingListCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            await CoreMethods.PushPageModel<ShoppingListPageModel>();
        //        });
        //    }
        //}

    }
}

