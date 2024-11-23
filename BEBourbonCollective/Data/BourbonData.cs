using System.Diagnostics;

namespace BEBourbonCollective.Models
{
    public class BourbonData
    {
        public static List<Bourbon> Bourbons = new List<Bourbon>()
        {
            new Bourbon
            {
                Id = 1,
                UserId = 1,
                DistilleryId = 1,
                Name = "Buffalo Trace Kentucky Straight Bourbon Whiskey",
                Image= "https://curiada.com/cdn/shop/products/BuffaloTrace1LTransp_1024x1024.png?v=1669377439",
            },

            new Bourbon
            {
                Id = 2,
                UserId = 1,
                DistilleryId = 2,
                Name = "Straight Bourbon Whiskey",
                Image="https://whiskyandwhiskey.com/cdn/shop/products/Bourbon-Bottle.png?v=1654035434",
            },
        };
    }
}
