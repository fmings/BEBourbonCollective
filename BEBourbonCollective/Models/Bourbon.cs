namespace BEBourbonCollective.Models
{
    public class Bourbon
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DistilleryId { get; set; }
        public Distillery Distillery { get; set; }
        public string Name { get; set; }
        public string ?Image { get; set; }

    }
}
