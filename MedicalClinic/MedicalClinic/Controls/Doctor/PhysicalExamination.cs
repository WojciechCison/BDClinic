﻿using System;
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
    public partial class PhysicalExamination : UserControl
    {
        public PhysicalExamination()
        {
            InitializeComponent();

            //var res = SQLDoc.GetPatient(1);
            //foreach (var order in res)
            //{
            //    textBox1.Text = order.patientTable.Name;
            //    textBox2.Text = order.patientTable.Surname;
            //    textBox3.Text = order.patientTable.PESEL;

            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel P = new Panel();
            P.Controls.Clear();
            this.Hide();
            this.Parent.Controls.Add(new NewPhysicalExaminationcs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show_ExaminationPsyhic f2 = new show_ExaminationPsyhic();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Panel P = new Panel();
            P.Controls.Clear();
            this.Hide();
            this.Parent.Controls.Add(new EditPhysicalExamination());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
