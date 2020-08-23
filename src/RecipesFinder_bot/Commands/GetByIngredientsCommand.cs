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
    public class GetByIngredientsCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Ingredient.Text;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var text = string.Empty;
            try
            {
                text = string.Format($"\U0001F525 {Ingredient.Message} ", GetIngredient(message.Text));
            }
            catch (Exception ex)
            {
                text = $"{Ingredient.Exception},{ex.Message} \U0001F4A9";
            }
            finally
            {
                await client.SendTextMessageAsync(message.Chat.Id, text);
            }
        }
        private string GetIngredient(string ingredient)
        {
            var IngridientSearch = SearchingByIngridient(ingredient).GetAwaiter().GetResult();
            var recipesList = IngridientSearch.hits.Select(x => x.recipe.label);
            return string.Join(',', recipesList);
            /* var searchParam = ingredient.ToLower().Replace("ingridient", "");
             var IngridientSearch = SearchingByIngridient(searchParam).GetAwaiter().GetResult();
             var recipesList = IngridientSearch.hits.Select(x => x.recipe.label);
             return string.Join(',', recipesList);*/

        }
        private static async Task<RecipesFinder_bot.Models.Edamam.Example> SearchingByIngridient(string ing)
        {//Степа
            //https://api.edamam.com/search?q=chicken&app_id=99c455ab&app_key=6e0062c1d84944adeb430d95976c1c69&from=0&to=3
            return await "https://api.edamam.com/search"
                .SetQueryParams(new { q = ing, app_id = "99c455ab", app_key = "6e0062c1d84944adeb430d95976c1c69" })
                .GetJsonAsync<RecipesFinder_bot.Models.Edamam.Example>();
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
