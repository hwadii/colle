namespace Colle.Models;

public class Paste
{
    public Ulid Id { get; set; } = Ulid.NewUlid();
    public string Slug { get; set; } = String.Empty;
    public string Path { get; set; } = String.Empty;
}
