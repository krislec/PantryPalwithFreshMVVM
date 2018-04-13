using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PantryPalwithFreshMVVM.Models
{
    [Table("Recipes")]
    //represents the data stored in the table

    public class Recipe
    {

        //PrimaryKey - tells SQLite that this colomn is going to be the primary key of the table-needs to be unique and an index is applied to speed up retrievals
        //AutoIncrement - when new "item" is inserted into table the ID column will populate automatically  
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }//unique ID that is used to refer to specific "item"
        [Column("Category")]
        public string CategoryOfRecipe { get; set; }

        [Column("Recipe")]
        [NotNull, MaxLength(100)]
        public string NameOfRecipe { get; set; }

        [Column("Quantity Of Ingrediant")]
        public string QuantityOfIngrediants { get; set; }

        [Column("Measurement of Ingrediant")]
        public string MeasurementOfIngrediants { get; set; }

        [Column("Ingrediant")]
        public string Ingrediants { get; set; }

        [Column("Comments")]
        public string Comments { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(NameOfRecipe);
        }

        private string _recipeQuantityMeasurement;
        public string RecipeQuantityMeasurement
        {
            get
            {
                return QuantityOfIngrediants + " " + MeasurementOfIngrediants;
            }

            set
            {
                _recipeQuantityMeasurement = value;
            }
        }

        public static implicit operator Recipe(Pantry v)
        {
            throw new NotImplementedException();
        }
    }
}
