
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace back.Services;

public class SecurityService : ISecuritySercive
{
    public async Task<string> GenerateSalt()
    {
        var saltBytes = getRandomArray();
        var base64salt = Convert.ToBase64String(saltBytes);
        return base64salt;
    }

    public Task<string> HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashBytes = getHash(saltBytes, passwordBytes);

    }
    
    public Task<string> GenerateJwt<T>(T obj)
    {
        throw new System.NotImplementedException();
    }

    public Task<string> ValidateJwt<T>(string jwt)
    {
        throw new System.NotImplementedException();
    }

    private byte[] getRandomArray()
    {
        byte[] randomBytes = new byte[24];
        Random.Shared.NextBytes(randomBytes);
        return randomBytes;
    }

    private byte[] getHash(byte[] saltBytes, byte[] passwordBytes)
    {
        const int iterationsCount = 1000;
        using var hashAlgorithm = new Rfc2898DeriveBytes(
            passwordBytes, saltBytes, iterationsCount
        );
        var hashBytes = hashAlgorithm.GetBytes(32);
        return hashBytes;
    }
}
