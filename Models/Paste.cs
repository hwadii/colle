using Microsoft.EntityFrameworkCore;

namespace Colle.Models;

[Index(nameof(Checksum), IsUnique = true)]
public class Paste
{
    public string Id { get; set; } = Ulid.NewUlid().ToString();
    public string Checksum { get; set; } = String.Empty;
    public string Path { get; set; } = String.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
