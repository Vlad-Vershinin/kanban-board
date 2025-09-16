using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities;

public class Board
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required] public Guid CreatorId { get; set; }
}
