using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace PantryPalwithFreshMVVM.Models
{
    
    [Table("Recipes")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }

        [Column("Recipe")]
        [NotNull, MaxLength(100)]
        public string NameOfRecipe { get; set; }

        [Column("Comments")]
        public string Comments { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(NameOfRecipe);
        }

        public static implicit operator Recipe(Pantry v)
        {
            throw new NotImplementedException();
        }
    }

}

   
   



