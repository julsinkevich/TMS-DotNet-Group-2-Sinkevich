using System.Collections.Generic;

namespace RecipesFinder_bot.Models.Spoonacular
{
    public class UnusedIngredient
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public IList<object> metaInformation { get; set; }
        public IList<object> meta { get; set; }
        public string image { get; set; }
    }
}
