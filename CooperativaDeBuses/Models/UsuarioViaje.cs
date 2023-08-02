using System;
using System.Collections.Generic;

namespace CooperativaDeBuses.Models;

public partial class UsuarioViaje
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdViaje { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Viaje IdViajeNavigation { get; set; } = null!;
}
