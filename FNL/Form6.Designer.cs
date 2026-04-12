namespace FNL
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            klubovi_pb = new PictureBox();
            fnl_pb = new PictureBox();
            zanimljivosti_pb = new PictureBox();
            pocetno_pb = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)klubovi_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fnl_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zanimljivosti_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pocetno_pb).BeginInit();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 85);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(400, 328);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(418, 85);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(438, 328);
            richTextBox2.TabIndex = 2;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(862, 85);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(436, 328);
            richTextBox3.TabIndex = 3;
            richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(1304, 85);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(423, 328);
            richTextBox4.TabIndex = 4;
            richTextBox4.Text = "";
            // 
            // klubovi_pb
            // 
            klubovi_pb.Location = new Point(862, 435);
            klubovi_pb.Name = "klubovi_pb";
            klubovi_pb.Size = new Size(436, 259);
            klubovi_pb.TabIndex = 5;
            klubovi_pb.TabStop = false;
            // 
            // fnl_pb
            // 
            fnl_pb.Location = new Point(418, 435);
            fnl_pb.Name = "fnl_pb";
            fnl_pb.Size = new Size(438, 259);
            fnl_pb.TabIndex = 6;
            fnl_pb.TabStop = false;
            // 
            // zanimljivosti_pb
            // 
            zanimljivosti_pb.Location = new Point(1304, 435);
            zanimljivosti_pb.Name = "zanimljivosti_pb";
            zanimljivosti_pb.Size = new Size(422, 259);
            zanimljivosti_pb.TabIndex = 7;
            zanimljivosti_pb.TabStop = false;
            // 
            // pocetno_pb
            // 
            pocetno_pb.Location = new Point(12, 435);
            pocetno_pb.Name = "pocetno_pb";
            pocetno_pb.Size = new Size(400, 259);
            pocetno_pb.TabIndex = 8;
            pocetno_pb.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 55);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 9;
            label2.Text = "Početno razdoblje";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(521, 55);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1061, 55);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 11;
            label4.Text = "Klubovi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1486, 55);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 12;
            label5.Text = "Zanimljivosti ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(612, 55);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 13;
            label1.Text = "FNL";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1738, 706);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pocetno_pb);
            Controls.Add(zanimljivosti_pb);
            Controls.Add(fnl_pb);
            Controls.Add(klubovi_pb);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Povijest lige";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)klubovi_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)fnl_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)zanimljivosti_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pocetno_pb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private PictureBox klubovi_pb;
        private PictureBox fnl_pb;
        private PictureBox zanimljivosti_pb;
        private PictureBox pocetno_pb;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label1;
    }
}