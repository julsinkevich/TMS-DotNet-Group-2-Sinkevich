using Flurl;
using Flurl.Http;
using RecipesFinder_bot.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RecipesFinder_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class GetListIngredientsCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = ListIngredients.Text;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                var recipes = GetRecipes(message.Text);
                //await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F525 {Ingredient.Message} ");
                if (recipes.Count() > 1)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F525 {ListIngredients.Message} ");
                    await client.SendTextMessageAsync(message.Chat.Id, recipes);
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F640 {ListIngredients.MessageEx} ");
                }
            }
            catch (Exception ex)
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"{ListIngredients.Exception},{ex.Message} \U0001F4A9");
            }
        }
        private string GetRecipes(string ingredient)
        {
            //var recipes = GetListIngridient(ingredient.GetQuery()).GetAwaiter().GetResult();
            //var recipesStrList = recipes.hits(x => "\n Title:" + x.label + "\n ID number:" + x.ingredientLines + "\n" + x.image);
            //return recipesStrList;
            var IngridientSearch = GetListIngridient(ingredient).GetAwaiter().GetResult();
            var recipesList = IngridientSearch.hits.Select(x => "\n Title: " + x.recipe.label + "\n" + x.recipe.image);
            return string.Join('\n', recipesList);
        }
        /// <summary>
        /// Поиск рецепта по игредиентам 
        /// </summary>
        /// <param name="ing"></param>
        /// <returns></returns>
        private static async Task<RecipesFinder_bot.Models.Edamam.Example> GetListIngridient(string ing)
        {
            return await "https://api.edamam.com/search"
                .SetQueryParams(new { q = ing, app_id = "99c455ab", app_key = "6e0062c1d84944adeb430d95976c1c69" })
                .GetJsonAsync<RecipesFinder_bot.Models.Edamam.Example>();
        }
        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
