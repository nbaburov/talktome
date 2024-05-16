namespace SharedLibrary.Models;

public class FlagUser : Flag
{
    public int ToUserId { get; set; }
    public virtual User ToUser { get; set; }
    public string Reason { get; set; }
}