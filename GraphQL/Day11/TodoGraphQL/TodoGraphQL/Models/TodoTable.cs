using System;
using System.Collections.Generic;

namespace TodoGraphQL.Models;

public partial class TodoTable
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool Completed { get; set; }
}
