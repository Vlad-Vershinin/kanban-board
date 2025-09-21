using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities;

public class Column
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public Guid BoardId { get; set; }

    public List<Card> Cards { get; set; }
}
