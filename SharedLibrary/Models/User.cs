

namespace SharedLibrary.Models
{

    public abstract class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}

