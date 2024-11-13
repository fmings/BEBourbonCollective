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
                OpenBottle = true,
                EmptyBottle = false,
            },

            new Bourbon
            {
                Id = 2,
                UserId = 1,
                DistilleryId = 2,
                Name = "Straight Bourbon Whiskey",
                OpenBottle = false,
                EmptyBottle = false,
            },
        };
    }
}
