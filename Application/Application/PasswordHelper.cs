using System.Security.Cryptography;
using System.Text;

namespace Application;

public class PasswordHelper
{
    public static string ComputeSha256Hash(string rawData)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawData));
        return Convert.ToBase64String(bytes);
    }
}
