﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RecipesFinder_bot.Commands
{
    /// <summary>
    /// Represents the response for TelegramBot unknown command.
    /// </summary>
    internal class UnknownCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = string.Empty;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Sorry, this command is unknown to me. Please, try again...");
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
