using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalClinic.MainPanel;

namespace MedicalClinic.Admin
{
    public partial class Admincs : UserControl
    {
        public Admincs()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = SQLAdm.GetStaff("", "", "", "");
            Mainlist.MultiSelect = false;


            //Refresh();
            //na liste 
            var res = SQLAdm.GetStaff("", "", "", "");
            
            foreach (var order in res)
            {
                ListViewItem lvi = new ListViewItem(order.Id_Staff.ToString());
                lvi.SubItems.Add(order.Name);
                lvi.SubItems.Add(order.Surname);
                lvi.SubItems.Add(order.Login);
                lvi.SubItems.Add(SQLAdm.translateRolePL(order.Role));

                Mainlist.Items.Add(lvi);
                
            }
            Mainlist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Mainlist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Mainlist.FullRowSelect = true;
            Mainlist.GridLines = true;
            ;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignOut_Click(object sender, EventArgs e)
        {

            Panel P = new Panel();
            P.Controls.Clear();
            this.Hide();
            this.Parent.Controls.Add(new MainPanel.MainPanel());
                      
        }

        private void Add_Click(object sender, EventArgs e)
        {
           
            WindowPanel.Controls.Add(new AddNew(connector));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            
            if (Selected != 0)
            {
            WindowPanel.Controls.Add(new Edit(connector,Selected));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();
            
            }
            else MessageBox.Show("Wybierz użytkownika", "Błąd");


        }

        private void Show_Click(object sender, EventArgs e)
        {
            if (Mainlist.SelectedItems.Count > 0)
            {
                WindowPanel.Controls.Add(new Show(Selected));
                WindowPanel.Visible = true;
                WindowPanel.Dock = DockStyle.Fill;
                WindowPanel.BringToFront();
                
            }
            else MessageBox.Show("Zaznacz wartość", "Błąd");
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (Role.Text.ToString() == "brak")
            {
                Role.Text = "";
            }
          
            Refresh(SQLAdm.GetStaff(Name.Text.ToString(), Surname.Text.ToString(), Login.Text.ToString(), SQLAdm.translateRoleDB(Role.Text.ToString())));
            
        }


        public void Refresh(IQueryable<Staff> a)
        {
             
            Mainlist.Items.Clear();
            foreach (var order in a)
            {
                ListViewItem lvi = new ListViewItem(order.Id_Staff.ToString());
                lvi.SubItems.Add(order.Name);
                lvi.SubItems.Add(order.Surname);
                lvi.SubItems.Add(order.Login);
                lvi.SubItems.Add(SQLAdm.translateRolePL(order.Role));
                Mainlist.Items.Add(lvi);

            }
            dataGridView1.DataSource = a;
            Selected = 0;
        }
        //sa 2 funkcje bo nie wiem ktora dziala 
        private void connector_TextChanged(object sender, EventArgs e)
        {
            Refresh(SQLAdm.GetStaff(Name.Text.ToString(), Surname.Text.ToString(), Login.Text.ToString(), SQLAdm.translateRoleDB(Role.Text.ToString())));
            connector.Text = "";
            
        }

        private void connector_TextChanged_1(object sender, EventArgs e)
        {
            Refresh(SQLAdm.GetStaff(Name.Text.ToString(), Surname.Text.ToString(), Login.Text.ToString(), SQLAdm.translateRoleDB(Role.Text.ToString())));
            connector.Text = "";
            
        }

        private static int Selected=0;
        private void Mainlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Mainlist.SelectedItems.Count > 0)
            Selected = int.Parse(Mainlist.SelectedItems[0].Text.ToString());
           
        }
    }
}
