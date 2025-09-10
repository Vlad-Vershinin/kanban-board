using System;
using System.Collections.Generic;

namespace client_app.Models;

public class Board
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Board> Boards { get; set; }
}
