using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities;

public class User
{
    [Required] public Guid Id { get; set; }
    [Required] public string Login { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string VisibleName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Board> CreatedBoards { get; set; } = [];
    public List<Board> Boards { get; set; } = [];
}
