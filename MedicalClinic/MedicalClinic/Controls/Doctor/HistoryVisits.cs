using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalClinic.Controls.Doctor;
using MedicalClinic.Doctor;
using static MedicalClinic.SQLDoc;


namespace MedicalClinic.Controls.Doctor
{
    public partial class HistoryVisits : UserControl
    {
        public HistoryVisits(int id)
        {
            InitializeComponent();

            Refresh(SQLDoc.GetAppointmentP(id));
        }
        private void Refresh(IQueryable<TableJoinResult> a)
        {
            Mainlist.Items.Clear();
            foreach (var order in a)
            {
                ListViewItem lvi = new ListViewItem(order.appointmentTable.Id_Appointment.ToString());
                lvi.SubItems.Add(order.appointmentTable.Date_Appointment.ToString()); //data
                string stateString = order.appointmentTable.State.ToString();
                char stringChar = char.Parse(stateString);
                var stateTemp = (State)(stringChar);
                lvi.SubItems.Add(stateTemp.ToString());
                lvi.SubItems.Add(order.staffTable.Surname); //nazwisko lekarza
              
                Mainlist.Items.Add(lvi);

            }
            Mainlist.FullRowSelect = true;
            Mainlist.GridLines = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Mainlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//powrot
            this.Controls.Clear();
            this.Visible = false;
            this.Parent.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {//pokaz opis i diagnoze

            if (Mainlist.SelectedItems.Count > 0)
            {
                ListViewItem item = Mainlist.SelectedItems[0];


                var vis = SQLDoc.GetAppointment(Int32.Parse(item.SubItems[0].Text));

                {

                    textBox1.Text = vis.First().Descirption;//opis
                    textBox2.Text = vis.First().Diagnosis;//diag



                }

            }
        }
    }
}
