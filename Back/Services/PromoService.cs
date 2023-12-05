using System.Collections.Generic;
using System.Threading.Tasks;
using Back.Services;
using System.Linq;

using DTO;
using Microsoft.EntityFrameworkCore;

namespace Back.Model;

public class PromoService : IPromoService
{
    KrustyBurgerDbContext ctx;
    ISecurityService security;
    public PromoService(KrustyBurgerDbContext ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }

    public async Task Create(PromoData data)
    {
        Promocao promo = new Promocao();

        promo.Preco = data.Preco;
        promo.ProdutoId = data.ProdutoId;

        this.ctx.Add(promo);
        await this.ctx.SaveChangesAsync();
    }

    public Task<Promocao> GetByName(string name)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<PromoData>> GetPromocoes()
    {
        var query =
            from prod in this.ctx.Produtos
            join promo in this.ctx.Promocaos
            on prod.Id equals promo.ProdutoId
            select new PromoData
            {
                ProdutoId = prod.Id,
                Preco = (float)promo.Preco
            };
        
        return await query.ToListAsync();
    }
}
