using RecipesFinder_bot.Models;
using RecipesFinder_bot.Resources;
using RecipesFinder_bot.Services;
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
    public class IngredientCommand : ITelegramCommand
    {
        private readonly API_Config _api;
        public IngredientCommand(API_Config api)
        {
            if (api == null)
            {
                throw new ArgumentNullException(nameof(api));
            }
            else
            {
                _api = api;
            }
        }
        /// <inheritdoc/>
        public string Name { get; } = Ingredient.Link;


        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                var chatId = message.Chat.Id;

                var httpHandler = new HttpHandler();
                var result = await httpHandler.GetRequest("https://api.spoonacular.com/", "recipes/findByIngredients", _api.api_key);

                await client.SendTextMessageAsync(chatId, $"\n{result.name} \n{result.originalName}\n{result.image}");
            }
            catch
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"Sorry, we have problem with request, please, try again...");
            }
        }
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
