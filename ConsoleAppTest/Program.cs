using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleAppTest
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
            return await "https://api.spoonacular.com/recipes/findByIngredients"
                .AppendPathSegment(ingridients)
                //.WithOAuthBearerToken("my_oauth_token")
                .GetJsonAsync<UsedIngredient>();
        }
    }
  /*  private static async Task<Meal> MethodAsync()
     {
            return await "https://www.themealdb.com/api/json/v1/1"//https://www.themealdb.com/api/json/v1/1/filter.php?i=chicken_breast
                .AppendPathSegment("person")
                .SetQueryParams(new { a = 1, b = 2 })
                .WithOAuthBearerToken("my_oauth_token")
                .PostJsonAsync(new
                {
                    first_name = "Claire",
                    last_name = "Underwood"
                })
                .ReceiveJson<Meal>();
    }*/
}

