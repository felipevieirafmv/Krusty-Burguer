using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Imagem
{
    public int Id { get; set; }

    public byte[] Foto { get; set; }

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();
}
