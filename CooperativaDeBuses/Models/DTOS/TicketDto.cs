using System;
using System.Collections.Generic;

namespace CooperativaDeBuses.Models;

public partial class TicketDto
{
    public int? Id { get; set; }

    public int? IdViaje { get; set; }

    public int? IdUsuario { get; set; }

    public string? Observacion { get; set; }

    public string? Status { get; set; } = null!;

}
