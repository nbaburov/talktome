namespace SharedLibrary.Models;
public class Comment
{
    public int CommentId { get; set; }
    public DateTime CreationDate { get; set; }
    public string Text { get; set; }

    public int UserId { get; set; } 
    public virtual User User { get; set; }
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    
}

