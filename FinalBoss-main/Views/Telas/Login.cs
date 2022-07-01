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

namespace Telas
{
    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblUser;
        Label lblPassword;
        TextBox txtUser;
        TextBox txtPass;

        Button btnConfirm;
        Button btnCancel;

        public Login()
        {
            this.lblUser = new Label();
            this.lblUser.Text = "Usuario";
            this.lblUser.Location = new Point(125, 40);

            this.txtUser = new TextBox();
            this.txtUser.Location = new Point(60, 60);
            this.txtUser.Size = new Size(180, 30);
            this.lblPassword = new Label();
            this.lblPassword.Text = "Senha";
            this.lblPassword.Location = new Point(125, 100);
            

            this.txtPass = new TextBox();
            this.txtPass.Location = new Point(60, 130);
            this.txtPass.Size = new Size(180, 30);
            this.txtPass.PasswordChar = '***';

            //============== BOTÕES ==================

            this.btnConfirm = new ButtonField("Confirma", 100, 170, 100, 30);
            btnConfirm.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancel = new ButtonField("Cancela",100, 200,100, 30);
            btnCancel.Click += new EventHandler(this.btnCancelarClick);

            //==================================  

            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Login:";
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {   
            try
            {
                Usuario.Auth(this.txtUser.Text, this.txtPass.Text);
                if(Usuario.UsuarioAuth != null)
                {
                    Menu Menus = new Menu();
                    Menus.ShowDialog(); 
                }
            }
            catch(Exception)
            {
                string message = "Email ou senha incorretos, por favor tente novamente";
                string caption = "Falha!";
                MessageBox.Show(message, caption);
            }
                
        }  

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }  

    }

    public class LabelField : Label 
    {
            public LabelField(string Text, int x, int y)
            {
                this.Text = Text;
                this.Location = new Point(x ,y);
            }
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
