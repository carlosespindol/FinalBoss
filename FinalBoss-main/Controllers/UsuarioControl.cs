using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class UsuarioControl
    {
         public static IEnumerable<Usuario> SelectUsuarios()
        {
            return Models.Usuario.GetUsuarios();  
        }

        public static Usuario DeleteUsuarios(int Id)
        {
            Usuario usuarios = Models.Usuario.GetUsuario(Id);
            Usuario.RemoverUsuario(usuarios);
            return usuarios;
        }

        public static Usuario InserirUsuarios(string Nome, string Email, string Senha)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome foi considerado invalido");
            }
            if(!validateEmailRegex.IsMatch(Email))
            {
                throw new Exception("O email foi considerado invalido");
            }
              if (String.IsNullOrEmpty(Senha) || Senha.Length <= 8)
            {
                throw new Exception("A senha foi considerada invalida");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }
            return new Usuario(Nome, Email, Senha);
        }

        public static void UpdateUsuarios(int Id,string Nome,string Email, string Senha)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }
            if (validateEmailRegex.IsMatch(Email))
            {
                usuario.Email = Email;
            }
            else
            {
                throw new Exception("O email foi considerado invalido");
            }
            if (!String.IsNullOrEmpty(Senha))
            {
                if (String.IsNullOrEmpty(Senha) || Senha.Length < 8)
                {
                    throw new Exception("A senha foi considerada invalida");
                }
                else
                {
                    Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                    usuario.Senha = Senha;
                }
            }
            else
            {
                throw new Exception("A senha foi considerada invalida");
            }
            Usuario.AlterarUsuario(Id,Nome,Email,Senha);
        }
    }
}