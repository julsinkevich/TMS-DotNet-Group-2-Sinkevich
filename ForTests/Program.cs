using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ForTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write ingredient");
            var userInputIngredients = Console.ReadLine();
            var userInput = "/ing " + userInputIngredients; 
            var query = userInput.GetQuery();
            var IngridientSearc = SearcingByIngridients(query).GetAwaiter().GetResult();
            foreach (var ingredient in IngridientSearc)
            {
                Console.WriteLine(ingredient.title);
            }
            Console.WriteLine();

            var SMelemet = IngridientSearc[0].id;

            var GetRecipe = SearcingRecipes(SMelemet).GetAwaiter().GetResult();

            var recipeInredient = GetRecipe.extendedIngredients;
            foreach (var item in recipeInredient)
            {
                Console.WriteLine(item.originalString);
            }
            Console.WriteLine(GetRecipe.instructions);

            Console.ReadLine();
        }

        /// <summary>
        /// Поиск рецепта по игредиентам 
        /// </summary>
        /// <param name="ing"></param>
        /// <returns></returns>
        private static async Task<IList <RecipesFinder_bot.Models.Spoonacular.Example>> SearcingByIngridients(string ing)
        {
            return await "https://api.spoonacular.com"
                .AppendPathSegments("recipes", "findByIngredients")
                .SetQueryParams(new { apiKey ="d67605a945664091b46863dfb731c31a", ingredients = ing, limitLicense = true, instructionsRequired = true,
                veryPopular = true
                })
                .GetJsonAsync<IList <RecipesFinder_bot.Models.Spoonacular.Example>>();
        }

        /// <summary>
        /// cСпособ приготовления рецепта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static async Task< RecipesFinder_bot.Models.Spoonacular.recipes.RecipesFound.Example> SearcingRecipes(int id)
        {
            return await "https://api.spoonacular.com"
                .AppendPathSegments("recipes", id, "information")
                .SetQueryParams(new { includeNutrition=false, apiKey = "d67605a945664091b46863dfb731c31a"})
                   
                .GetJsonAsync <RecipesFinder_bot.Models.Spoonacular.recipes.RecipesFound.Example>();
        }
    }

    //убирает ingredients из строки поиска. Но надо доработать 
    public static class User
    {
        public static string GetQuery(this string userInput)
        {
            var str = string.Empty;
            var words = userInput.Split(new char[] { ' ' }).Skip(1);
            foreach (var word in words)
            {
                str += $"{word},+";
            }

            return str.Remove(str.Length - 2); ;
        }
    }
}



