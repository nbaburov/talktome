namespace SharedLibrary.Models;



public class FlagPost : Flag
{
    public int PostId { get; set; }
    public virtual Post Post { get; set; }

}