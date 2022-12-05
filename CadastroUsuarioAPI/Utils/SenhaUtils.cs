using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CadastroUsuarioAPI.Utils
{
    public static class SenhaUtils
    {
        public static (string senha, string salt) GerarHash(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return (hashed, SenhaUtils.ToString(salt));
        }

        public static string PegarHash(string senha, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha!,
                salt: ToByte(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static string ToString(byte[] salt)
        {
            var str = "";

            foreach(var b in salt)
            {
                str += b.ToString() + ",";
            }

            str = str.Substring(0, str.Length-1);

            return str;
        }

        public static byte[] ToByte(string salt)
        {
            var strs = salt.Split(',');
            var bytes = new byte[strs.Length];
            for(int i=0; i<strs.Length; i++)
            {
                bytes[i] = Convert.ToByte(strs[i]);
            }
            return bytes;
        }
    }
}
