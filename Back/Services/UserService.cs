using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace back.Services;

using Back.Model;
using DTO;

public class UserService : IUserService
{
    KrustyBurgerDbContext ctx;
    
    public Task Create(UserData data)
    {
        throw new System.NotImplementedException();
    }

    public Task<Usuario> GetByLogin(string login)
    {
        throw new System.NotImplementedException();
    }
}

