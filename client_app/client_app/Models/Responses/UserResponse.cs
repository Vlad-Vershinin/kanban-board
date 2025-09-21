using System;
using System.Collections.Generic;

namespace client_app.Models.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string VisibleName { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Board> Boards { get; set; }
}
