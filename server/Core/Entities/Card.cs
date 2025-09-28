using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace server.Core.Entities;

public class Card
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public Guid ColumnId { get; set; }
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public Column? Column { get; set; }
}
