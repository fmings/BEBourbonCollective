using System.ComponentModel.DataAnnotations.Schema;

namespace BEBourbonCollective.Models
{
    public class TradeRequest
    {
        public int Id { get; set; }
        
        [ForeignKey("RequestingUser")]
        public int RequestingUserId { get; set; }
        public User RequestingUser { get; set; }

        public int RequestingBourbonId { get; set; }
        public Bourbon RequestingFromBourbon { get; set; }

        [ForeignKey("RequestedFromUser")]
        public int RequestedFromUserId { get; set; }
        public User RequestedFromUser { get; set; }
        public int RequestedFromBourbonId { get; set; }
        public Bourbon RequestedFromBourbon { get; set; }
        public bool Pending { get; set; }
        public bool Approved { get; set; }

    }
}
