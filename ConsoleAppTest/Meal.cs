using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest
{
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
