using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public double Preco { get; set; }

    public string Tipo { get; set; }

    public int? ImagemId { get; set; }

    public virtual Imagem Imagem { get; set; }

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; } = new List<PedidoProduto>();

    public virtual ICollection<Promocao> Promocaos { get; } = new List<Promocao>();
}
