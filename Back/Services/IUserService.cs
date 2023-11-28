using System.Threading.Tasks;

namespace back.Services;

using Back.Model;
using DTO;

public interface IUserService
{
    Task Create(UserData data);
    Task<Usuario> GetByLogin(string login);
}