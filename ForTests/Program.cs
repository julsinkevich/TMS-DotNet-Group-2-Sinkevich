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
<<<<<<< HEAD
           
       {//Влад
            var RecipeSearch = SearchingByRecipe(586662).GetAwaiter().GetResult();
            var recipe = RecipeSearch.extendedIngredients;
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe)
            {
                Console.WriteLine(ingredient.original);
            }

            Console.WriteLine("\nSummmary:");
            Console.WriteLine(RecipeSearch.summary);

            Console.WriteLine("\nInstructions:");
            Console.WriteLine(RecipeSearch.instructions);

            Console.WriteLine("\nAnalyzed instructions:");
            var instructions = RecipeSearch.analyzedInstructions;
            foreach (var instruction in instructions)
            {
                foreach (var step in instruction.steps)
                {
                    Console.WriteLine();
                    Console.WriteLine(step.number + " - " + step.step);
                    foreach (var i in step.ingredients)
                    {
                        Console.WriteLine(i.image);
                    }
                }
            }
            //Степа
            var IngridientSearch = SearchingByIngridient("chicken").GetAwaiter().GetResult();
            var recipesList = IngridientSearch.hits;
            foreach (var hit in recipesList)
            {
                Console.WriteLine(hit.recipe.label);
            }
            Console.ReadLine();
        }

        private static async Task<RecipesFinder_bot.Models.SpoonacularRecipe.Example> SearchingByRecipe(int ing)
        {//Влад
            //https://api.spoonacular.com/recipes/586662/information?includeNutrition=false&apiKey=d67605a945664091b46863dfb731c31a
            return await "https://api.spoonacular.com"
                .AppendPathSegments("recipes", ing, "information")
                .SetQueryParams(new { includeNutrition = false, apiKey = "d67605a945664091b46863dfb731c31a" })
                .GetJsonAsync<RecipesFinder_bot.Models.SpoonacularRecipe.Example>();
        }

        //private static async Task<RecipesFinder_bot.Models.Edamam.Example> SearchingByIngridient(string ing)
        //{
        //    //https://api.edamam.com/search?q=chicken&app_id=99c455ab&app_key=6e0062c1d84944adeb430d95976c1c69&from=0&to=3
        //    return await "https://api.edamam.com/search"
        //        .SetQueryParams(new { q = ing, app_id = "99c455ab", app_key = "6e0062c1d84944adeb430d95976c1c69", from = 0, to = 1 })
        //        .GetJsonAsync<RecipesFinder_bot.Models.Edamam.Example>();
        //}

        private static async Task<RecipesFinder_bot.Models.Edamam.Example> SearchingByIngridient(string ing)
        {//Степа
            //https://api.edamam.com/search?q=chicken&app_id=99c455ab&app_key=6e0062c1d84944adeb430d95976c1c69&from=0&to=3
            return await "https://api.edamam.com/search"
                .SetQueryParams(new { q = ing, app_id = "99c455ab", app_key = "6e0062c1d84944adeb430d95976c1c69" })
                .GetJsonAsync<RecipesFinder_bot.Models.Edamam.Example>();
=======
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
>>>>>>> spoonacular-API
        }
    }
}



