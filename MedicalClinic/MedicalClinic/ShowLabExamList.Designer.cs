﻿namespace MedicalClinic
{
    partial class ShowLabExamList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          //  this.labolatoryExaminantion1 = new MedicalClinic.Controls.Doctor.LabolatoryExaminantion();
            this.SuspendLayout();
            // 
            // labolatoryExaminantion1
            // 

            //this.labolatoryExaminantion1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            //this.labolatoryExaminantion1.Name = "labolatoryExaminantion1";
            //this.labolatoryExaminantion1.Size = new System.Drawing.Size(1280, 650);
            //this.labolatoryExaminantion1.TabIndex = 0;
            // 
            // ShowLabExamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 665);
            this.Controls.Add(this.labolatoryExaminantion1);
            this.Name = "ShowLabExamList";
            this.Text = "ShowLabExamList";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Doctor.LabolatoryExaminantion labolatoryExaminantion1;
    }
}