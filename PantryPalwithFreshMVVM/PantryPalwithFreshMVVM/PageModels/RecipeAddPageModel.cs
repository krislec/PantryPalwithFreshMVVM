using FreshMvvm;
using PantryPalwithFreshMVVM.Data;
using PantryPalwithFreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PantryPalwithFreshMVVM.PageModels
{
    public class RecipeAddPageModel : FreshBasePageModel
    {
        private Recipe _recipe;
        
        private PantryPalDatabase _pantrypaldatabase = FreshIOC.Container.Resolve<PantryPalDatabase>();

      public RecipeAddPageModel()
        {
            IngredientItems = new ObservableCollection<Ingredient>();
        }


        public ObservableCollection<Ingredient> IngredientItems { get; set; }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _pantrypaldatabase.RecipeDeleteAsync(_recipe);
                    await CoreMethods.PopPageModel(_recipe);
                });
            }
        }

        /// <summary>
        ///     The reminder's name for data binding.
        /// </summary>
        public string NameOfRecipe
        {
            get => _recipe.NameOfRecipe;
            set
            {
                _recipe.NameOfRecipe = value;
                RaisePropertyChanged();
            }
        }

   
        

        public string Comments
        {
            get => _recipe.Comments;
            set
            {
                _recipe.Comments = value;
                RaisePropertyChanged();
            }
        }

       



        /// <summary>
        ///     Save the reminder to permanent storage.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (_recipe.IsValid())
                    {
                        await _pantrypaldatabase.RecipeSaveAsync(_recipe);
                        await CoreMethods.PopPageModel(_recipe);
                    }
                });
            }
        }

        /// <summary>
        ///     Called automatically by FreshMVVM when the page is navigated to.
        /// </summary>
        /// <param name="initData">
        ///     If supplied, use an existing model, otherwise start a new one.
        /// </param>
        public override void Init(object initData)
        {
        
            _recipe = initData as Recipe;
            if (_recipe == null) _recipe = new Recipe();

            Load();

            base.Init(initData);
            RaisePropertyChanged(string.Empty);
        }

        private void Load()
        {
            IngredientItems.Clear();
            if (_recipe.ID != null)
            {
                var items = Task.Run(() => _pantrypaldatabase.IngredientGetByRecipeAsync((int)_recipe.ID)).Result;
                foreach (var ingredient in items) IngredientItems.Add(ingredient);
            }

            
        }
    }
}

