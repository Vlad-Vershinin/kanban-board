using ReactiveUI;
using System;

namespace client_app.Models;

public class Card
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
