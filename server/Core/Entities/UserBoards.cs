namespace server.Core.Entities;

public class UserBoards
{
    public Guid UserId { get; set; }
    public Guid BoardId { get; set; }

    public User User { get; set; }
    public Board Board { get; set; }
}
