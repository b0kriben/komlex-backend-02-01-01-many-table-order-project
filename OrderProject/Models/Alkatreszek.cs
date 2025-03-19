using System;
using System.Collections.Generic;

namespace OrderProject.Models;

public partial class Alkatreszek
{
    public string? Id { get; set; }

    public string? Nev { get; set; }

    public string? Ar { get; set; }

    public string? Raktaron { get; set; }

    public string? LaptopAlkatresz { get; set; }

    public string? BeszallitoId { get; set; }

    public string? KategoriaId { get; set; }
}
