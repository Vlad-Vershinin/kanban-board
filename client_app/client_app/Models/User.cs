using client_app.Models;
using System;
using System.Collections.Generic;

namespace server.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string VisibleName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<Board> Boards { get; set; }
}
