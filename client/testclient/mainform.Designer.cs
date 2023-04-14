
namespace testclient
{
    partial class mainform
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.signallog = new System.Windows.Forms.ListBox();
            this.pbox_mine = new System.Windows.Forms.PictureBox();
            this.btn_stream = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.pb6 = new System.Windows.Forms.PictureBox();
            this.pb5 = new System.Windows.Forms.PictureBox();
            this.pb7 = new System.Windows.Forms.PictureBox();
            this.pb9 = new System.Windows.Forms.PictureBox();
            this.pb8 = new System.Windows.Forms.PictureBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_mine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // signallog
            // 
            this.signallog.FormattingEnabled = true;
            this.signallog.ItemHeight = 12;
            this.signallog.Location = new System.Drawing.Point(628, 12);
            this.signallog.Name = "signallog";
            this.signallog.Size = new System.Drawing.Size(95, 364);
            this.signallog.TabIndex = 1;
            // 
            // pbox_mine
            // 
            this.pbox_mine.Location = new System.Drawing.Point(-8, 13);
            this.pbox_mine.Name = "pbox_mine";
            this.pbox_mine.Size = new System.Drawing.Size(553, 567);
            this.pbox_mine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_mine.TabIndex = 10;
            this.pbox_mine.TabStop = false;
            // 
            // btn_stream
            // 
            this.btn_stream.Location = new System.Drawing.Point(628, 443);
            this.btn_stream.Name = "btn_stream";
            this.btn_stream.Size = new System.Drawing.Size(95, 66);
            this.btn_stream.TabIndex = 8;
            this.btn_stream.Text = "Start";
            this.btn_stream.UseVisualStyleBackColor = true;
            this.btn_stream.Click += new System.EventHandler(this.checker_Streaming);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(665, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "light";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(655, 554);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 25);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb2
            // 
            this.pb2.Location = new System.Drawing.Point(223, 122);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(100, 100);
            this.pb2.TabIndex = 15;
            this.pb2.TabStop = false;
            this.pb2.Visible = false;
            this.pb2.Click += new System.EventHandler(this.pb2_Click);
            // 
            // pb3
            // 
            this.pb3.Location = new System.Drawing.Point(366, 122);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(100, 100);
            this.pb3.TabIndex = 16;
            this.pb3.TabStop = false;
            this.pb3.Visible = false;
            this.pb3.Click += new System.EventHandler(this.pb3_Click);
            // 
            // pb4
            // 
            this.pb4.Location = new System.Drawing.Point(80, 253);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(100, 100);
            this.pb4.TabIndex = 17;
            this.pb4.TabStop = false;
            this.pb4.Visible = false;
            this.pb4.Click += new System.EventHandler(this.pb4_Click);
            // 
            // pb6
            // 
            this.pb6.Location = new System.Drawing.Point(366, 253);
            this.pb6.Name = "pb6";
            this.pb6.Size = new System.Drawing.Size(100, 100);
            this.pb6.TabIndex = 18;
            this.pb6.TabStop = false;
            this.pb6.Visible = false;
            this.pb6.Click += new System.EventHandler(this.pb6_Click);
            // 
            // pb5
            // 
            this.pb5.Location = new System.Drawing.Point(223, 253);
            this.pb5.Name = "pb5";
            this.pb5.Size = new System.Drawing.Size(100, 100);
            this.pb5.TabIndex = 19;
            this.pb5.TabStop = false;
            this.pb5.Visible = false;
            this.pb5.Click += new System.EventHandler(this.pb5_Click);
            // 
            // pb7
            // 
            this.pb7.Location = new System.Drawing.Point(80, 389);
            this.pb7.Name = "pb7";
            this.pb7.Size = new System.Drawing.Size(100, 100);
            this.pb7.TabIndex = 20;
            this.pb7.TabStop = false;
            this.pb7.Visible = false;
            this.pb7.Click += new System.EventHandler(this.pb7_Click);
            // 
            // pb9
            // 
            this.pb9.Location = new System.Drawing.Point(366, 389);
            this.pb9.Name = "pb9";
            this.pb9.Size = new System.Drawing.Size(100, 100);
            this.pb9.TabIndex = 21;
            this.pb9.TabStop = false;
            this.pb9.Visible = false;
            this.pb9.Click += new System.EventHandler(this.pb9_Click);
            // 
            // pb8
            // 
            this.pb8.Location = new System.Drawing.Point(223, 389);
            this.pb8.Name = "pb8";
            this.pb8.Size = new System.Drawing.Size(100, 100);
            this.pb8.TabIndex = 22;
            this.pb8.TabStop = false;
            this.pb8.Visible = false;
            this.pb8.Click += new System.EventHandler(this.pb8_Click);
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(80, 122);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(100, 100);
            this.pb1.TabIndex = 14;
            this.pb1.TabStop = false;
            this.pb1.Visible = false;
            this.pb1.Click += new System.EventHandler(this.pb1_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 591);
            this.Controls.Add(this.pb8);
            this.Controls.Add(this.pb9);
            this.Controls.Add(this.pb7);
            this.Controls.Add(this.pb5);
            this.Controls.Add(this.pb6);
            this.Controls.Add(this.pb4);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbox_mine);
            this.Controls.Add(this.btn_stream);
            this.Controls.Add(this.signallog);
            this.Name = "mainform";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbox_mine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox signallog;
        private System.Windows.Forms.PictureBox pbox_mine;
        private System.Windows.Forms.Button btn_stream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.PictureBox pb6;
        private System.Windows.Forms.PictureBox pb5;
        private System.Windows.Forms.PictureBox pb7;
        private System.Windows.Forms.PictureBox pb9;
        private System.Windows.Forms.PictureBox pb8;
        private System.Windows.Forms.PictureBox pb1;
    }
}

