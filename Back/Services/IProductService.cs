using System.Threading.Tasks;

namespace Back.Services;

using System.Collections.Generic;
using Back.Model;
using DTO;

public interface IProductService
{
    Task Create(ProductData data);
    Task<Produto> GetByName(string name);
    Task<List<Produto>> GetProdutos();
}