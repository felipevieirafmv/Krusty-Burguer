using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Pedido
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime HoraPedido { get; set; }

    public DateTime? HoraEntregue { get; set; }

    public bool? PedidoPronto { get; set; }

    public virtual Usuario Usuario { get; set; }
}
