using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace server.Core.Entities;

public class User
{
    [Required] public Guid Id { get; set; }
    [Required] public string Login { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string VisibleName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public List<Board> CreatedBoards { get; set; } = [];
    [JsonIgnore]
    public List<Board> Boards { get; set; } = [];
}
