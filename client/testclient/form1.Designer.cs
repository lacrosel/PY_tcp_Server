
namespace testclient
{
    partial class Form1
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
            this.btn_servconnect = new System.Windows.Forms.Button();
            this.lbl_inname = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_servconnect
            // 
            this.btn_servconnect.Location = new System.Drawing.Point(418, 270);
            this.btn_servconnect.Name = "btn_servconnect";
            this.btn_servconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_servconnect.TabIndex = 7;
            this.btn_servconnect.Text = "connect";
            this.btn_servconnect.UseVisualStyleBackColor = true;
            this.btn_servconnect.Click += new System.EventHandler(this.btn_servconnect_Click);
            // 
            // lbl_inname
            // 
            this.lbl_inname.Location = new System.Drawing.Point(305, 270);
            this.lbl_inname.Name = "lbl_inname";
            this.lbl_inname.Size = new System.Drawing.Size(86, 21);
            this.lbl_inname.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(302, 234);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 21);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "10.10.21.107";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_inname);
            this.Controls.Add(this.btn_servconnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_servconnect;
        private System.Windows.Forms.TextBox lbl_inname;
        private System.Windows.Forms.TextBox textBox1;
    }
}