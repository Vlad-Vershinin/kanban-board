namespace server.Core.DTOs.Board;

public class CreateBoardDto
{
    public Guid CreatorId { get; set; }
    public string Name { get; set; }
}
