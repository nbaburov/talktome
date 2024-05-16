namespace SharedLibrary.Models;


public class FlagComment : Flag
{
    public int CommentId { get; set; }
    public virtual Comment Comment { get; set; }

}
