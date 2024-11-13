namespace BEBourbonCollective.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirebaseId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public ICollection<UserBourbon> UserBourbons { get; set; }
        public int NumberOfBourbons()
        {
            return UserBourbons?.Count ?? 0;
        }
    }
}
