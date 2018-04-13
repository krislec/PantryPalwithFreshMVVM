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
    public class PantryAddPageModel : FreshBasePageModel
    {
        
            private Pantry _pantry;
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
                        await _pantrypaldatabase.PantryDeleteAsync(_pantry);
                        await CoreMethods.PopPageModel(_pantry);
                    });
                }
            }

            /// <summary>
            ///     The reminder's name for data binding.
            /// </summary>
            public string NameOfItem
            {
                get => _pantry.NameOfItem;
                set
                {
                    _pantry.NameOfItem = value;
                    RaisePropertyChanged();
                }
            }

            /// <summary>
            ///     The reminder's notes for data binding.
            /// </summary>
            public string Quantity
            {
                get => _pantry.Quantity;
                set
                {
                    _pantry.Quantity = value;
                    RaisePropertyChanged();
                }
            }

        /// <summary>
        ///     The reminder's notes for data binding.
        /// </summary>
        public string Measurement
        {
            get => _pantry.Measurement;
            set
            {
                _pantry.Measurement = value;
                RaisePropertyChanged();
            }
        }

        public string QuantityMeasurement
        {
            get => _pantry.QuantityMeasurement;
            set
            {
                _pantry.QuantityMeasurement = value;
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
                        if (_pantry.IsValid())
                        {
                            await _pantrypaldatabase.PantrySaveAsync(_pantry);
                            await CoreMethods.PopPageModel(_pantry);
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
                _pantry = initData as Pantry;
                if (_pantry == null) _pantry = new Pantry();
                base.Init(initData);
                RaisePropertyChanged(string.Empty);
            }
        }
    }

