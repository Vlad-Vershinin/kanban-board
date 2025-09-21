using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities;

public class Card
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public Guid ColumnId { get; set; }
    public string Description { get; set; } = string.Empty;
}
