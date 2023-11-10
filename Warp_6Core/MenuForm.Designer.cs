namespace Warp_6Core
{
    partial class MenuForm
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
            NewGameButton = new System.Windows.Forms.Button();
            GameExit = new System.Windows.Forms.Button();
            DownloadGameButtom = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // NewGameButton
            // 
            NewGameButton.BackColor = System.Drawing.SystemColors.Control;
            NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NewGameButton.Location = new System.Drawing.Point(194, 142);
            NewGameButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new System.Drawing.Size(389, 48);
            NewGameButton.TabIndex = 19;
            NewGameButton.Text = "Новая игра";
            NewGameButton.UseVisualStyleBackColor = false;
            NewGameButton.Click += NewGameButton_Click;
            // 
            // GameExit
            // 
            GameExit.BackColor = System.Drawing.SystemColors.Control;
            GameExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8000011F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GameExit.Location = new System.Drawing.Point(194, 275);
            GameExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GameExit.Name = "GameExit";
            GameExit.Size = new System.Drawing.Size(389, 48);
            GameExit.TabIndex = 35;
            GameExit.Text = "Выйти из игры";
            GameExit.UseVisualStyleBackColor = false;
            GameExit.Click += GameExit_Click;
            // 
            // DownloadGameButtom
            // 
            DownloadGameButtom.BackColor = System.Drawing.SystemColors.Control;
            DownloadGameButtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DownloadGameButtom.Location = new System.Drawing.Point(194, 210);
            DownloadGameButtom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            DownloadGameButtom.Name = "DownloadGameButtom";
            DownloadGameButtom.Size = new System.Drawing.Size(389, 48);
            DownloadGameButtom.TabIndex = 36;
            DownloadGameButtom.Text = "Загрузка игры";
            DownloadGameButtom.UseVisualStyleBackColor = false;
            DownloadGameButtom.Click += DownloadGameButtom_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(GameExit);
            Controls.Add(DownloadGameButtom);
            Controls.Add(NewGameButton);
            Name = "MenuForm";
            Text = "Form1";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += MenuForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button GameExit;
        private System.Windows.Forms.Button DownloadGameButtom;
    }
}