using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace ForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var IngridientSearc = SearcingByIngridients("apple").GetAwaiter().GetResult();
            Console.WriteLine(IngridientSearc.originalName);
            Console.ReadLine();
        }

        private static async Task<UsedIngredient> SearcingByIngridients(string ingridients)
        {
            return await "https://api.spoonacular.com/recipes/findByIngredients?apiKey=d67605a945664091b46863dfb731c31a"
                .AppendPathSegment(ingridients)
                //.WithOAuthBearerToken("my_oauth_token")
                .GetJsonAsync<UsedIngredient>();
        } 
    }
}



