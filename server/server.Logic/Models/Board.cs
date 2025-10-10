using System;
using System.Collections.Generic;

namespace server.Domain.Models;

public class Board
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CreatorId { get; set; }

    public User? Creator { get; set; }
    public List<UserBoardRole> Users { get; set; } = [];
    public List<Column> Columns { get; set; } = [];
}
