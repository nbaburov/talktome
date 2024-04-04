namespace SharedLibrary.Models
{

    public class Post
    {
        public int PostId { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string? Text { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
