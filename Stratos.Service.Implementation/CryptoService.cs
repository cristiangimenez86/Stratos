using Stratos.Service.Contract;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Stratos.Service.Implementation
{
    public class CryptoService : ICryptoService
    {
        private static byte[] key = { 235, 243, 24, 165, 133, 159, 119, 128, 228, 91, 156, 72, 173, 105, 19, 61, 5, 78, 249, 106, 249, 13, 155, 104, 85, 85, 108, 47, 18, 16, 97, 103 };
        private static byte[] vector = { 181, 216, 144, 107, 21, 102, 236, 91, 227, 198, 117, 164, 168, 241, 49, 189 };
        private ICryptoTransform encryptor, decryptor;
        private UTF8Encoding encoder;

        public CryptoService()
        {
            RijndaelManaged rm = new RijndaelManaged();
            encryptor = rm.CreateEncryptor(key, vector);
            decryptor = rm.CreateDecryptor(key, vector);
            encoder = new UTF8Encoding();
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, encryptor);
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
