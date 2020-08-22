using System.Collections.Generic;
using static RecipesFinder_bot.Models.Edamam;

namespace RecipesFinder_bot.Models
{
    public class Edamam
    {
        public class Ingredient
        {
            public string text { get; set; }
            public double weight { get; set; }
            public string image { get; set; }
        }
        
        public class Recipe
        {
            public string uri { get; set; }
            public string label { get; set; }
            public string image { get; set; }
            public string source { get; set; }
            public string url { get; set; }
            public string shareAs { get; set; }
            public double yield { get; set; }
            public IList<string> dietLabels { get; set; }
            public IList<string> healthLabels { get; set; }
            public IList<string> cautions { get; set; }
            public IList<string> ingredientLines { get; set; }
            public IList<Ingredient> ingredients { get; set; }
            public double calories { get; set; }
            public double totalWeight { get; set; }
            public double totalTime { get; set; }
        }

        public class Hit
        {
            public Recipe recipe { get; set; }
        }

        public class Example
        {
            public IList<Hit> hits { get; set; }
        }
    }
}
