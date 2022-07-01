using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telas;

namespace Telas
{
    public class Menu : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblMenu;
        Button btnSair;
        Button btnCategoria;
        Button btnTags;
        Button btnSenhas;
        Button btnUsuario;

        public Menu()
        {

            this.lblMenu = new Label();
            this.lblMenu.Text = " Menu ";
            this.lblMenu.Location = new Point(135, 20);

            this.btnCategoria = new ButtonField("Categoria", 25, 50, 100, 25);
            btnCategoria.Click += new EventHandler(this.btnCategoriasClick);

            this.btnTags = new ButtonField("Tag", 25, 90, 100, 30);
            btnTags.Click += new EventHandler(this.btnTagsClick);

            this.btnSenhas = new ButtonField("Senha", 170, 90, 100, 30);
            btnSenhas.Click += new EventHandler(this.btnSenhaClick);

            this.btnUsuario = new ButtonField("Usuario", 170, 50, 100, 25);
            btnUsuario.Click += new EventHandler(this.btnUsuarioClick);

            this.btnSair = new ButtonField("Sair", 105, 170, 100, 25);
            btnSair.Click += new EventHandler(this.btnSairClick);


            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnSenhas);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblMenu);
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Text = "Revisar";

        }

            private void btnTagsClick(object sender, EventArgs e)
            {
                Tags Tags = new Tags();
                Tags.ShowDialog();
            }

            private void btnCategoriasClick(object sender, EventArgs e)
            {
                Categorias Categorias = new Categorias();
                Categorias.ShowDialog();
            }
       
            private void btnSenhaClick(object sender, EventArgs e)
            {
                Senhas Senha = new Senhas();
                Senha.ShowDialog();
            }

            private void btnUsuarioClick(object sender, EventArgs e)
            {
                Usuarios Usuarios = new Usuarios();
                Usuarios.ShowDialog();
            }

            private void btnSairClick(object sender, EventArgs e)
            {
                this.Close();
            }

        public class ButtonField : Button 
        {
            public ButtonField(string Text, int x, int y, int Z, int P)
            {
                this.Text = Text;
                this.Location = new Point(x ,y);
                this.Size = new Size(Z, P);
            }
        }

    }
}