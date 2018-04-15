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
    public class PantryDetailPageModel : FreshBasePageModel
    {
        private PantryPalDatabase _pantrypaldatabase = FreshIOC.Container.Resolve<PantryPalDatabase>();
        private Pantry _selectedPantry = null;

        public PantryDetailPageModel()
        {
            PantryItems = new ObservableCollection<Pantry>();
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<PantryAddPageModel>();
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async (pantry) =>
                {
                    await CoreMethods.PushPageModel<PantryAddPageModel>(pantry);
                });

            }
        }

        public ObservableCollection<Pantry> PantryItems { get; set; }

        public Pantry Selected
        {
            get => _selectedPantry;
            set
            {
                _selectedPantry = value;
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
            PantryItems.Clear();
            var items = Task.Run(() => _pantrypaldatabase.PantryGetAllAsync()).Result;
            foreach (var pantry in items) PantryItems.Add(pantry);
        }
    }
}
