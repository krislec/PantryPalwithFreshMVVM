using SQLite;


namespace PantryPalwithFreshMVVM.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
            [PrimaryKey, AutoIncrement]
            public int? ID { get; set; }

            public string NameOfIngredient { get; set; }
            public string quantityOfIngredient { get; set; }
            public string unit_of_measurement { get; set; }

            //[ForeignKey(typeof(Recipe))]
            public int RecipeID { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(NameOfIngredient);
        }

    }

    
}
