namespace Soundify.NET
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            UpdateStepsPorgressBar = new ReaLTaiizor.Controls.LostProgressBar();
            LogoBox = new PictureBox();
            UpdateLabel = new Label();
            UpdateBtn = new ReaLTaiizor.Controls.HopeButton();
            UpdatePorgressBar = new ReaLTaiizor.Controls.LostProgressBar();
            CancelUpdateBtn = new ReaLTaiizor.Controls.HopeButton();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // UpdateStepsPorgressBar
            // 
            UpdateStepsPorgressBar.BackColor = Color.FromArgb(45, 45, 48);
            UpdateStepsPorgressBar.Color = Color.DodgerBlue;
            UpdateStepsPorgressBar.ForeColor = Color.FromArgb(63, 63, 70);
            UpdateStepsPorgressBar.Hover = true;
            UpdateStepsPorgressBar.Location = new Point(12, 288);
            UpdateStepsPorgressBar.Name = "UpdateStepsPorgressBar";
            UpdateStepsPorgressBar.Progress = 0;
            UpdateStepsPorgressBar.Size = new Size(676, 25);
            UpdateStepsPorgressBar.TabIndex = 0;
            UpdateStepsPorgressBar.Text = "Progress";
            // 
            // LogoBox
            // 
            LogoBox.Dock = DockStyle.Top;
            LogoBox.Image = Properties.Resources.BannerDropShadowLogo;
            LogoBox.Location = new Point(0, 0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new Size(700, 245);
            LogoBox.SizeMode = PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 1;
            LogoBox.TabStop = false;
            // 
            // UpdateLabel
            // 
            UpdateLabel.AutoSize = true;
            UpdateLabel.Font = new Font("Segoe UI", 20F);
            UpdateLabel.Location = new Point(0, 248);
            UpdateLabel.Name = "UpdateLabel";
            UpdateLabel.Size = new Size(158, 37);
            UpdateLabel.TabIndex = 2;
            UpdateLabel.Text = "Update Text";
            // 
            // UpdateBtn
            // 
            UpdateBtn.BorderColor = Color.FromArgb(220, 223, 230);
            UpdateBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            UpdateBtn.DangerColor = Color.FromArgb(245, 108, 108);
            UpdateBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            UpdateBtn.Font = new Font("Segoe UI", 12F);
            UpdateBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            UpdateBtn.InfoColor = Color.FromArgb(144, 147, 153);
            UpdateBtn.Location = new Point(12, 350);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.PrimaryColor = Color.FromArgb(64, 158, 255);
            UpdateBtn.Size = new Size(676, 37);
            UpdateBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            UpdateBtn.TabIndex = 18;
            UpdateBtn.Text = "Update";
            UpdateBtn.TextColor = Color.White;
            UpdateBtn.WarningColor = Color.FromArgb(230, 162, 60);
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // UpdatePorgressBar
            // 
            UpdatePorgressBar.BackColor = Color.FromArgb(45, 45, 48);
            UpdatePorgressBar.Color = Color.DodgerBlue;
            UpdatePorgressBar.ForeColor = Color.FromArgb(63, 63, 70);
            UpdatePorgressBar.Hover = true;
            UpdatePorgressBar.Location = new Point(12, 319);
            UpdatePorgressBar.Name = "UpdatePorgressBar";
            UpdatePorgressBar.Progress = 0;
            UpdatePorgressBar.Size = new Size(676, 25);
            UpdatePorgressBar.TabIndex = 19;
            UpdatePorgressBar.Text = "Progress";
            // 
            // CancelUpdateBtn
            // 
            CancelUpdateBtn.BorderColor = Color.FromArgb(220, 223, 230);
            CancelUpdateBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            CancelUpdateBtn.DangerColor = Color.FromArgb(245, 108, 108);
            CancelUpdateBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            CancelUpdateBtn.Font = new Font("Segoe UI", 12F);
            CancelUpdateBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            CancelUpdateBtn.InfoColor = Color.FromArgb(144, 147, 153);
            CancelUpdateBtn.Location = new Point(12, 393);
            CancelUpdateBtn.Name = "CancelUpdateBtn";
            CancelUpdateBtn.PrimaryColor = Color.FromArgb(192, 0, 0);
            CancelUpdateBtn.Size = new Size(676, 37);
            CancelUpdateBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            CancelUpdateBtn.TabIndex = 20;
            CancelUpdateBtn.Text = "Cancel";
            CancelUpdateBtn.TextColor = Color.White;
            CancelUpdateBtn.WarningColor = Color.FromArgb(230, 162, 60);
            CancelUpdateBtn.Click += CancelUpdateBtn_Click;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(700, 450);
            Controls.Add(CancelUpdateBtn);
            Controls.Add(UpdatePorgressBar);
            Controls.Add(UpdateBtn);
            Controls.Add(UpdateLabel);
            Controls.Add(LogoBox);
            Controls.Add(UpdateStepsPorgressBar);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 450);
            MinimizeBox = false;
            MinimumSize = new Size(700, 450);
            Name = "UpdateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateForm";
            TopMost = true;
            Load += UpdateForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.LostProgressBar UpdateStepsPorgressBar;
        private PictureBox LogoBox;
        private Label UpdateLabel;
        private ReaLTaiizor.Controls.HopeButton UpdateBtn;
        private ReaLTaiizor.Controls.LostProgressBar UpdatePorgressBar;
        private ReaLTaiizor.Controls.HopeButton CancelUpdateBtn;
    }
}