namespace Breaking_Virus
{
    partial class SinglePlayerMenu
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
            this.btn_returnMainMenu = new System.Windows.Forms.Button();
            this.btn_Covid19 = new System.Windows.Forms.Button();
            this.btn_Dengue = new System.Windows.Forms.Button();
            this.btn_Ebola = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_returnMainMenu
            // 
            this.btn_returnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btn_returnMainMenu.FlatAppearance.BorderSize = 0;
            this.btn_returnMainMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_returnMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_returnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_returnMainMenu.Image = global::Breaking_Virus.Resource1.regresar;
            this.btn_returnMainMenu.Location = new System.Drawing.Point(22, 18);
            this.btn_returnMainMenu.Name = "btn_returnMainMenu";
            this.btn_returnMainMenu.Size = new System.Drawing.Size(128, 128);
            this.btn_returnMainMenu.TabIndex = 0;
            this.btn_returnMainMenu.UseVisualStyleBackColor = false;
            this.btn_returnMainMenu.Click += new System.EventHandler(this.btn_returnMainMenu_Click);
            // 
            // btn_Covid19
            // 
            this.btn_Covid19.BackColor = System.Drawing.Color.Transparent;
            this.btn_Covid19.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Covid19.FlatAppearance.BorderSize = 4;
            this.btn_Covid19.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Covid19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Covid19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Covid19.Image = global::Breaking_Virus.Resource1.Covid19;
            this.btn_Covid19.Location = new System.Drawing.Point(143, 328);
            this.btn_Covid19.Name = "btn_Covid19";
            this.btn_Covid19.Size = new System.Drawing.Size(524, 688);
            this.btn_Covid19.TabIndex = 1;
            this.btn_Covid19.UseVisualStyleBackColor = false;
            // 
            // btn_Dengue
            // 
            this.btn_Dengue.BackColor = System.Drawing.Color.Transparent;
            this.btn_Dengue.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Dengue.FlatAppearance.BorderSize = 4;
            this.btn_Dengue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Dengue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Dengue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dengue.Image = global::Breaking_Virus.Resource1.Dengue;
            this.btn_Dengue.Location = new System.Drawing.Point(689, 328);
            this.btn_Dengue.Name = "btn_Dengue";
            this.btn_Dengue.Size = new System.Drawing.Size(525, 688);
            this.btn_Dengue.TabIndex = 2;
            this.btn_Dengue.UseVisualStyleBackColor = false;
            // 
            // btn_Ebola
            // 
            this.btn_Ebola.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ebola.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ebola.FlatAppearance.BorderSize = 4;
            this.btn_Ebola.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Ebola.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Ebola.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ebola.Image = global::Breaking_Virus.Resource1.Ebola;
            this.btn_Ebola.Location = new System.Drawing.Point(1235, 328);
            this.btn_Ebola.Name = "btn_Ebola";
            this.btn_Ebola.Size = new System.Drawing.Size(525, 688);
            this.btn_Ebola.TabIndex = 3;
            this.btn_Ebola.UseVisualStyleBackColor = false;
            // 
            // SinglePlayerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Breaking_Virus.Resource1.Select_Virus_SP;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1160);
            this.Controls.Add(this.btn_Ebola);
            this.Controls.Add(this.btn_Dengue);
            this.Controls.Add(this.btn_Covid19);
            this.Controls.Add(this.btn_returnMainMenu);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "SinglePlayerMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Selection";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_returnMainMenu;
        private Button btn_Covid19;
        private Button btn_Dengue;
        private Button btn_Ebola;
    }
}