﻿namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    partial class AddServerDialog
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
            components = new System.ComponentModel.Container();
            lblServerJar = new Label();
            lblDirectory = new Label();
            lblTitle = new Label();
            lblAllocRam = new Label();
            lblMaxRam = new Label();
            txtServerJar = new TextBox();
            btnServerJar = new Button();
            txtDirectory = new TextBox();
            btnDirectory = new Button();
            numAllocRam = new NumericUpDown();
            numMaxRam = new NumericUpDown();
            txtTitle = new TextBox();
            cbAllocRam = new ComboBox();
            cbMaxRam = new ComboBox();
            btnCancel = new Button();
            btnOk = new Button();
            ofdServerJar = new OpenFileDialog();
            fbdDirectory = new FolderBrowserDialog();
            lvJarArgument = new ListView();
            cmsArgument = new ContextMenuStrip(components);
            cmsArgumentAdd = new ToolStripMenuItem();
            cmsArgumentEdit = new ToolStripMenuItem();
            cmsArgumentDelete = new ToolStripMenuItem();
            lvJavaArgument = new ListView();
            lblJarArgument = new Label();
            lblJavaArgument = new Label();
            cbJava = new ComboBox();
            lblJava = new Label();
            ((System.ComponentModel.ISupportInitialize)numAllocRam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxRam).BeginInit();
            cmsArgument.SuspendLayout();
            SuspendLayout();
            // 
            // lblServerJar
            // 
            lblServerJar.AutoSize = true;
            lblServerJar.Location = new Point(12, 16);
            lblServerJar.Name = "lblServerJar";
            lblServerJar.Size = new Size(106, 20);
            lblServerJar.TabIndex = 14;
            lblServerJar.Text = "Server JAR file:";
            // 
            // lblDirectory
            // 
            lblDirectory.AutoSize = true;
            lblDirectory.Location = new Point(12, 51);
            lblDirectory.Name = "lblDirectory";
            lblDirectory.Size = new Size(132, 20);
            lblDirectory.TabIndex = 15;
            lblDirectory.Text = "Working Directory:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 122);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(41, 20);
            lblTitle.TabIndex = 17;
            lblTitle.Text = "Title:";
            // 
            // lblAllocRam
            // 
            lblAllocRam.AutoSize = true;
            lblAllocRam.Location = new Point(12, 157);
            lblAllocRam.Name = "lblAllocRam";
            lblAllocRam.Size = new Size(135, 20);
            lblAllocRam.TabIndex = 18;
            lblAllocRam.Text = "Allocated Memory:";
            // 
            // lblMaxRam
            // 
            lblMaxRam.AutoSize = true;
            lblMaxRam.Location = new Point(12, 192);
            lblMaxRam.Name = "lblMaxRam";
            lblMaxRam.Size = new Size(137, 20);
            lblMaxRam.TabIndex = 19;
            lblMaxRam.Text = "Maximum Memory:";
            // 
            // txtServerJar
            // 
            txtServerJar.Location = new Point(155, 13);
            txtServerJar.Name = "txtServerJar";
            txtServerJar.Size = new Size(325, 27);
            txtServerJar.TabIndex = 0;
            // 
            // btnServerJar
            // 
            btnServerJar.Location = new Point(486, 12);
            btnServerJar.Name = "btnServerJar";
            btnServerJar.Size = new Size(94, 29);
            btnServerJar.TabIndex = 1;
            btnServerJar.Text = "Browse";
            btnServerJar.UseVisualStyleBackColor = true;
            btnServerJar.Click += BtnServerJar_Click;
            // 
            // txtDirectory
            // 
            txtDirectory.Location = new Point(155, 48);
            txtDirectory.Name = "txtDirectory";
            txtDirectory.Size = new Size(325, 27);
            txtDirectory.TabIndex = 2;
            // 
            // btnDirectory
            // 
            btnDirectory.Location = new Point(486, 47);
            btnDirectory.Name = "btnDirectory";
            btnDirectory.Size = new Size(94, 29);
            btnDirectory.TabIndex = 3;
            btnDirectory.Text = "Browse";
            btnDirectory.UseVisualStyleBackColor = true;
            btnDirectory.Click += BtnDirectory_Click;
            // 
            // numAllocRam
            // 
            numAllocRam.Location = new Point(155, 155);
            numAllocRam.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAllocRam.Name = "numAllocRam";
            numAllocRam.Size = new Size(100, 27);
            numAllocRam.TabIndex = 6;
            numAllocRam.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numMaxRam
            // 
            numMaxRam.Location = new Point(155, 190);
            numMaxRam.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxRam.Name = "numMaxRam";
            numMaxRam.Size = new Size(100, 27);
            numMaxRam.TabIndex = 8;
            numMaxRam.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(155, 119);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 27);
            txtTitle.TabIndex = 5;
            // 
            // cbAllocRam
            // 
            cbAllocRam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAllocRam.FormattingEnabled = true;
            cbAllocRam.Location = new Point(261, 154);
            cbAllocRam.Name = "cbAllocRam";
            cbAllocRam.Size = new Size(94, 28);
            cbAllocRam.TabIndex = 7;
            // 
            // cbMaxRam
            // 
            cbMaxRam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaxRam.FormattingEnabled = true;
            cbMaxRam.Location = new Point(261, 189);
            cbMaxRam.Name = "cbMaxRam";
            cbMaxRam.Size = new Size(94, 28);
            cbMaxRam.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 17F);
            btnCancel.Location = new Point(381, 86);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(179, 55);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Segoe UI", 17F);
            btnOk.Location = new Point(380, 153);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(181, 56);
            btnOk.TabIndex = 12;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // ofdServerJar
            // 
            ofdServerJar.DefaultExt = "jar";
            ofdServerJar.Filter = "JAR Files (*.jar)|*.jar";
            // 
            // lvJarArgument
            // 
            lvJarArgument.AllowDrop = true;
            lvJarArgument.ContextMenuStrip = cmsArgument;
            lvJarArgument.HeaderStyle = ColumnHeaderStyle.None;
            lvJarArgument.LabelEdit = true;
            lvJarArgument.Location = new Point(299, 243);
            lvJarArgument.Name = "lvJarArgument";
            lvJarArgument.Size = new Size(281, 200);
            lvJarArgument.TabIndex = 11;
            lvJarArgument.UseCompatibleStateImageBehavior = false;
            lvJarArgument.View = View.List;
            // 
            // cmsArgument
            // 
            cmsArgument.ImageScalingSize = new Size(20, 20);
            cmsArgument.Items.AddRange(new ToolStripItem[] { cmsArgumentAdd, cmsArgumentEdit, cmsArgumentDelete });
            cmsArgument.Name = "cmsArgument";
            cmsArgument.Size = new Size(123, 76);
            cmsArgument.Opening += CmsArgument_Opening;
            // 
            // cmsArgumentAdd
            // 
            cmsArgumentAdd.Name = "cmsArgumentAdd";
            cmsArgumentAdd.Size = new Size(122, 24);
            cmsArgumentAdd.Text = "Add";
            cmsArgumentAdd.Click += CmsArgumentAdd_Click;
            // 
            // cmsArgumentEdit
            // 
            cmsArgumentEdit.Name = "cmsArgumentEdit";
            cmsArgumentEdit.Size = new Size(122, 24);
            cmsArgumentEdit.Text = "Edit";
            cmsArgumentEdit.Click += CmsArgumentEdit_Click;
            // 
            // cmsArgumentDelete
            // 
            cmsArgumentDelete.Name = "cmsArgumentDelete";
            cmsArgumentDelete.Size = new Size(122, 24);
            cmsArgumentDelete.Text = "Delete";
            cmsArgumentDelete.Click += CmsArgumentDelete_Click;
            // 
            // lvJavaArgument
            // 
            lvJavaArgument.AllowDrop = true;
            lvJavaArgument.ContextMenuStrip = cmsArgument;
            lvJavaArgument.HeaderStyle = ColumnHeaderStyle.None;
            lvJavaArgument.LabelEdit = true;
            lvJavaArgument.Location = new Point(12, 243);
            lvJavaArgument.Name = "lvJavaArgument";
            lvJavaArgument.Size = new Size(281, 200);
            lvJavaArgument.TabIndex = 10;
            lvJavaArgument.UseCompatibleStateImageBehavior = false;
            lvJavaArgument.View = View.List;
            // 
            // lblJarArgument
            // 
            lblJarArgument.AutoSize = true;
            lblJarArgument.Location = new Point(299, 220);
            lblJarArgument.Name = "lblJarArgument";
            lblJarArgument.Size = new Size(166, 20);
            lblJarArgument.TabIndex = 21;
            lblJarArgument.Text = "Extra Server Arguments:";
            // 
            // lblJavaArgument
            // 
            lblJavaArgument.AutoSize = true;
            lblJavaArgument.Location = new Point(12, 220);
            lblJavaArgument.Name = "lblJavaArgument";
            lblJavaArgument.Size = new Size(153, 20);
            lblJavaArgument.TabIndex = 20;
            lblJavaArgument.Text = "Extra Java Arguments:";
            // 
            // cbJava
            // 
            cbJava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJava.FormattingEnabled = true;
            cbJava.Location = new Point(155, 83);
            cbJava.Name = "cbJava";
            cbJava.Size = new Size(200, 28);
            cbJava.TabIndex = 4;
            // 
            // lblJava
            // 
            lblJava.AutoSize = true;
            lblJava.Location = new Point(12, 86);
            lblJava.Name = "lblJava";
            lblJava.Size = new Size(40, 20);
            lblJava.TabIndex = 16;
            lblJava.Text = "Java:";
            // 
            // AddServerDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(592, 455);
            Controls.Add(lblJava);
            Controls.Add(cbJava);
            Controls.Add(lblJavaArgument);
            Controls.Add(lblJarArgument);
            Controls.Add(lvJavaArgument);
            Controls.Add(lvJarArgument);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(cbMaxRam);
            Controls.Add(cbAllocRam);
            Controls.Add(txtTitle);
            Controls.Add(numMaxRam);
            Controls.Add(numAllocRam);
            Controls.Add(btnDirectory);
            Controls.Add(txtDirectory);
            Controls.Add(btnServerJar);
            Controls.Add(txtServerJar);
            Controls.Add(lblMaxRam);
            Controls.Add(lblAllocRam);
            Controls.Add(lblTitle);
            Controls.Add(lblDirectory);
            Controls.Add(lblServerJar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddServerDialog";
            StartPosition = FormStartPosition.CenterParent;
            Load += AddServerDialog_Load;
            ((System.ComponentModel.ISupportInitialize)numAllocRam).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxRam).EndInit();
            cmsArgument.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblServerJar;
        private Label lblDirectory;
        private Label lblTitle;
        private Label lblAllocRam;
        private Label lblMaxRam;
        private TextBox txtServerJar;
        private Button btnServerJar;
        private TextBox txtDirectory;
        private Button btnDirectory;
        private NumericUpDown numAllocRam;
        private NumericUpDown numMaxRam;
        private TextBox txtTitle;
        private ComboBox cbAllocRam;
        private ComboBox cbMaxRam;
        private Button btnCancel;
        private Button btnOk;
        private OpenFileDialog ofdServerJar;
        private FolderBrowserDialog fbdDirectory;
        private ListView lvJarArgument;
        private ListView lvJavaArgument;
        private ContextMenuStrip cmsArgument;
        private ToolStripMenuItem cmsArgumentAdd;
        private ToolStripMenuItem cmsArgumentEdit;
        private ToolStripMenuItem cmsArgumentDelete;
        private Label lblJarArgument;
        private Label lblJavaArgument;
        private ComboBox cbJava;
        private Label lblJava;
    }
}