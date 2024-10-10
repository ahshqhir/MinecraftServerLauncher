namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    partial class AddJavaDialog
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
            lblJava = new Label();
            lblTitle = new Label();
            txtJava = new TextBox();
            btnJava = new Button();
            txtTitle = new TextBox();
            ofdJava = new OpenFileDialog();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblJava
            // 
            lblJava.AutoSize = true;
            lblJava.Location = new Point(12, 16);
            lblJava.Name = "lblJava";
            lblJava.Size = new Size(72, 20);
            lblJava.TabIndex = 16;
            lblJava.Text = "Java Path:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 51);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(41, 20);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "Title:";
            // 
            // txtJava
            // 
            txtJava.Location = new Point(90, 13);
            txtJava.Name = "txtJava";
            txtJava.Size = new Size(390, 27);
            txtJava.TabIndex = 0;
            // 
            // btnJava
            // 
            btnJava.Location = new Point(486, 12);
            btnJava.Name = "btnJava";
            btnJava.Size = new Size(94, 29);
            btnJava.TabIndex = 1;
            btnJava.Text = "Browse";
            btnJava.UseVisualStyleBackColor = true;
            btnJava.Click += BtnJava_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(90, 48);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(290, 27);
            txtTitle.TabIndex = 4;
            // 
            // ofdJava
            // 
            ofdJava.DefaultExt = "exe";
            ofdJava.FileName = "java";
            ofdJava.Filter = "Java exe file (java.exe)|java.exe";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(486, 47);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 17;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(386, 47);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddJavaDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(592, 88);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtTitle);
            Controls.Add(btnJava);
            Controls.Add(txtJava);
            Controls.Add(lblTitle);
            Controls.Add(lblJava);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddJavaDialog";
            StartPosition = FormStartPosition.CenterParent;
            Load += AddJavaDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJava;
        private Label lblTitle;
        private TextBox txtJava;
        private Button btnJava;
        private TextBox txtTitle;
        private OpenFileDialog ofdJava;
        private Button btnOk;
        private Button btnCancel;
    }
}