using Flurl;
using Flurl.Http;
using RecipesFinder_bot.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RecipesFinder_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class GetRecipesByIngredientsCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Ingredients.Text;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                var recipes = GetRecipes(message.Text);
                //await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F525 {Ingredient.Message} ");
                if (recipes.Count() > 0)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F525 {Ingredients.Message} ");
                    foreach (var recipeString in recipes)
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, recipeString);
                    }
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F640 {Ingredients.MessageEx} ");
                }
            }
            catch (Exception ex)
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"{Ingredients.Exception},\n{ex.Message} \U0001F4A9");
            }
        }
        private IEnumerable<string> GetRecipes(string ingredient)
        {
            var recipes = GetRecipesByIngridient(ingredient.GetQuery()).GetAwaiter().GetResult();
            var recipesStrList = recipes.Select(x => "\n Title: " + x.title + "\n ID number: " + x.id + "\n" + x.image);
            return recipesStrList;
        }
        /// <summary>
        /// Поиск рецепта по игредиентам 
        /// </summary>
        /// <param name="ing"></param>
        /// <returns></returns>
        private static async Task<IList<Models.Spoonacular.Example>> GetRecipesByIngridient(string ing)
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
                .GetJsonAsync<IList<Models.Spoonacular.Example>>();
        }
        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
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
