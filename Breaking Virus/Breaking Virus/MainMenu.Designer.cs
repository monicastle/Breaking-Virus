namespace Breaking_Virus
{
    partial class MainMenu
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
            this.btn_Singleplayer = new System.Windows.Forms.Button();
            this.btn_Multiplayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Singleplayer
            // 
            this.btn_Singleplayer.BackColor = System.Drawing.Color.Transparent;
            this.btn_Singleplayer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Singleplayer.FlatAppearance.BorderSize = 4;
            this.btn_Singleplayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Singleplayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Singleplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Singleplayer.Font = new System.Drawing.Font("Segoe UI Black", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Singleplayer.ForeColor = System.Drawing.Color.White;
            this.btn_Singleplayer.Location = new System.Drawing.Point(312, 886);
            this.btn_Singleplayer.Name = "btn_Singleplayer";
            this.btn_Singleplayer.Size = new System.Drawing.Size(578, 120);
            this.btn_Singleplayer.TabIndex = 1;
            this.btn_Singleplayer.Text = "SINGLEPLAYER";
            this.btn_Singleplayer.UseVisualStyleBackColor = false;
            this.btn_Singleplayer.Click += new System.EventHandler(this.btn_Singleplayer_Click);
            // 
            // btn_Multiplayer
            // 
            this.btn_Multiplayer.BackColor = System.Drawing.Color.Transparent;
            this.btn_Multiplayer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Multiplayer.FlatAppearance.BorderSize = 4;
            this.btn_Multiplayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Multiplayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Multiplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Multiplayer.Font = new System.Drawing.Font("Segoe UI Black", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Multiplayer.ForeColor = System.Drawing.Color.White;
            this.btn_Multiplayer.Location = new System.Drawing.Point(1013, 886);
            this.btn_Multiplayer.Name = "btn_Multiplayer";
            this.btn_Multiplayer.Size = new System.Drawing.Size(578, 120);
            this.btn_Multiplayer.TabIndex = 2;
            this.btn_Multiplayer.Text = "MULTIPLAYER";
            this.btn_Multiplayer.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImage = global::Breaking_Virus.Resource1.MainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1160);
            this.Controls.Add(this.btn_Multiplayer);
            this.Controls.Add(this.btn_Singleplayer);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btn_Singleplayer;
        private Button btn_Multiplayer;
    }
}