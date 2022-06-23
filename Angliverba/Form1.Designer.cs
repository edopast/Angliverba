namespace Angliverba
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TestStart = new System.Windows.Forms.Button();
            this.VerbListModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(235, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benvenuto! Cosa desideri fare?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestStart
            // 
            this.TestStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TestStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TestStart.Location = new System.Drawing.Point(78, 121);
            this.TestStart.Name = "TestStart";
            this.TestStart.Size = new System.Drawing.Size(203, 91);
            this.TestStart.TabIndex = 1;
            this.TestStart.Text = "Avvia";
            this.TestStart.UseVisualStyleBackColor = true;
            this.TestStart.Click += new System.EventHandler(this.TestStart_Click);
            // 
            // VerbListModify
            // 
            this.VerbListModify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VerbListModify.ForeColor = System.Drawing.Color.Black;
            this.VerbListModify.Location = new System.Drawing.Point(523, 121);
            this.VerbListModify.Name = "VerbListModify";
            this.VerbListModify.Size = new System.Drawing.Size(203, 91);
            this.VerbListModify.TabIndex = 2;
            this.VerbListModify.Text = "Modifica lista verbi";
            this.VerbListModify.UseVisualStyleBackColor = true;
            this.VerbListModify.Click += new System.EventHandler(this.VerbListModify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 259);
            this.Controls.Add(this.VerbListModify);
            this.Controls.Add(this.TestStart);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Progetto Angliverba";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button TestStart;
        private Button VerbListModify;
    }
}