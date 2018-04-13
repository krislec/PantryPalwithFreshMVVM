using FreshMvvm;
using PantryPalwithFreshMVVM.Data;
using PantryPalwithFreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PantryPalwithFreshMVVM.PageModels
{
    class RecipeAddPageModel : FreshBasePageModel
    {
        private Recipe _recipe;
        private PantryPalDatabase _pantrypaldatabase = FreshIOC.Container.Resolve<PantryPalDatabase>();


        /// <summary>
        ///     Delete the reminder from permanent storage.
        /// </summary>
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

        /// <summary>
        ///     The reminder's notes for data binding.
        /// </summary>
        public string Ingrediants
        {
            get => _recipe.Ingrediants;
            set
            {
                _recipe.Ingrediants = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The reminder's notes for data binding.
        /// </summary>
        public string MeasurementOfIngrediants
        {
            get => _recipe.MeasurementOfIngrediants;
            set
            {
                _recipe.MeasurementOfIngrediants = value;
                RaisePropertyChanged();
            }
        }

        public string QuantityOfIngrediants
        {
            get => _recipe.QuantityOfIngrediants;
            set
            {
                _recipe.QuantityOfIngrediants = value;
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

        public string QuantityMeasurement
        {
            get => _recipe.RecipeQuantityMeasurement;
            set
            {
                _recipe.RecipeQuantityMeasurement = value;
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
            base.Init(initData);
            RaisePropertyChanged(string.Empty);
        }
    }
}

