using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ACS.WebApi.Util
{
    public class MD5Crypto : ICrypto
    {
        private MD5 _md5Hash { get; set; }
        public MD5Crypto()
        {
            _md5Hash = MD5.Create();
        }
        
        public string RetonarHash(string entrada)
        {
            byte[] data = _md5Hash.ComputeHash(Encoding.UTF8.GetBytes(entrada));

            StringBuilder cripto = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                cripto.Append(data[i].ToString("x2"));
            }

            return cripto.ToString();
        }

        public bool VerificarHash(string entrada, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            return 0 == compara.Compare(this.RetonarHash(entrada), hash);
        }
    }
}
