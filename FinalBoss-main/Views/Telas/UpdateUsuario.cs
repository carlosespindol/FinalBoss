using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Telas
{
    public class UpdateUsuario : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblNome;
        Label lblEmail;
        Label lblSenha;

        int Id;
        
        TextBox txtNome;
        TextBox txtEmail;
        TextBox txtSenha;
        
        Button btnConfirmar;
        Button btnCancelar;

        public UpdateUsuario(int Id)
        {

            this.Id = Id;
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            this.lblNome = new Label();
            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new Point(110, 40);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(60, 60);
            this.txtNome.Size = new Size(180, 30);
            this.txtNome.Text = usuario.Nome;
            
            this.lblEmail = new Label();
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(110, 90);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(60, 115);
            this.txtEmail.Size = new Size(180, 20);
            this.txtEmail.Text = usuario.Email;

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha:";
            this.lblSenha.Location = new Point(110, 140);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(60, 170);
            this.txtSenha.Size = new Size(180, 20);
            this.txtSenha.PasswordChar = '***';

            this.btnConfirmar = new ButtonField("Confirma", 100, 200, 100, 40);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancelar = new ButtonField("Cancela",100, 230,100, 40);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);


            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Update Usuario";
        }

        private void btnCancelarClick(object sender, EventArgs e)
           {
                this.Close();
           }

           public void btnConfirmarClick(object sender, EventArgs e)
        {
            try{
            string message = "Usuário alterado";
            string caption = "Enjoy!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            UsuarioControl.UpdateUsuarios(Id, this.txtNome.Text, this.txtEmail.Text, this.txtSenha.Text);
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }
            }catch(Exception){
            string message = "Dados sem validez, repita o processo";
            string caption = "Falha";
            MessageBox.Show(message, caption);
            }

        }
    }
}