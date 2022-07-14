namespace 暗棋
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.lblB = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReNew = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.ForeColor = System.Drawing.Color.Red;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(240, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(700, 68);
            this.listBox1.TabIndex = 0;
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEnd.Location = new System.Drawing.Point(1038, 531);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(102, 38);
            this.btnEnd.TabIndex = 16;
            this.btnEnd.Text = "結束";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click_1);
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblB.ForeColor = System.Drawing.Color.Blue;
            this.lblB.Location = new System.Drawing.Point(1017, 12);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(0, 21);
            this.lblB.TabIndex = 14;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblR.ForeColor = System.Drawing.Color.Red;
            this.lblR.Location = new System.Drawing.Point(8, 9);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(0, 21);
            this.lblR.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Chartreuse;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1080, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "X";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "O";
            // 
            // pnlBoard
            // 
            this.pnlBoard.AllowDrop = true;
            this.pnlBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBoard.BackgroundImage")));
            this.pnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBoard.Location = new System.Drawing.Point(213, 123);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(727, 390);
            this.pnlBoard.TabIndex = 10;
            this.pnlBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReNew
            // 
            this.btnReNew.BackColor = System.Drawing.Color.Lime;
            this.btnReNew.Enabled = false;
            this.btnReNew.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReNew.Location = new System.Drawing.Point(5, 547);
            this.btnReNew.Name = "btnReNew";
            this.btnReNew.Size = new System.Drawing.Size(96, 38);
            this.btnReNew.TabIndex = 17;
            this.btnReNew.Text = "重新一局";
            this.btnReNew.UseVisualStyleBackColor = false;
            this.btnReNew.Click += new System.EventHandler(this.btnReNew_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.White;
            this.imageList2.Images.SetKeyName(0, "將.png");
            this.imageList2.Images.SetKeyName(1, "士.png");
            this.imageList2.Images.SetKeyName(2, "士.png");
            this.imageList2.Images.SetKeyName(3, "象.png");
            this.imageList2.Images.SetKeyName(4, "象.png");
            this.imageList2.Images.SetKeyName(5, "車.png");
            this.imageList2.Images.SetKeyName(6, "車.png");
            this.imageList2.Images.SetKeyName(7, "馬.png");
            this.imageList2.Images.SetKeyName(8, "馬.png");
            this.imageList2.Images.SetKeyName(9, "泡.png");
            this.imageList2.Images.SetKeyName(10, "泡.png");
            this.imageList2.Images.SetKeyName(11, "卒.png");
            this.imageList2.Images.SetKeyName(12, "卒.png");
            this.imageList2.Images.SetKeyName(13, "卒.png");
            this.imageList2.Images.SetKeyName(14, "卒.png");
            this.imageList2.Images.SetKeyName(15, "卒.png");
            this.imageList2.Images.SetKeyName(16, "黑.png");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "帥.png");
            this.imageList1.Images.SetKeyName(1, "仕.png");
            this.imageList1.Images.SetKeyName(2, "仕.png");
            this.imageList1.Images.SetKeyName(3, "相.png");
            this.imageList1.Images.SetKeyName(4, "相.png");
            this.imageList1.Images.SetKeyName(5, "俥.png");
            this.imageList1.Images.SetKeyName(6, "俥.png");
            this.imageList1.Images.SetKeyName(7, "傌.png");
            this.imageList1.Images.SetKeyName(8, "傌.png");
            this.imageList1.Images.SetKeyName(9, "炮.png");
            this.imageList1.Images.SetKeyName(10, "炮.png");
            this.imageList1.Images.SetKeyName(11, "兵.png");
            this.imageList1.Images.SetKeyName(12, "兵.png");
            this.imageList1.Images.SetKeyName(13, "兵.png");
            this.imageList1.Images.SetKeyName(14, "兵.png");
            this.imageList1.Images.SetKeyName(15, "兵.png");
            this.imageList1.Images.SetKeyName(16, "黑.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1150, 592);
            this.ControlBox = false;
            this.Controls.Add(this.btnReNew);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.RightToLeftLayout = true;
            this.Text = "暗棋";
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnReNew;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
    }
}