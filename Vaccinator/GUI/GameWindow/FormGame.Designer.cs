
namespace Vaccinator.GUI.GameWindow {
    partial class FormGame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAmmoT = new System.Windows.Forms.Label();
            this.labelAmmoC = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelAmmoT);
            this.panel1.Controls.Add(this.labelAmmoC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 41);
            this.panel1.TabIndex = 0;
            // 
            // labelAmmoT
            // 
            this.labelAmmoT.BackColor = System.Drawing.Color.Black;
            this.labelAmmoT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelAmmoT.Location = new System.Drawing.Point(634, 0);
            this.labelAmmoT.Name = "labelAmmoT";
            this.labelAmmoT.Size = new System.Drawing.Size(112, 41);
            this.labelAmmoT.TabIndex = 1;
            this.labelAmmoT.Text = "AMMO:";
            this.labelAmmoT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAmmoC
            // 
            this.labelAmmoC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelAmmoC.Location = new System.Drawing.Point(752, 0);
            this.labelAmmoC.Name = "labelAmmoC";
            this.labelAmmoC.Size = new System.Drawing.Size(29, 41);
            this.labelAmmoC.TabIndex = 0;
            this.labelAmmoC.Text = "0";
            this.labelAmmoC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormGame";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAmmoT;
        private System.Windows.Forms.Label labelAmmoC;
    }
}