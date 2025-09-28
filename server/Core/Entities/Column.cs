using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities;

public class Column
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public Guid BoardId { get; set; }

    public Board? Board { get; set; }
    public List<Card> Cards { get; set; } = [];
}
