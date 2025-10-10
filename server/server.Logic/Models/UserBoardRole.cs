using System;
using System.Text.Json.Serialization;

namespace server.Domain.Models;

public class UserBoardRole
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BoardId { get; set; }
    public string Role { get; set; } = string.Empty;

    [JsonIgnore] public User? User { get; set; }
    [JsonIgnore] public Board? Board { get; set; }
}
