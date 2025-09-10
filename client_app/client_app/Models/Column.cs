using System;
using System.Collections.Generic;

namespace client_app.Models;

public class Column
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Card> Cards { get; set; }
}
