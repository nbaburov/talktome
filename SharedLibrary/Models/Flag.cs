namespace SharedLibrary.Models;

public abstract class Flag
{
    public int FlagId { get; set; }
    public int FromUserId { get; set; }
    public virtual User FromUser { get; set; }
    public bool Resolved { get; set; }
    public DateTime CreationDate { get; set; }

}

public class FlagUser : Flag
{
    public int ToUserId { get; set; }
    public virtual User ToUser { get; set; }
    public string Reason { get; set; }
}

public class FlagPost : Flag
{
    public int PostId { get; set; }
    public virtual Post Post { get; set; }

}
public class FlagComment : Flag
{
    public int CommentId { get; set; }
    public virtual Comment Comment { get; set; }

}
