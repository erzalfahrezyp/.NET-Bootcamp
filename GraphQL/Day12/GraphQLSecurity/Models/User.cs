﻿using System;
using System.Collections.Generic;

namespace GraphQLSecurity.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
