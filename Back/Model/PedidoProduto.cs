using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class PedidoProduto
{
    public int Id { get; set; }

    public int? ProdutoId { get; set; }

    public int? PromocaoId { get; set; }

    public int Quantidade { get; set; }

    public virtual Produto Produto { get; set; }

    public virtual Promocao Promocao { get; set; }
}
