using Flurl;
using Flurl.Http;
using RecipesFinder_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RecipesFinder_bot.Models.Spoonacular;

namespace RecipesFinder_bot.Services
{
    /// <summary>
    /// Cтандартный HTTP Handler
    /// </summary>
    public class HttpHandler
    {
        /// <summary>
        /// Получение json файла.
        /// </summary>
        /// <param name="host">Сайт</param>
        /// <param name="path">Путь</param>
        /// <returns>json файл</returns>
        public async Task<MissedIngredient> GetRequest(string host, string path, string apiKey)
        {
            var res = await host.AppendPathSegment(path)
                                .SetQueryParams(new { api_key = apiKey })
                                .GetJsonAsync<MissedIngredient>();
            return res;
        }
    }
}
