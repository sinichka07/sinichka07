using System.Collections.Generic;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public int ReleaseYear { get; set; }
    public List<string> Tracks { get; set; } = new List<string>();

    public override string ToString()
    {
        return $"{Title} by {Artist}, {ReleaseYear}";
    }
}
