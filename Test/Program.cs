using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using EL;
using Utilidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] Key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");//24 Caracteres
            byte[] IV = Encoding.UTF8.GetBytes("Pr0y3ct03J3mpl00");//16 Caracteres

            Usuarios user = new Usuarios();
            user.IdUsuario = 1;
            user.IdUsuarioActualiza = 1;
            user.Password = Encripty.Encrypt("123", Key, IV);
            BL_Usuarios.PasswordUpdate(user);
        }

    }
}
