namespace AHSHQHIR.MinecraftServerLauncher.Windows
{
    partial class ServerListForm
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
            components = new System.ComponentModel.Container();
            tbcServer = new TabControl();
            tbpServerList = new TabPage();
            lvServerList = new ListView();
            cmsServerList = new ContextMenuStrip(components);
            cmsServerListOpen = new ToolStripMenuItem();
            cmsServerListAdd = new ToolStripMenuItem();
            cmsServerListEdit = new ToolStripMenuItem();
            cmsServerListDelete = new ToolStripMenuItem();
            tbcServer.SuspendLayout();
            tbpServerList.SuspendLayout();
            cmsServerList.SuspendLayout();
            SuspendLayout();
            // 
            // tbcServer
            // 
            tbcServer.Controls.Add(tbpServerList);
            tbcServer.Location = new Point(12, 12);
            tbcServer.Name = "tbcServer";
            tbcServer.SelectedIndex = 0;
            tbcServer.Size = new Size(1093, 679);
            tbcServer.TabIndex = 0;
            // 
            // tbpServerList
            // 
            tbpServerList.Controls.Add(lvServerList);
            tbpServerList.Location = new Point(4, 29);
            tbpServerList.Name = "tbpServerList";
            tbpServerList.Padding = new Padding(3);
            tbpServerList.Size = new Size(1085, 646);
            tbpServerList.TabIndex = 0;
            tbpServerList.Text = "Server List";
            tbpServerList.UseVisualStyleBackColor = true;
            // 
            // lvServerList
            // 
            lvServerList.AllowDrop = true;
            lvServerList.ContextMenuStrip = cmsServerList;
            lvServerList.HeaderStyle = ColumnHeaderStyle.None;
            lvServerList.LabelEdit = true;
            lvServerList.Location = new Point(6, 6);
            lvServerList.Name = "lvServerList";
            lvServerList.Size = new Size(1073, 634);
            lvServerList.TabIndex = 10;
            lvServerList.UseCompatibleStateImageBehavior = false;
            lvServerList.View = View.List;
            // 
            // cmsServerList
            // 
            cmsServerList.ImageScalingSize = new Size(20, 20);
            cmsServerList.Items.AddRange(new ToolStripItem[] { cmsServerListOpen, cmsServerListAdd, cmsServerListEdit, cmsServerListDelete });
            cmsServerList.Name = "cmsServerList";
            cmsServerList.Size = new Size(123, 100);
            cmsServerList.Opening += CmsServerList_Opening;
            // 
            // cmsServerListOpen
            // 
            cmsServerListOpen.Name = "cmsServerListOpen";
            cmsServerListOpen.Size = new Size(122, 24);
            cmsServerListOpen.Text = "Open";
            cmsServerListOpen.Click += CmsServerListOpen_Click;
            // 
            // cmsServerListAdd
            // 
            cmsServerListAdd.Name = "cmsServerListAdd";
            cmsServerListAdd.Size = new Size(122, 24);
            cmsServerListAdd.Text = "Add";
            cmsServerListAdd.Click += CmsServerListAdd_Click;
            // 
            // cmsServerListEdit
            // 
            cmsServerListEdit.Name = "cmsServerListEdit";
            cmsServerListEdit.Size = new Size(122, 24);
            cmsServerListEdit.Text = "Edit";
            cmsServerListEdit.Click += CmsServerListEdit_Click;
            // 
            // cmsServerListDelete
            // 
            cmsServerListDelete.Name = "cmsServerListDelete";
            cmsServerListDelete.Size = new Size(122, 24);
            cmsServerListDelete.Text = "Delete";
            cmsServerListDelete.Click += CmsServerListDelete_Click;
            // 
            // ServerListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 703);
            Controls.Add(tbcServer);
            Name = "ServerListForm";
            Text = "Server List";
            FormClosing += ServerListForm_FormClosing;
            tbcServer.ResumeLayout(false);
            tbpServerList.ResumeLayout(false);
            cmsServerList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcServer;
        private TabPage tbpServerList;
        private ListView lvServerList;
        private ContextMenuStrip cmsServerList;
        private ToolStripMenuItem cmsServerListOpen;
        private ToolStripMenuItem cmsServerListAdd;
        private ToolStripMenuItem cmsServerListEdit;
        private ToolStripMenuItem cmsServerListDelete;
    }
}
