using System;
using System.Collections.Generic;

namespace NWBC_Assignment02.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Major { get; set; } = null!;
}
