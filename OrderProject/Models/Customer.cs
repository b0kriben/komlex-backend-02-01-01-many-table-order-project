using System;
using System.Collections.Generic;

namespace OrderProject.Models;

public partial class Customer
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public int? Budget { get; set; }
}
