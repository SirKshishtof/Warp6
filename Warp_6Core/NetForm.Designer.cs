namespace Warp_6Core
{
    partial class NetForm
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
            GoBack_Button = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // GoBack_Button
            // 
            GoBack_Button.Location = new System.Drawing.Point(12, 409);
            GoBack_Button.Name = "GoBack_Button";
            GoBack_Button.Size = new System.Drawing.Size(94, 29);
            GoBack_Button.TabIndex = 0;
            GoBack_Button.Text = "Назад";
            GoBack_Button.UseVisualStyleBackColor = true;
            GoBack_Button.Click += GoBack_Button_Click;
            // 
            // NetForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(GoBack_Button);
            Name = "NetForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button GoBack_Button;
    }
}