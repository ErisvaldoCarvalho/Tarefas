using System.Security.Cryptography;
using System.Text;

namespace Infra
{
    public static class Criptografia
    {
        public static string GetHash(string _texto)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] data = sHA256.ComputeHash(Encoding.UTF8.GetBytes(_texto));
                var retorno = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                    retorno.Append(data[i].ToString("x2"));

                return retorno.ToString();
            }
        }
        public static bool VerificaHash(string _texto, string _hash)
        {
            var hash = GetHash(_texto);
            return hash == _hash;
        }
    }
}
