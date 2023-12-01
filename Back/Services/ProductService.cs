using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Back.Services;

using Back.Model;
using DTO;

public class ProductService : IProductService
{
    public Task Create(ProductData data)
    {
        throw new System.NotImplementedException();
    }

    public Task<Produto> GetByName(string name)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Produto>> GetProdutos()
    {
        throw new System.NotImplementedException();
    }
}
