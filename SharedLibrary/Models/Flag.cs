namespace SharedLibrary.Models;

public abstract class Flag
{
    public int FlagId { get; set; }
    public int FromUserId { get; set; }
    public virtual User FromUser { get; set; }
    public bool Resolved { get; set; }
    public DateTime CreationDate { get; set; }

}