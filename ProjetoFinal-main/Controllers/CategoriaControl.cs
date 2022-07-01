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

namespace Controllers
{
    public class CategoriaControl
    {
        public static IEnumerable<Categoria> SelectCategorias()
        {
            return Models.Categoria.GetCategorias();  
        }

        public static Categoria DeleteCategorias(int Id)
        {
            Categoria categorias = Models.Categoria.GetCategoria(Id);
            Categoria.RemoverCategoria(categorias);
            return categorias;
        }

        public static Categoria InserirCategorias(string Nome, string Descricao)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }
            return new Categoria(Nome, Descricao);
        }

        public static void UpdateCategorias(int Id,string Nome,string Descricao)
        {
            Categoria categoria = Models.Categoria.GetCategoria(Id);
            if (!String.IsNullOrEmpty(Nome))
            {
                categoria.Nome = Nome;
            }
            if (!String.IsNullOrEmpty(Descricao))
            {
                categoria.Descricao = Descricao;
            }
            Categoria.AlterarCategoria(Id,Nome,Descricao);
        }
    }
}