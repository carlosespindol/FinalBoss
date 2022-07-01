using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Telas
{
    public class CadTags : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblDescricao;
        TextBox txtDescricao;
        Button btnConfirm;
        Button btnCancel;

        public CadTags()
        {
            
            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descriçao ";
            this.lblDescricao.Location = new Point(120, 50);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(60, 80);
            this.txtDescricao.Size = new Size(180, 30);
            
            this.btnConfirm = new ButtonField("Confirme", 100, 170, 100, 40);
            btnConfirm.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancel = new ButtonField("Cancela",100, 200,100, 40);
            btnCancel.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Cadastrar uma tag";
        }

        private void btnCancelarClick(object sender, EventArgs e)
           {
                this.Close();
           }

           public void btnConfirmarClick(object sender, EventArgs e)
        {
            string message = "Sua tag foi cadastrada com sucesso!";
            string caption = " Enjoy! ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            TagControl.InserirTags(this.txtDescricao.Text);
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }

        }
    }
}