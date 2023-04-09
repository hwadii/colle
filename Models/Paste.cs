using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Colle.Models;

[Index(nameof(Checksum), IsUnique = true)]
public class Paste
{
    public string Id { get; set; } = Ulid.NewUlid().ToString();
    public string Checksum { get; set; } = String.Empty;
    public string Contents { get; set; } = String.Empty;
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
