namespace MinecraftServerLauncher
{
    public partial class AddServerDialog : Form
    {
        #region types

        private class Item
        {
            public string? Text { get; set; }
            public string? Char { get; set; }
            public Decimal Value { get; set; }
        }

        #endregion

        #region constants

        private readonly Item[] ITEMS = {
            new() { Text = "MB", Char = "M", Value = 1 },
            new() { Text = "GB", Char = "G", Value = 1024 }
        };

        #endregion

        #region fields

        ListView? _selectedListView;

        #endregion

        #region properties

        public Server? Server { get; set; }

        #endregion

        #region constructors

        public AddServerDialog()
        {
            InitializeComponent();
            cbAllocRam.Items.AddRange(ITEMS);
            cbMaxRam.Items.AddRange(ITEMS);
            cbAllocRam.SelectedIndex = 0;
            cbMaxRam.SelectedIndex = 0;
            cbAllocRam.DisplayMember = "Text";
            cbMaxRam.DisplayMember = "Text";
            numAllocRam.Maximum = int.MaxValue;
            numMaxRam.Maximum = int.MaxValue;
        }

        #endregion

        #region methods

        private void AddServerDialog_Load(object sender, EventArgs e)
        {
            if (Server == null)
                return;
            var charLList = ITEMS.Select(x => x.Char).ToList();
            txtTitle.SetText(Server.Title);
            txtServerJar.SetText(Server.Path);
            txtDirectory.SetText(Server.WorkingDirectory);
            numAllocRam.Value = Decimal.Parse(Server.AllocatedMemory.Substring(0, Server.AllocatedMemory.Length - 1));
            cbAllocRam.SelectedIndex = charLList.IndexOf(Server.AllocatedMemory.Last().ToString());
            numMaxRam.Value = Decimal.Parse(Server.MaxMemory.Substring(0, Server.MaxMemory.Length - 1));
            cbMaxRam.SelectedIndex = charLList.IndexOf(Server.MaxMemory.Last().ToString());
            lvJavaArgument.Items.AddRange(Server.JavaArguments.Select(x => new ListViewItem(x)).ToArray());
            lvJarArgument.Items.AddRange(Server.JarArguments.Select(x => new ListViewItem(x)).ToArray());
        }

        #endregion

        #region event handlers

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Item? alloc = (Item?)cbAllocRam.SelectedItem;
            Item? max = (Item?)cbMaxRam.SelectedItem;

            if (!File.Exists(txtServerJar.Text) || Path.GetExtension(txtServerJar.Text) != ".jar")
                MessageBox.Show("Invalid JAR path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Directory.Exists(txtDirectory.Text))
                MessageBox.Show("Invalid working directory path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrEmpty(txtTitle.Text))
                MessageBox.Show("Title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numAllocRam.Value == 0)
                MessageBox.Show("Allocated Memory cannot be zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numMaxRam.Value == 0)
                MessageBox.Show("Maimum Memory cannot be zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numMaxRam.Value * max?.Value < numAllocRam.Value * alloc?.Value)
                MessageBox.Show("Maximum Memory cannot be less than Allocated Memory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Server = new Server
                {
                    Title = txtTitle.Text,
                    Path = txtServerJar.Text,
                    WorkingDirectory = txtDirectory.Text,
                    AllocatedMemory = numAllocRam.Text + alloc?.Char,
                    MaxMemory = numMaxRam.Text + max?.Char,
                    JavaArguments = lvJavaArgument.Items.Cast<ListViewItem>().Select(x => x.Text).Where(s => !string.IsNullOrEmpty(s)),
                    JarArguments = lvJarArgument.Items.Cast<ListViewItem>().Select(x => x.Text).Where(s => !string.IsNullOrEmpty(s))
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnServerJar_Click(object sender, EventArgs e)
        {
            if (ofdServerJar.ShowDialog() != DialogResult.OK)
                return;
            txtServerJar.SetText(ofdServerJar.FileName);
            if (string.IsNullOrEmpty(txtTitle.Text))
                txtTitle.SetText(Path.GetFileNameWithoutExtension(ofdServerJar.FileName));
            if (string.IsNullOrEmpty(txtDirectory.Text))
            {
                txtDirectory.SetText(Path.GetDirectoryName(ofdServerJar.FileName) ?? "");
                fbdDirectory.SelectedPath = txtDirectory.Text;
            }
        }

        private void BtnDirectory_Click(object sender, EventArgs e)
        {
            if (fbdDirectory.ShowDialog() != DialogResult.OK)
                return;
            txtDirectory.SetText(fbdDirectory.SelectedPath);
            if (string.IsNullOrEmpty(txtTitle.Text))
                ofdServerJar.InitialDirectory = fbdDirectory.SelectedPath;
        }

        private void CmsArgument_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _selectedListView = (sender as ContextMenuStrip)?.SourceControl as ListView;
            cmsArgumentEdit.Enabled = _selectedListView?.SelectedItems?.Count == 1;
            cmsArgumentDelete.Enabled = _selectedListView?.SelectedItems?.Count > 0;
        }

        private void CmsArgumentAdd_Click(object sender, EventArgs e)
        {
            var item = _selectedListView?.Items?.Add(string.Empty);
            item?.BeginEdit();
        }

        private void CmsArgumentEdit_Click(object sender, EventArgs e)
        {
            _selectedListView?.SelectedItems?.Cast<ListViewItem>()?.Single()?.BeginEdit();
        }

        private void CmsArgumentDelete_Click(object sender, EventArgs e)
        {
            _selectedListView?.SelectedItems?.Cast<ListViewItem>()?.ToList()?.ForEach(x => x.Remove());
        }

        #endregion
    }
}
