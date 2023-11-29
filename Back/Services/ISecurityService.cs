using System.Threading.Tasks;

namespace Back.Services;

public interface ISecurityService
{
    Task<string> GenerateSalt();
    Task<string> HashPassword(string password, string salt);
}