using System;
using System.Collections.Generic;

namespace WebDbAppCrudMVC.Models;

public partial class Barang
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Stock { get; set; }

    public double Price { get; set; }

    public string FileProduct { get; set; } = null!;
}
