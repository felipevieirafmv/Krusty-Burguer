using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

using Back.Model;
using DTO;

public class ProductService : IProductService
{
    KrustyBurgerDbContext ctx;
    ISecurityService security;
    public ProductService(KrustyBurgerDbContext ctx, ISecurityService security) {
        this.ctx = ctx;
        this.security = security;
    }
    public async Task Create(ProductData data)
    {
        Produto produto = new Produto();

        produto.Nome = data.Nome;
        produto.Descricao = data.Descricao;
        produto.Tipo = data.Tipo;
        produto.Preco = data.Preco;

        
        this.ctx.Add(produto);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Produto> GetByName(string name)
    {
        var query = 
            from u in this.ctx.Produtos
            where u.Nome == name
            select u;
        
        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<Produto>> GetProdutos()
        => await this.ctx.Produtos.ToListAsync();
}
