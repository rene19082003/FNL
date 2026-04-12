namespace FNL
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
            glavni_izbornik = new MenuStrip();
            aktualnaSezonaToolStripMenuItem = new ToolStripMenuItem();
            tablicaToolStripMenuItem = new ToolStripMenuItem();
            rasporedIRezultatiToolStripMenuItem = new ToolStripMenuItem();
            kluboviIIgračiToolStripMenuItem = new ToolStripMenuItem();
            kluboviToolStripMenuItem1 = new ToolStripMenuItem();
            povijestFNLaToolStripMenuItem = new ToolStripMenuItem();
            povijestLigeToolStripMenuItem = new ToolStripMenuItem();
            prvaciKrozGodineToolStripMenuItem = new ToolStripMenuItem();
            glavni_izbornik.SuspendLayout();
            SuspendLayout();
            // 
            // glavni_izbornik
            // 
            glavni_izbornik.BackColor = Color.White;
            glavni_izbornik.Dock = DockStyle.Left;
            glavni_izbornik.ImageScalingSize = new Size(20, 20);
            glavni_izbornik.Items.AddRange(new ToolStripItem[] { aktualnaSezonaToolStripMenuItem, kluboviToolStripMenuItem1, povijestFNLaToolStripMenuItem });
            glavni_izbornik.LayoutStyle = ToolStripLayoutStyle.Table;
            glavni_izbornik.Location = new Point(0, 0);
            glavni_izbornik.Name = "glavni_izbornik";
            glavni_izbornik.Size = new Size(137, 435);
            glavni_izbornik.Stretch = false;
            glavni_izbornik.TabIndex = 0;
            glavni_izbornik.Text = "menuStrip1";
            glavni_izbornik.ItemClicked += glavni_izbornik_ItemClicked;
            // 
            // aktualnaSezonaToolStripMenuItem
            // 
            aktualnaSezonaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tablicaToolStripMenuItem, rasporedIRezultatiToolStripMenuItem, kluboviIIgračiToolStripMenuItem });
            aktualnaSezonaToolStripMenuItem.Name = "aktualnaSezonaToolStripMenuItem";
            aktualnaSezonaToolStripMenuItem.Size = new Size(131, 24);
            aktualnaSezonaToolStripMenuItem.Text = "Aktualna sezona";
            aktualnaSezonaToolStripMenuItem.Click += aktualnaSezonaToolStripMenuItem_Click;
            // 
            // tablicaToolStripMenuItem
            // 
            tablicaToolStripMenuItem.Name = "tablicaToolStripMenuItem";
            tablicaToolStripMenuItem.Size = new Size(221, 26);
            tablicaToolStripMenuItem.Text = "Ligaška tablica";
            tablicaToolStripMenuItem.Click += kluboviToolStripMenuItem_Click;
            // 
            // rasporedIRezultatiToolStripMenuItem
            // 
            rasporedIRezultatiToolStripMenuItem.Name = "rasporedIRezultatiToolStripMenuItem";
            rasporedIRezultatiToolStripMenuItem.Size = new Size(221, 26);
            rasporedIRezultatiToolStripMenuItem.Text = "Raspored i rezultati";
            rasporedIRezultatiToolStripMenuItem.Click += rasporedIRezultatiToolStripMenuItem_Click;
            // 
            // kluboviIIgračiToolStripMenuItem
            // 
            kluboviIIgračiToolStripMenuItem.Name = "kluboviIIgračiToolStripMenuItem";
            kluboviIIgračiToolStripMenuItem.Size = new Size(221, 26);
            kluboviIIgračiToolStripMenuItem.Text = "Klubovi i Igrači";
            kluboviIIgračiToolStripMenuItem.Click += kluboviIIgraciToolStripMenuItem_Click;
            // 
            // kluboviToolStripMenuItem1
            // 
            kluboviToolStripMenuItem1.Name = "kluboviToolStripMenuItem1";
            kluboviToolStripMenuItem1.Size = new Size(73, 24);
            kluboviToolStripMenuItem1.Text = "Klubovi";
            kluboviToolStripMenuItem1.Click += kluboviToolStripMenuItem1_Click;
            // 
            // povijestFNLaToolStripMenuItem
            // 
            povijestFNLaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { povijestLigeToolStripMenuItem, prvaciKrozGodineToolStripMenuItem });
            povijestFNLaToolStripMenuItem.Name = "povijestFNLaToolStripMenuItem";
            povijestFNLaToolStripMenuItem.Size = new Size(116, 24);
            povijestFNLaToolStripMenuItem.Text = "Povijest FNL-a";
            // 
            // povijestLigeToolStripMenuItem
            // 
            povijestLigeToolStripMenuItem.Name = "povijestLigeToolStripMenuItem";
            povijestLigeToolStripMenuItem.Size = new Size(224, 26);
            povijestLigeToolStripMenuItem.Text = "Povijest lige";
            povijestLigeToolStripMenuItem.Click += povijestLigeToolStripMenuItem_Click;
            // 
            // prvaciKrozGodineToolStripMenuItem
            // 
            prvaciKrozGodineToolStripMenuItem.Name = "prvaciKrozGodineToolStripMenuItem";
            prvaciKrozGodineToolStripMenuItem.Size = new Size(224, 26);
            prvaciKrozGodineToolStripMenuItem.Text = "Prvaci kroz godine";
            prvaciKrozGodineToolStripMenuItem.Click += prvaciKrozGodineToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(828, 435);
            Controls.Add(glavni_izbornik);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = glavni_izbornik;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FNL";
            Load += Form1_Load;
            glavni_izbornik.ResumeLayout(false);
            glavni_izbornik.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip glavni_izbornik;
        private ToolStripMenuItem aktualnaSezonaToolStripMenuItem;
        private ToolStripMenuItem tablicaToolStripMenuItem;
        private ToolStripMenuItem kluboviToolStripMenuItem1;
        private ToolStripMenuItem povijestFNLaToolStripMenuItem;
        private ToolStripMenuItem rasporedIRezultatiToolStripMenuItem;
        private ToolStripMenuItem kluboviIIgračiToolStripMenuItem;
        private ToolStripMenuItem povijestLigeToolStripMenuItem;
        private ToolStripMenuItem prvaciKrozGodineToolStripMenuItem;
    }
}
