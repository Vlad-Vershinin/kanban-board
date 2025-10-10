using System.Text.Json.Serialization;

namespace server.Domain.Models;

public class Issue
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status {  get; set; } = string.Empty;
    public Guid ColumnId { get; set; }

    [JsonIgnore] public List<User> UsersPerform { get; set; } = [];
}
