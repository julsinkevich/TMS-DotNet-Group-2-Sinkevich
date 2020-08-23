using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var IngridientSearch = SearchingByIngridient("chicken").GetAwaiter().GetResult();
            var recipesList = IngridientSearch.hits;
            foreach (var hit in recipesList)
            {
                Console.WriteLine(hit.recipe.label);
            }            
            Console.ReadLine();
        }

        private static async Task<RecipesFinder_bot.Models.Edamam.Example> SearchingByIngridient(string ing)
        {
            //https://api.edamam.com/search?q=chicken&app_id=99c455ab&app_key=6e0062c1d84944adeb430d95976c1c69&from=0&to=3
            return await "https://api.edamam.com/search"
                .SetQueryParams(new { q = ing, app_id = "99c455ab", app_key = "6e0062c1d84944adeb430d95976c1c69" })
                .GetJsonAsync<RecipesFinder_bot.Models.Edamam.Example>();
        }
    }    
}

