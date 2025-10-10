using System.Text.Json.Serialization;

namespace server.Domain.Models;

public class Column
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid BoardId { get; set; }

    [JsonIgnore] public List<Issue> Issues { get; set; } = [];
}
