using System;
using System.Collections.Generic;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Telas
{
    public class UpdateSenhas : Form
    {
        private System.ComponentModel.IContainer components = null;

        int Id;
        Form parent;
        Button btnVoltar;
        Button btnInsert;
        Label lblNome;
        Label lblCategoria;
        Label lblUrl;
        Label lblUser;
        Label lblSenha;
        Label lblProcedimento;
        Label lblTags;
        TextBox txtNome;
        CheckedListBox checkedTags;
        TextBox txtUrl;
        TextBox txtUser;
        TextBox txtSenha;
        TextBox txtProcedimento;
        ComboBox cbCategoria;

        public UpdateSenhas(int Id,Form parent)
        {
            this.parent = parent;

            this.Id = Id;
            Senha senhas = Models.Senha.GetSenha(Id);
            this.lblNome = new Label();
            this.lblNome = new Campos.LabelField("Nome:", 30, 50);
            this.txtNome = new Campos.TextBoxField(30, 80, 250, 200);

            this.lblCategoria = new Label();
            this.lblCategoria = new Campos.LabelField("Categoria:", 25, 130);
            
            IEnumerable<Categoria> categoria = CategoriaControl.SelectCategorias();
            this.cbCategoria = new Campos.ComboBoxField(30, 160, 250, 200);
			foreach (Categoria item in categoria)
			{
				cbCategoria.Items.Add(item);
			}
			cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            

            this.lblUrl = new Label();
            this.lblUrl = new Campos.LabelField("URL:", 30, 210);
            this.txtUrl = new Campos.TextBoxField(30, 240, 250, 200);

            this.lblUser = new Label();
            this.lblUser = new Campos.LabelField("Usuario:", 30, 290);
            this.txtUser = new Campos.TextBoxField(30, 320, 250, 200);
            
            this.lblSenha = new Label();
            this.lblSenha = new Campos.LabelField("Senha:", 30, 370);
            this.txtSenha = new Campos.TextBoxField(30, 400, 250, 200);
       
            this.lblProcedimento = new Label();
            this.lblProcedimento = new Campos.LabelField("Procedimento:", 30, 440);
            this.txtProcedimento = new Campos.TextBoxField(30, 470, 250, 200);

            this.lblTags = new Label();
            this.lblTags = new Campos.LabelField("Tag:", 30, 520);
            checkedTags = new Campos.CheckedListBoxField(30, 550, 250, 200);
			foreach(Tag item in TagControl.SelectTag())
            {
                CheckedListBox checkedListBox = new CheckedListBox();
                checkedListBox.Items.Add(item.Descricao + " ");
                checkedTags.Items.AddRange(checkedListBox.Items);
            }	
			
			checkedTags.CheckOnClick = true;


            btnVoltar = new Campos.ButtonField("Volta", 50, 750, 100, 40);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            btnInsert = new Campos.ButtonField("Confirma", 150, 750, 100, 40);
			btnInsert.Click += new EventHandler(this.btnConfirmarClick);

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.checkedTags);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtProcedimento);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 800);
            this.Text = "Update Senha";
        }

        public void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        public void btnConfirmarClick(object sender, EventArgs e)
        {
            string message = "Sua senha foi alterada";
            string caption = "Enjoy!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string[] categoria = this.cbCategoria.Text.Split('-');
            SenhaControl.UpdateSenha(Id, this.txtNome.Text, Convert.ToInt32(categoria[0].Trim()), this.txtUrl.Text,this.txtUser.Text,this.txtSenha.Text, this.txtProcedimento.Text);
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }
        }
    }
}