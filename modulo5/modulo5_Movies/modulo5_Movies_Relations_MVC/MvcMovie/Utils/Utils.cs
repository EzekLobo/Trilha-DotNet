using System.Security.Cryptography;
using System.Text;

namespace Mvc.AppUtils;
public static class Utils
{
    public static string ComputeSha256Hash(string pass)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}