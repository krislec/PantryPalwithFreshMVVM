using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using PantryPalwithFreshMVVM.Data;
using PantryPalwithFreshMVVM.Models;
using Xamarin.Forms;

namespace PantryPalwithFreshMVVM.PageModels
{
    class RecipeDetailPageModel :FreshBasePageModel
    {
        private PantryPalDatabase _pantrypaldatabase = FreshIOC.Container.Resolve<PantryPalDatabase>();
        private Recipe _selectedRecipe = null;

        public RecipeDetailPageModel()
        {
            RecipeItems = new ObservableCollection<Recipe>();
        }


        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<RecipeAddPageModel>();
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async (recipe) =>
                {
                    await CoreMethods.PushPageModel<RecipeAddPageModel>(recipe);
                });

            }
        }

        public ObservableCollection<Recipe> RecipeItems { get; set; }

        public Recipe Selected
        {
            get => _selectedRecipe;

            set
            {
                _selectedRecipe = value;
                if (value != null) EditCommand.Execute(value);
            }
        }

        public override void Init(object initData)
        {
            Load();
        }

        public override void ReverseInit(object returnedData)
        {
            Load();
            base.ReverseInit(returnedData);
        }

        private void Load()
        {
            RecipeItems.Clear();
            var items = Task.Run(() => _pantrypaldatabase.RecipeGetAllAsync()).Result;
            foreach (var recipe in items) RecipeItems.Add(recipe);
        }
    }
}

