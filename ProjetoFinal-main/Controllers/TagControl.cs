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
    public class TagControl
    {
        public static IEnumerable<Tag> SelectTag()
        {
            return Models.Tag.GetTags();  
        }

        public static Tag DeleteTags(int Id)
        {
            Tag tags = Models.Tag.GetTag(Id);
            Tag.RemoverTag(tags);
            return tags;
        }
    
        public static Tag InserirTags(string Descricao)
        {

            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }
            return new Tag(Descricao);
        }

        public static void UpdateTag(int Id,string Descricao)
        {
            Tag tag = Models.Tag.GetTag(Id);
           if (!String.IsNullOrEmpty(Descricao))
            {
                tag.Descricao = Descricao;
            }
            Tag.AlterarTag(Id,Descricao);
        }
    }
}