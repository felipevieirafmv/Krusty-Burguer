using System.Threading.Tasks;

namespace back.Services;

public interface ISecuritySercive
{
    Task<string> GenerateSalt();
    Task<string> HashPassword(string password, string salt);
    Task<string> GenerateJwt<T>(T obj);
    Task<string> ValidateJwt<T>(string jwt);
}