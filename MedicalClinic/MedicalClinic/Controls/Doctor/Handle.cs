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

namespace MedicalClinic.Doctor
{
    public partial class Handle : UserControl
    { private string IDVis;
      private int idpat;

        public Handle (int IDP, string IDV)
        {
            InitializeComponent();

            IDVis = IDV;
            //textb = text;
            idpat = IDP;
            PatientsSearchCriteria searchCriteria = new PatientsSearchCriteria();
            searchCriteria.setPatientId(IDP);

            var res = SQLDoc.GetPatient(searchCriteria);
            foreach (var order in res)
            {
                textBox1.Text = order.patientTable.Name;
                textBox2.Text = order.patientTable.Surname;
                textBox3.Text = order.patientTable.PESEL;


            }


            int x = Int32.Parse(IDV);
            var res1 = SQLDoc.GetAppointment(x);
            foreach (var order in res1)
            {
                textBox4.Text = order.Descirption;
                textBox5.Text = order.Diagnosis;


            }

        }






        private void button4_Click(object sender, EventArgs e) //show phisical
        {

            WindowPanel.Controls.Add(new PhysicalExamination(idpat, IDVis, 2));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();
            
        }

        private void button3_Click(object sender, EventArgs e) //show labo
        {

            WindowPanel.Controls.Add(new LabolatoryExaminantion(idpat, IDVis, 2));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e) //back
        {
            
            int idDoctor = -1;
            int x = Int32.Parse(IDVis);
            var res1 = SQLDoc.GetAppointment(x);
            foreach (var order in res1)
            {
                idDoctor = order.Id_Doctor;

            }

            this.Controls.Clear();
            this.Hide();
            this.Controls.Add(new MedicalClinic.Doctor.Doctor(idDoctor));
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WindowPanel.Controls.Add(new HistoryVisits(idpat));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();
           

        }

        private void Handle_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            WindowPanel.Controls.Add(new HistoryLaboratoryExamination(idpat));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {


            WindowPanel.Controls.Add(new HistoryPhysicalExamination(idpat));
            WindowPanel.Visible = true;
            WindowPanel.Dock = DockStyle.Fill;
            WindowPanel.BringToFront();

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)//zapisz
        {
            SQLDoc.updateDescDia(Int32.Parse(IDVis), textBox5.Text.ToString(), textBox4.Text.ToString(), "R");
            MessageBox.Show("Zapisano");

        }

        private void button5_Click(object sender, EventArgs e)//zakończ
        {
            SQLDoc.updateDescDia(Int32.Parse(IDVis), textBox5.Text.ToString(), textBox4.Text.ToString(), "E");
            MessageBox.Show("Zapisano i zakończono wizytę");
            //this.Controls.Clear();
            //this.Visible = false;
            //this.Parent.Hide();
            int idDoctor = -1;
            int x = Int32.Parse(IDVis);
            var res1 = SQLDoc.GetAppointment(x);
            foreach (var order in res1)
            {
                idDoctor = order.Id_Doctor;

            }
            if (idDoctor != -1)
            {
                Panel P = new Panel();
                P.Controls.Clear();
                this.Hide();
                this.Parent.Controls.Add(new Doctor(idDoctor));
            }

        }

        private void button6_Click(object sender, EventArgs e)//anulowanie
        {
            SQLDoc.updateDescDia(Int32.Parse(IDVis), textBox5.Text.ToString(), textBox4.Text.ToString(), "C");
            MessageBox.Show("Zapisano i anulowano wizytę");
            //this.Controls.Clear();
            //this.Visible = false;
            //this.Parent.Hide();
            int idDoctor = -1;
            int x = Int32.Parse(IDVis);
            var res1 = SQLDoc.GetAppointment(x);
            foreach (var order in res1)
            {
                idDoctor = order.Id_Doctor;

            }
            if (idDoctor != -1)
            {
                Panel P = new Panel();
                P.Controls.Clear();
                this.Hide();
                this.Parent.Controls.Add(new Doctor(idDoctor));
            }

        }
    }
}
