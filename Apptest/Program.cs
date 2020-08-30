using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Apptest
{
    public class Program
    {
        static void Main(string[] args)
        { //Степа
            var IngridientSearch = SearchingByIngridient("chicken").GetAwaiter().GetResult();
            var recipesList = IngridientSearch.hits;
            foreach (var hit in recipesList)
            {
                Console.WriteLine(hit.recipe.label);
            }
            Console.ReadLine();

            var text = Console.ReadLine();
            string[] array = { "/start", "/about", "/ingredients", "/links", "/id" };
            foreach (var str in array)
            {
                if (str != text)
                {
                    Console.WriteLine(string.Format("Слово не {0} содержится в массиве", text));
                }
            }
            //Влад
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
        //private static async Task<RecipesFinder_bot.Models.Edamam.Example> SearchingByIngridient(string ing)
        private string GetRecipes(string ingredient)
        {
            var recipes = SearchingByIngridient(ingredient.GetQuery()).GetAwaiter().GetResult();
            var recipesStrList = recipes.hits.Select(x => "\n Title: " + x.recipe.label + "\n ID number: " + x.recipe.url + "\n" + x.recipe.image);
            return string.Join('\n', recipesStrList);
        }
        private static async Task<RecipesFinder_bot.Models.Edamam.Example> SearchingByIngridient(string ing)
        {
            //Cтепа
            //https://api.edamam.com/search?q=chicken&app_id=99c455ab&app_key=6e0062c1d84944adeb430d95976c1c69&from=0&to=3
            return await "https://api.edamam.com/search"
                .SetQueryParams(new { q = ing, app_id = "99c455ab", app_key = "6e0062c1d84944adeb430d95976c1c69" })
                .GetJsonAsync<RecipesFinder_bot.Models.Edamam.Example>();
        }
        /// <summary>
        /// Поиск рецепта по игредиентам 
        /// </summary>
        /// <param name="ing"></param>
        /// <returns></returns>
        private static async Task<IList<RecipesFinder_bot.Models.Spoonacular.Example>> SearcingByIngridients(string ing)
        {
            return await "https://api.spoonacular.com"
                .AppendPathSegments("recipes", "findByIngredients")
                .SetQueryParams(new
                {
                    apiKey = "d67605a945664091b46863dfb731c31a",
                    ingredients = ing,
                    limitLicense = true,
                    instructionsRequired = true,
                    veryPopular = true
                })
                .GetJsonAsync<IList<RecipesFinder_bot.Models.Spoonacular.Example>>();
        }
        /// <summary>
        /// cСпособ приготовления рецепта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static async Task<RecipesFinder_bot.Models.Spoonacular.RecipesFound.Example> SearcingRecipes(int id)
        {
            return await "https://api.spoonacular.com"
                .AppendPathSegments("recipes", id, "information")
                .SetQueryParams(new { includeNutrition = false, apiKey = "d67605a945664091b46863dfb731c31a" })

                .GetJsonAsync<RecipesFinder_bot.Models.Spoonacular.RecipesFound.Example>();
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



