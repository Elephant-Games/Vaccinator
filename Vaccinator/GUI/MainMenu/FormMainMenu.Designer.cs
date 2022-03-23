
namespace Vaccinator.GUI.MainMenu {
    partial class FormMainMenu {
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
            this.tblOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tblInner = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPtrLeft = new System.Windows.Forms.Label();
            this.lblPtrRight = new System.Windows.Forms.Label();
            this.labelHead = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tblOuter.SuspendLayout();
            this.tblInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblOuter
            // 
            this.tblOuter.ColumnCount = 3;
            this.tblOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblOuter.Controls.Add(this.tblInner, 1, 1);
            this.tblOuter.Controls.Add(this.labelHead, 1, 0);
            this.tblOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOuter.Location = new System.Drawing.Point(0, 0);
            this.tblOuter.Name = "tblOuter";
            this.tblOuter.RowCount = 2;
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblOuter.Size = new System.Drawing.Size(784, 561);
            this.tblOuter.TabIndex = 0;
            // 
            // tblInner
            // 
            this.tblInner.BackColor = System.Drawing.Color.Black;
            this.tblInner.ColumnCount = 3;
            this.tblInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblInner.Controls.Add(this.label1, 1, 0);
            this.tblInner.Controls.Add(this.label2, 1, 1);
            this.tblInner.Controls.Add(this.label3, 1, 2);
            this.tblInner.Controls.Add(this.label4, 1, 3);
            this.tblInner.Controls.Add(this.lblPtrLeft, 0, 0);
            this.tblInner.Controls.Add(this.lblPtrRight, 2, 0);
            this.tblInner.Controls.Add(this.label5, 1, 4);
            this.tblInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInner.Location = new System.Drawing.Point(235, 168);
            this.tblInner.Margin = new System.Windows.Forms.Padding(0);
            this.tblInner.Name = "tblInner";
            this.tblInner.RowCount = 6;
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblInner.Size = new System.Drawing.Size(313, 393);
            this.tblInner.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(93, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "START";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(93, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "SETTINGS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(93, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "RECORDS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(93, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "AUTHORS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPtrLeft
            // 
            this.lblPtrLeft.AutoSize = true;
            this.lblPtrLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPtrLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblPtrLeft.Location = new System.Drawing.Point(3, 0);
            this.lblPtrLeft.Name = "lblPtrLeft";
            this.lblPtrLeft.Size = new System.Drawing.Size(87, 39);
            this.lblPtrLeft.TabIndex = 4;
            this.lblPtrLeft.Text = ")";
            this.lblPtrLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPtrRight
            // 
            this.lblPtrRight.AutoSize = true;
            this.lblPtrRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPtrRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblPtrRight.Location = new System.Drawing.Point(221, 0);
            this.lblPtrRight.Name = "lblPtrRight";
            this.lblPtrRight.Size = new System.Drawing.Size(89, 39);
            this.lblPtrRight.TabIndex = 4;
            this.lblPtrRight.Text = "(";
            this.lblPtrRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHead
            // 
            this.labelHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHead.ForeColor = System.Drawing.Color.Red;
            this.labelHead.Location = new System.Drawing.Point(238, 0);
            this.labelHead.Name = "labelHead";
            this.labelHead.Size = new System.Drawing.Size(307, 168);
            this.labelHead.TabIndex = 1;
            this.labelHead.Text = "VACCINATOR";
            this.labelHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(93, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 39);
            this.label5.TabIndex = 3;
            this.label5.Text = "EXIT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.tblOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FormMainMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tblOuter.ResumeLayout(false);
            this.tblInner.ResumeLayout(false);
            this.tblInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblOuter;
        private System.Windows.Forms.TableLayoutPanel tblInner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelHead;
        private System.Windows.Forms.Label lblPtrLeft;
        private System.Windows.Forms.Label lblPtrRight;
        private System.Windows.Forms.Label label5;
    }
}