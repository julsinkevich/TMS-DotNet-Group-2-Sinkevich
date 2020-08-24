
using System.Collections.Generic;

namespace RecipesFinder_bot.Models.Spoonacular.recipes
{
    public class RecipesFound
    {
        public class Us
        {
            public double amount { get; set; }
            public string unitShort { get; set; }
            public string unitLong { get; set; }
        }

        public class Metric
        {
            public double amount { get; set; }
            public string unitShort { get; set; }
            public string unitLong { get; set; }
        }

        public class Measures
        {
            public Us us { get; set; }
            public Metric metric { get; set; }
        }

        public class ExtendedIngredient
        {
            public int id { get; set; }
            public string aisle { get; set; }
            public string image { get; set; }
            public string consistency { get; set; }
            public string name { get; set; }
            public string original { get; set; }
            public string originalString { get; set; }
            public string originalName { get; set; }
            public double amount { get; set; }
            public string unit { get; set; }
            public IList<string> meta { get; set; }
            public IList<string> metaInformation { get; set; }
            public Measures measures { get; set; }
        }

        public class WinePairing
        {
            public IList<object> pairedWines { get; set; }
            public string pairingText { get; set; }
            public IList<object> productMatches { get; set; }
        }

        public class Example
        {
            public bool vegetarian { get; set; }
            public bool vegan { get; set; }
            public bool glutenFree { get; set; }
            public bool dairyFree { get; set; }
            public bool veryHealthy { get; set; }
            public bool cheap { get; set; }
            public bool veryPopular { get; set; }
            public bool sustainable { get; set; }
            public int weightWatcherSmartPoints { get; set; }
            public string gaps { get; set; }
            public bool lowFodmap { get; set; }
            public int aggregateLikes { get; set; }
            public double spoonacularScore { get; set; }
            public double healthScore { get; set; }
            public string creditsText { get; set; }
            public string license { get; set; }
            public string sourceName { get; set; }
            public double pricePerServing { get; set; }
            public IList<ExtendedIngredient> extendedIngredients { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public int readyInMinutes { get; set; }
            public int servings { get; set; }
            public string sourceUrl { get; set; }
            public string image { get; set; }
            public string imageType { get; set; }
            public string summary { get; set; }
            public IList<object> cuisines { get; set; }
            public IList<string> dishTypes { get; set; }
            public IList<object> diets { get; set; }
            public IList<object> occasions { get; set; }
            public WinePairing winePairing { get; set; }
            public string instructions { get; set; }
            public IList<object> analyzedInstructions { get; set; }
            public object originalId { get; set; }
            public string spoonacularSourceUrl { get; set; }
        }
    }
}
