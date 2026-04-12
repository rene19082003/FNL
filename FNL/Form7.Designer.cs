namespace FNL
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            dataGridViewprvaci = new DataGridView();
            dataGridView_ljestvica = new DataGridView();
            richTextBox_info = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewprvaci).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ljestvica).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewprvaci
            // 
            dataGridViewprvaci.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewprvaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewprvaci.Location = new Point(47, 41);
            dataGridViewprvaci.Name = "dataGridViewprvaci";
            dataGridViewprvaci.RowHeadersWidth = 51;
            dataGridViewprvaci.Size = new Size(261, 388);
            dataGridViewprvaci.TabIndex = 0;
            // 
            // dataGridView_ljestvica
            // 
            dataGridView_ljestvica.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView_ljestvica.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ljestvica.Location = new Point(596, 41);
            dataGridView_ljestvica.Name = "dataGridView_ljestvica";
            dataGridView_ljestvica.RowHeadersWidth = 51;
            dataGridView_ljestvica.Size = new Size(300, 388);
            dataGridView_ljestvica.TabIndex = 1;
            // 
            // richTextBox_info
            // 
            richTextBox_info.Location = new Point(340, 41);
            richTextBox_info.Name = "richTextBox_info";
            richTextBox_info.Size = new Size(205, 388);
            richTextBox_info.TabIndex = 2;
            richTextBox_info.Text = "";
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(934, 458);
            Controls.Add(richTextBox_info);
            Controls.Add(dataGridView_ljestvica);
            Controls.Add(dataGridViewprvaci);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prvaci";
            Load += Form7_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewprvaci).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ljestvica).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewprvaci;
        private DataGridView dataGridView_ljestvica;
        private RichTextBox richTextBox_info;
    }
}