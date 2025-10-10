using System.Text.Json.Serialization;

namespace server.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonIgnore] public List<Board> CreatedBoards { get; set; } = [];
    [JsonIgnore] public List<UserBoardRole> Boards { get; set; } = [];
}
