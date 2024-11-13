namespace BEBourbonCollective.Models
{
    public class TradeRequest
    {
        public int Id { get; set; }
        public string RequestingUserId { get; set; }
        public User RequestingUser { get; set; }
        public int RequestingBourbonId { get; set; }
        public Bourbon RequestingFromBourbon { get; set; }
        public string RequestedFromUserId { get; set; }
        public User RequestedFromUser { get; set; }
        public int RequestedFromBourbonId { get; set; }
        public Bourbon RequestedFromBourbon { get; set; }
        public bool Pending { get; set; }
        public bool Approved { get; set; }

    }
}
