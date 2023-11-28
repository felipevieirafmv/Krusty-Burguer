using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Promocao
{
    public int Id { get; set; }

    public int? ProdutoId { get; set; }

    public double Preco { get; set; }

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; } = new List<PedidoProduto>();

    public virtual Produto Produto { get; set; }
}
