using System;

namespace ACS.WebApi.Util
{
    public interface ICrypto
    {
        string RetonarHash(string entrada);

        bool VerificarHash(string entrada, string hash);

    }
}
