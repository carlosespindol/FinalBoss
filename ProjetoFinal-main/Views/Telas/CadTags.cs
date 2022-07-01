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
            this.lblDescricao.Text = " Descrição ";
            this.lblDescricao.Location = new Point(120, 40);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(60, 80);
            this.txtDescricao.Size = new Size(180, 20);
            
            this.btnConfirm = new ButtonField("Confirmar", 100, 170, 100, 30);
            btnConfirm.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancel = new ButtonField("Cancelar",100, 200,100, 30);
            btnCancel.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Cadastrar Tag";
        }

        private void btnCancelarClick(object sender, EventArgs e)
           {
                this.Close();
           }

           public void btnConfirmarClick(object sender, EventArgs e)
        {
            string message = "Tag cadastrada com sucesso!";
            string caption = " PARABÉNS ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            TagControl.InserirTags(this.txtDescricao.Text);
            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }

        }
    }
}