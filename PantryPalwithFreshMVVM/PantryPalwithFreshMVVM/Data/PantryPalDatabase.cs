using System;
using System.Collections.Generic;
using System.Text;
using PantryPalwithFreshMVVM.Models;
using SQLite;
using System.Threading.Tasks;

namespace PantryPalwithFreshMVVM.Data
{
    //interface for reading and writing the data
    public class PantryPalDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        
        //connect to the database //
        public PantryPalDatabase(string path)
        {
            _database = new SQLiteAsyncConnection(path);
            _database.CreateTableAsync<Pantry>().Wait();
            _database.CreateTableAsync<Recipe>().Wait();
        }

        //Pantry Item section of the database
        //Delete from database//
        public async Task PantryDeleteAsync(Pantry pantryItem)
        {
            var result = await _database.DeleteAsync(pantryItem).ConfigureAwait(false);
        }

        //Get All from database//
        public async Task<List<Pantry>> PantryGetAllAsync()
        {
            return await _database.Table<Pantry>().ToListAsync();
        }

        // to save to database
        public async Task PantrySaveAsync(Pantry pantryItem)
        {
            //do not allow save of invalid data//
            if (!pantryItem.IsValid()) throw new ApplicationException("Pantry Item is not valid.");

            // insert new or update existing//
            await _database.InsertOrReplaceAsync(pantryItem).ConfigureAwait(false);

        }



        // Recipe section of Database 

        //Delete from database//
        public async Task RecipeDeleteAsync(Recipe recipeItem)
        {
            var result = await _database.DeleteAsync(recipeItem).ConfigureAwait(false);
        }

        //Get All from database//
        public async Task<List<Recipe>> RecipeGetAllAsync()
        {
            return await _database.Table<Recipe>().ToListAsync();
        }

        // to save to database
        public async Task RecipeSaveAsync(Recipe recipeItem)
        {
            //do not allow save of invalid data//
            if (!recipeItem.IsValid()) throw new ApplicationException("Recipe Item is not valid.");

            // insert new or update existing//
            await _database.InsertOrReplaceAsync(recipeItem).ConfigureAwait(false);

        }

    }
}
