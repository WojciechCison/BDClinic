﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalClinic.Doctor;

namespace MedicalClinic.Controls.Doctor
{
    public partial class ShowLabExamination : UserControl
    {
        public ShowLabExamination()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel P = new Panel();
            P.Controls.Clear();
            this.Hide();
            this.Parent.Controls.Add(new Show());
        }

        private void ShowLabExamination_Load(object sender, EventArgs e)
        {

        }
    }
}
