using System.Collections.Generic;

namespace RecipesFinder_bot.Models.Spoonacular
{
    public class Example
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public IList<MissedIngredient> missedIngredients { get; set; }
        public IList<UsedIngredient> usedIngredients { get; set; }
        public IList<UnusedIngredient> unusedIngredients { get; set; }
        public int likes { get; set; }
    }
}
