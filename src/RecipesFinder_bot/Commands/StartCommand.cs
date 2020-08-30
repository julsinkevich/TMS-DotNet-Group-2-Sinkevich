using RecipesFinder_bot.Resources;
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
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, $"{Start.Message} \U0001F369");
            await client.SendTextMessageAsync(chatId, $"{Start.Message1} \U0001F389 \n{Start.MessageCommandAbout} \U0001F63C \n{Start.MessageCommandRecipe} \U0001F34C \n{Start.MessageCommandID} \U0001F608 \n{Start.MessageCommandIng} \U0001F367");
            await client.SendTextMessageAsync(chatId, $"{Start.MessageLaziness} \U0001F47B \n{Start.MessageDelivio} \U0001F47D \n{Start.MessageMenu} \U0001F525 \n{Start.MessageKoko} \U0001F428");
        }
        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
