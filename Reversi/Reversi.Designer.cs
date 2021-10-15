namespace Reversi
{
    partial class Reversi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reversi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Speler1 = new System.Windows.Forms.Label();
            this.Speler2 = new System.Windows.Forms.Label();
            this.BeurtAan = new System.Windows.Forms.Label();
            this.NieuwSpel = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.Naam1 = new System.Windows.Forms.Label();
            this.Naam2 = new System.Windows.Forms.Label();
            this.Startscherm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Location = new System.Drawing.Point(204, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 702);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Reversipanel_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Muisklik);
            // 
            // Speler1
            // 
            this.Speler1.AutoSize = true;
            this.Speler1.ForeColor = System.Drawing.Color.LightGray;
            this.Speler1.Location = new System.Drawing.Point(152, 46);
            this.Speler1.Name = "Speler1";
            this.Speler1.Size = new System.Drawing.Size(16, 17);
            this.Speler1.TabIndex = 1;
            this.Speler1.Text = "2";
            // 
            // Speler2
            // 
            this.Speler2.AutoSize = true;
            this.Speler2.ForeColor = System.Drawing.Color.LightGray;
            this.Speler2.Location = new System.Drawing.Point(164, 138);
            this.Speler2.Name = "Speler2";
            this.Speler2.Size = new System.Drawing.Size(16, 17);
            this.Speler2.TabIndex = 2;
            this.Speler2.Text = "2";
            // 
            // BeurtAan
            // 
            this.BeurtAan.AutoSize = true;
            this.BeurtAan.Location = new System.Drawing.Point(20, 199);
            this.BeurtAan.Name = "BeurtAan";
            this.BeurtAan.Size = new System.Drawing.Size(28, 17);
            this.BeurtAan.TabIndex = 3;
            this.BeurtAan.Text = "Wit";
            // 
            // NieuwSpel
            // 
            this.NieuwSpel.Location = new System.Drawing.Point(8, 561);
            this.NieuwSpel.Name = "NieuwSpel";
            this.NieuwSpel.Size = new System.Drawing.Size(190, 44);
            this.NieuwSpel.TabIndex = 4;
            this.NieuwSpel.Text = "Nieuw Spel";
            this.NieuwSpel.UseVisualStyleBackColor = true;
            this.NieuwSpel.Click += new System.EventHandler(this.NieuwSpel_Click);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(12, 611);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(186, 43);
            this.Help.TabIndex = 5;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Naam1
            // 
            this.Naam1.AutoSize = true;
            this.Naam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Naam1.ForeColor = System.Drawing.Color.LightGray;
            this.Naam1.Location = new System.Drawing.Point(12, 33);
            this.Naam1.Name = "Naam1";
            this.Naam1.Size = new System.Drawing.Size(39, 42);
            this.Naam1.TabIndex = 6;
            this.Naam1.Text = "1";
            // 
            // Naam2
            // 
            this.Naam2.AutoSize = true;
            this.Naam2.ForeColor = System.Drawing.Color.LightGray;
            this.Naam2.Location = new System.Drawing.Point(20, 119);
            this.Naam2.Name = "Naam2";
            this.Naam2.Size = new System.Drawing.Size(16, 17);
            this.Naam2.TabIndex = 7;
            this.Naam2.Text = "2";
            // 
            // Startscherm
            // 
            this.Startscherm.Location = new System.Drawing.Point(12, 660);
            this.Startscherm.Name = "Startscherm";
            this.Startscherm.Size = new System.Drawing.Size(186, 43);
            this.Startscherm.TabIndex = 8;
            this.Startscherm.Text = "Menu";
            this.Startscherm.UseVisualStyleBackColor = true;
            this.Startscherm.Click += new System.EventHandler(this.Startscherm_Click);
            // 
            // Reversi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(932, 803);
            this.Controls.Add(this.NieuwSpel);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Startscherm);
            this.Controls.Add(this.Naam2);
            this.Controls.Add(this.Naam1);
            this.Controls.Add(this.BeurtAan);
            this.Controls.Add(this.Speler2);
            this.Controls.Add(this.Speler1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reversi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reversi";
            this.TransparencyKey = System.Drawing.Color.DarkCyan;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reversi_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Speler1;
        private System.Windows.Forms.Label Speler2;
        private System.Windows.Forms.Label BeurtAan;
        private System.Windows.Forms.Button NieuwSpel;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Label Naam1;
        private System.Windows.Forms.Label Naam2;
        private System.Windows.Forms.Button Startscherm;
    }
}

