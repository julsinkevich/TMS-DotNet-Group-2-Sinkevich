using RecipesFinder_bot.Commands;
using System.Collections.Generic;

namespace RecipesFinder_bot.Interfaces
{  
    /// <summary>
     /// Commands management service.
     /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// Get all available commands.
        /// </summary>
        /// <returns>Command list.</returns>
        IEnumerable<ITelegramCommand> Get();
    }
}
