using System;
using System.Collections.Generic;

namespace WebDBApp.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Created { get; set; }
}
