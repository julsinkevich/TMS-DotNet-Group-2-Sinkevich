using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesFinder_bot.Models
{
    /*public class AppSettings
    {
        public static string Ur1 { get; set; } = "https://telegrambotapp.azurewebsites.net:443/{0}";
        public static string Name { get; set; } = "RecipesFinder_bot";
        public static string Key { get; set; } = "1148344323:AAEjZNPojEnCgeVdV4dBUO3ipXpKGDpwuMM";
    }
    */

    /// <summary>
    /// GET JSON запрос фильтр по основному ингредиент.https://www.themealdb.com/api.php
    /// </summary>
    public class Meal
    {
        /// <summary>
        /// Наименование блюда.
        /// </summary>
        public string strMeal { get; set; }

        /// <summary>
        /// Фотография блюда.
        /// </summary>
        public string strMealThumb { get; set; }

        /// <summary>
        /// Номер блюда.
        /// </summary>
        public string idMeal { get; set; }
    }

    /// <summary>
    /// Cписок.
    /// </summary>
    public class Example
    {
        public IList<Meal> meals { get; set; }
    }
}
