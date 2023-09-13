using System.Security.Cryptography;
using System.Text;

namespace IntegradorSofttekImanol.Helpers
{
    public static class EncrypterHelper
    {
        /// <summary>
        /// Crea un string encriptado en base al algoritmo SHA256
        /// </summary>
        /// <param name="password">string</param>
        /// <returns>Un string encriptado con una cantidad especifica de caracteres</returns>
        public static string Encrypter(string password)
        {
            //Algoritmo de encriptacion
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = Array.Empty<byte>();
            StringBuilder sb = new StringBuilder();

            //Formatea el arreglo de bytes
            stream = sha256.ComputeHash(encoding.GetBytes(password));

            for(int i = 0; i < stream.Length; i++)
            {
                //Se toma cada byte de dos en dos
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();

        }

    }
}
