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
    public class IngredientAddPageModel : FreshBasePageModel

    {

        private Ingredient _ingredient;

        private PantryPalDatabase _pantrypaldatabase = FreshIOC.Container.Resolve<PantryPalDatabase>();

        public string Ingredients
        {
            get => _ingredient.NameOfIngredient;
            set
            {
                _ingredient.NameOfIngredient = value;
                RaisePropertyChanged();
            }
        }


        public string Unit_of_Measurement
        {
            get => _ingredient.unit_of_measurement;
            set
            {
                _ingredient.unit_of_measurement = value;
                RaisePropertyChanged();
            }
        }

        public string QuantityOfIngredients
        {
            get => _ingredient.quantityOfIngredient;
            set
            {
                _ingredient.quantityOfIngredient = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Save the ingredient to permanent storage.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (_ingredient.IsValid())
                    {
                        await _pantrypaldatabase.IngredientSaveAsync(_ingredient);
                        await CoreMethods.PopPageModel(_ingredient);
                    }
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _pantrypaldatabase.IngredientDeleteAsync(_ingredient);
                    await CoreMethods.PopPageModel(_ingredient);
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

            _ingredient = initData as Ingredient;
            if (_ingredient == null) _ingredient = new Ingredient();

            Load();

            base.Init(initData);
            RaisePropertyChanged(string.Empty);
        }
        public ObservableCollection<Ingredient> IngredientItems { get; set; }

        private void Load()
        {
            //IngredientItems.Clear();
            if (_ingredient.ID != null)
            {
                var items = Task.Run(() => _pantrypaldatabase.IngredientGetByRecipeAsync((int)_ingredient.ID)).Result;
                foreach (var ingredient in items) IngredientItems.Add(ingredient);
            }


        }
    }

}


