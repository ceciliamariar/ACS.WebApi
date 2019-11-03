using ACS.WebApi.Util;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ACS.WebApi.Negocio
{
    public class CriptografiaNegocio : ICriptografiaNegocio
    {
        private ICrypto _Criptografia { get; set; }
        public CriptografiaNegocio(ICrypto criptografia)
        {
            _Criptografia = criptografia;
        }

        public string Criptografa(string valor)
        {
            return _Criptografia.RetonarHash(valor);
        }

        public bool ComparaValor(string valorDescriptografado, string valorCriptografado)
        {
            return _Criptografia.VerificarHash(valorDescriptografado, valorCriptografado);
        }

    }
}

