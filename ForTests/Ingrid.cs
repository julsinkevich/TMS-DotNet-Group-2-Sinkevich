using System.Collections.Generic;

namespace ForTests
{
    
        public class MissedIngredient
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
            public IList<string> metaInformation { get; set; }
            public IList<string> meta { get; set; }
            public string extendedName { get; set; }
            public string image { get; set; }
        }

        public class UsedIngredient
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
            public IList<string> metaInformation { get; set; }
            public IList<string> meta { get; set; }
            public string extendedName { get; set; }
            public string image { get; set; }
        }

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
