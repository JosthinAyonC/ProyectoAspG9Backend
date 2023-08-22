using System;
using System.Collections.Generic;

namespace CooperativaDeBuses.Models;

public partial class UsuarioDto
{
    public int? Id { get; set; }

    public string? Username { get; set; } = null!;

    public string? Firstname { get; set; } = null!;

    public string? Lastname { get; set; } = null!;

    public string? Ci { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public string? Status { get; set; } = null!;

    public virtual ICollection<UsuarioRole>? UsuarioRoles { get; set; } = new List<UsuarioRole>();
}
