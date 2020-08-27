﻿using RecipesFinder_bot.Resources;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RecipesFinder_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class StartCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Start.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                var chatId = message.Chat.Id;
                await client.SendTextMessageAsync(chatId, $"{Start.Message} \U0001F369");
                await client.SendTextMessageAsync(chatId, $"\U0001F389 \n{Start.MessageCommandAbout} \U0001F63C \n{Start.MessageCommandRecipe} \U0001F34C \n{Start.MessageCommandID} \U0001F608");
                //await client.SendTextMessageAsync(chatId, $"{Start.MessageCommandIng} \U0001F374");
            }
            catch (Exception ex)
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"Sorry, we have problem with request, please, try again...");
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
