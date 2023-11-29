using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

using Back.Model;
using DTO;

public class UserService : IUserService
{
    KrustyBurgerDbContext ctx;
    ISecurityService security;
    
    public UserService(KrustyBurgerDbContext ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }

    public async Task Create(UserDataCadastro data)
    {
        Usuario usuario = new Usuario();
        var salt = await security.GenerateSalt();

        usuario.Nome = data.Login;
        usuario.Cpf = data.Cpf;
        usuario.Senha = await security.HashPassword(
            data.Password, salt
        );
        usuario.Adm = data.Adm;
        usuario.Salt = salt;

        this.ctx.Add(usuario);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Usuario> GetByLogin(string login)
    {
        var query = 
            from u in this.ctx.Usuarios
            where u.Nome == login
            select u;
        
        return await query.FirstOrDefaultAsync();
    }
}

