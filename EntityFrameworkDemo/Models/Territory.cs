﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Models;

public partial class Territory
{
    public string TerritoryId { get; set; }

    public string TerritoryDescription { get; set; }

    public int RegionId { get; set; }

    public virtual Region Region { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
