using Microsoft.Extensions.Options;
using RecipesFinder_bot.Commands;
using RecipesFinder_bot.Interfaces;
using System;
using System.Collections.Generic;

namespace RecipesFinder_bot.Models
{
    /// <inheritdoc cref="ICommandService"/>
    public class CommandService : ICommandService
    {
        private readonly IEnumerable<ITelegramCommand> _commands;

        /// <summary>
        /// Base constructor.
        /// </summary>
        public CommandService(IOptions<API_Config> options)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));
            _commands = new List<ITelegramCommand>
            {
                new StartCommand(),
                new AboutCommand(),
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ITelegramCommand> Get() => _commands;
    }
}
