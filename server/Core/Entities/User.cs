using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities;

public class User
{
    [Required] public Guid Id { get; set; }
    [Required] public string Login { get; set; }
    [Required] public string Password { get; set; }
    public string Email { get; set; } = string.Empty;
    public string VisibleName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<UserBoards> UserBoards { get; set; } = [];
    public List<Board> Boards => UserBoards.Select(ub => ub.Board).ToList();
}
