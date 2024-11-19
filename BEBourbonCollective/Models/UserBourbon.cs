namespace BEBourbonCollective.Models
{
    public class UserBourbon
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BourbonId { get; set; }
        public Bourbon Bourbon { get; set; }
    }
}
