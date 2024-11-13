namespace BEBourbonCollective.Models
{
    public class UserBourbon
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int BourbonId { get; set; }
        public Bourbon Bourbon { get; set; }
    }
}
