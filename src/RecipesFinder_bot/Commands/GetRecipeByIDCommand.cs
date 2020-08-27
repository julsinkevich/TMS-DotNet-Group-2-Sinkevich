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
    public class GetRecipeByIDCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = ID.Text;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                var recipeID = int.Parse(message.Text.GetQuery());
                var recipeString = GetID(recipeID);
                await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F525 {ID.Message} ");
                if (recipeString.Count() > 0)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, recipeString);
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"\U0001F640 {ID.MessageEx} ");
                }
            }
            catch (Exception ex)
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"{ID.Exception},{ex.Message} \U0001F4A9");
            }
        }
        private string GetID(int id)
        {
            var recipe = GetRecipeByID(id).GetAwaiter().GetResult();
            return "\n Title: " + recipe.title + "\n Instructions: " + recipe.instructions + "\n" + recipe.image;
           // return "\n Title:" + recipe.title + "\n Summary:" + recipe.summary + "\n Instructions:" + recipe.instructions + "\n" + recipe.image;
        }
        /// <summary>
        /// Способ приготовления рецепта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static async Task<RecipesFinder_bot.Models.Spoonacular.recipes.RecipesFound.Example> GetRecipeByID(int id)
        {
            return await "https://api.spoonacular.com"
                .AppendPathSegments("recipes", id, "information")
                .SetQueryParams(new { includeNutrition = false, apiKey = "d67605a945664091b46863dfb731c31a" })

                .GetJsonAsync<RecipesFinder_bot.Models.Spoonacular.recipes.RecipesFound.Example>();
        }
        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
