using System;
using System.Collections.Generic;

namespace CooperativaDeBuses.Models;

public partial class Bus
{
    public int Id { get; set; }

    public int Capacidad { get; set; }

    public string Model { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public string Status { get; set; } = null!;
}
