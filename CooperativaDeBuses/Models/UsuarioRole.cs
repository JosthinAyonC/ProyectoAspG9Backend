using System;
using System.Collections.Generic;

namespace CooperativaDeBuses.Models;

public partial class UsuarioRole
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
