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
using Controllers;

namespace Telas
{
    public class Usuarios : Form
    {
		private System.ComponentModel.IContainer components = null;
        ListView lstUsuario;
		Button btnInserir;
		Button btnUpdate;
		Button btnDelete;
		Button btnVoltar;

        public Usuarios()
        {
            lstUsuario = new ListView();
			lstUsuario.Location = new Point(50,50 );
			lstUsuario.Size = new Size(400,320);
			lstUsuario.View = View.Details;
			foreach (Usuario i in UsuarioControl.SelectUsuarios())
			{
				ListViewItem list = new ListViewItem(i.Id + "");
				list.SubItems.Add(i.Nome);
				list.SubItems.Add(i.Email);
				lstUsuario.Items.AddRange(new ListViewItem[] {list});
			}
			lstUsuario.Columns.Add("ID", -2, HorizontalAlignment.Left);
    		lstUsuario.Columns.Add("Nome", -2, HorizontalAlignment.Left);
			lstUsuario.Columns.Add("Email", -2, HorizontalAlignment.Left);
			lstUsuario.FullRowSelect = true;
			lstUsuario.GridLines = true;
			lstUsuario.AllowColumnReorder = true;
			lstUsuario.Sorting = SortOrder.Ascending;

			//============= Inserir ===============

			this.btnInserir = new ButtonField("Inserir", 50, 380,100, 30);
			btnInserir.Click += new EventHandler(this.btnInserirClick);

			//================ Update ==================

			this.btnUpdate = new ButtonField("Update", 150, 380, 100, 30);
			btnUpdate.Click += new EventHandler(this.btnUpdateClick);

			//================= Delete =====================

			this.btnDelete = new ButtonField("Delete", 250, 380, 100, 30);
			btnDelete.Click += new EventHandler(this.btnDeleteClick);

			//================= Voltar =================

			this.btnVoltar = new ButtonField("Voltar", 350, 380, 100, 30);
			btnVoltar.Click += new EventHandler(this.btnVoltarClick);

			this.Controls.Add(this.btnInserir);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lstUsuario);

			this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Usuarios";

			
        }

			private void btnVoltarClick(object sender, EventArgs e)
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

		public void btnDeleteClick(object sender, EventArgs e)
        {
            string message = "Você realmente deseja excluir o item?";
            string caption = " EXCLUIR ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (lstUsuario.SelectedItems.Count > 0)
                    {
                        ListViewItem li = lstUsuario.SelectedItems[0];
                        MessageBox.Show("O item de id " + li.Text + " foi deletado com sucesso!", "Deletado");
                        UsuarioControl.DeleteUsuarios(Convert.ToInt32(li.Text));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao deletar", "Erro");
                }
            }
        }

		private void btnInserirClick(object sender, EventArgs e)
            {
            
				CadUsuario CadUsuario = new CadUsuario();
				CadUsuario.ShowDialog();
            }

			private void btnUpdateClick(object sender, EventArgs e)
           {
            if (lstUsuario.SelectedItems.Count > 0)
             {
                ListViewItem li = lstUsuario.SelectedItems[0];
                    
                UpdateUsuario UpdateUsuario = new UpdateUsuario(Convert.ToInt32(li.Text));
                UpdateUsuario.ShowDialog();
             }
           }		
    }
}