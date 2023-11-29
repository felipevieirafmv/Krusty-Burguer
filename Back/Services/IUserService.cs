using System.Threading.Tasks;

namespace Back.Services;

using Back.Model;
using DTO;

public interface IUserService
{
    Task Create(UserDataCadastro data);
    Task<Usuario> GetByLogin(string login);
}