using Paket.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisadorX
{
    public class Hash
    {
        public byte[] GerarSalt()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] salt = new byte[16];
            rngCsp.GetBytes(salt);

            return salt;
        }

        public string CriarHash(string senha, byte[] salt)
        {
            
            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 100000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashSenha = Convert.ToBase64String(hashBytes);

            return hashSenha;
        }

        public string CompararSenhas(string senhaDigitada, byte[] sal)
        {
            string senhaComparada = CriarHash(senhaDigitada, sal);

            return senhaComparada;
        }
    }
}
