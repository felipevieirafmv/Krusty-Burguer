using System.Collections.Generic;
using System.Threading.Tasks;
using Back.Model;
using DTO;

namespace Back.Services;

public interface IPromoService
{
    Task Create(PromoData data);
    Task<Promocao> GetByName(string name);
    Task<List<PromoData>> GetPromocoes();
}