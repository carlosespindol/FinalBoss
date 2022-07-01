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
    public class Tags : Form
    {
        private System.ComponentModel.IContainer components = null;
        ListView lstTags;
        Button btnInserir;
        Button btnUpdate;
        Button btnDelete;
        Button btnVoltar;

        public Tags()
        {
            lstTags = new ListView();
            lstTags.Location = new Point(50, 50);
            lstTags.Size = new Size(400, 320);
            lstTags.View = View.Details;
            foreach (Tag i in TagControl.SelectTag())
            {
                ListViewItem list = new ListViewItem(i.Id + "");
                list.SubItems.Add(i.Descricao);
                lstTags.Items.AddRange(new ListViewItem[] { list });
            }

            lstTags.Columns.Add("Id", -2, HorizontalAlignment.Left);
            lstTags.Columns.Add("Descriçao", -2, HorizontalAlignment.Left);
            lstTags.FullRowSelect = true;
            lstTags.GridLines = true;
            lstTags.AllowColumnReorder = true;
            lstTags.Sorting = SortOrder.Ascending;

            this.btnInserir = new ButtonField("Insert", 50, 380, 100, 40);
            btnInserir.Click += new EventHandler(this.btnInserirClick);

            this.btnUpdate = new ButtonField("Update", 150, 380, 100, 40);
            btnUpdate.Click += new EventHandler(this.btnUpdateClick);

            this.btnDelete = new ButtonField("Delete", 250, 380, 100, 40);
            btnDelete.Click += new EventHandler(this.btnDeleteClick);

            this.btnVoltar = new ButtonField("Back", 350, 380, 100, 40);
            btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lstTags);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Text = "Tag";


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
                this.Location = new Point(x, y);
                this.Size = new Size(Z, P);
            }
        }

        public void btnDeleteClick(object sender, EventArgs e)

        {
			string message = "Você deseja excluir o item?";
            string caption = "Excluir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);;

			 if (result == DialogResult.Yes)
            {
                try
                {
                    if (lstTags.SelectedItems.Count > 0)
                    {
                        ListViewItem li = lstTags.SelectedItems[0];
                        MessageBox.Show("O item: " + li.Text + " foi deletado!", "Excluido");
                        TagControl.DeleteTags(Convert.ToInt32(li.Text));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Falha ao deletar", "Falha");
                }
            }
        }

        private void btnInserirClick(object sender, EventArgs e)
        {
            CadTags CadTags = new CadTags();
            CadTags.ShowDialog();
        }

        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (lstTags.SelectedItems.Count > 0)
            {
                ListViewItem li = lstTags.SelectedItems[0];
                    
                UpdateTags updateTags = new UpdateTags(Convert.ToInt32(li.Text));
                updateTags.ShowDialog();
            }
        }
    }
}