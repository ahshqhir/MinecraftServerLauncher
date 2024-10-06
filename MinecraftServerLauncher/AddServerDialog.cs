namespace MinecraftServerLauncher
{
    public partial class AddServerDialog : Form
    {
        private class Item
        {
            public string Text { get; set; }
            public string Char { get; set; }
            public Decimal Value { get; set; }
        }

        Item[] _ITEMS = {
            new Item { Text = "MB", Char = "M", Value = 1 },
            new Item { Text = "GB", Char = "G", Value = 1024 }
        };

        public AddServerDialog()
        {
            InitializeComponent();
            cbAllocRam.Items.AddRange(_ITEMS);
            cbMaxRam.Items.AddRange(_ITEMS);
            cbAllocRam.SelectedIndex = 0;
            cbMaxRam.SelectedIndex = 0;
            cbAllocRam.DisplayMember = "Text";
            cbMaxRam.DisplayMember = "Text";
            numAllocRam.Maximum = int.MaxValue;
            numMaxRam.Maximum = int.MaxValue;
        }

        private void AddServerDialog_Load(object sender, EventArgs e)
        {
            if (Server == null)
                return;
            var charLList = _ITEMS.Select(x => x.Char).ToList();
            txtTitle.setText(Server.Title);
            txtServerJar.setText(Server.Path);
            txtDirectory.setText(Server.WorkingDirectory);
            numAllocRam.Value = Decimal.Parse(Server.AllocatedMemory.Substring(0, Server.AllocatedMemory.Length - 1));
            cbAllocRam.SelectedIndex = charLList.IndexOf(Server.AllocatedMemory.Last().ToString());
            numMaxRam.Value = Decimal.Parse(Server.MaxMemory.Substring(0, Server.MaxMemory.Length - 1));
            cbMaxRam.SelectedIndex = charLList.IndexOf(Server.MaxMemory.Last().ToString());
            lvJavaArgument.Items.AddRange(Server.JavaArguments.Select(x => new ListViewItem(x)).ToArray());
            lvJarArgument.Items.AddRange(Server.JarArguments.Select(x => new ListViewItem(x)).ToArray());
        }

        public Server? Server { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Item alloc = (Item)cbAllocRam.SelectedItem;
            Item max = (Item)cbMaxRam.SelectedItem;
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
            else if (numMaxRam.Value * max.Value < numAllocRam.Value * alloc.Value)
                MessageBox.Show("Maximum Memory cannot be less than Allocated Memory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Server = new Server
                {
                    Title = txtTitle.Text,
                    Path = txtServerJar.Text,
                    WorkingDirectory = txtDirectory.Text,
                    AllocatedMemory = numAllocRam.Text + alloc.Char,
                    MaxMemory = numMaxRam.Text + max.Char,
                    JavaArguments = lvJavaArgument.Items.Cast<ListViewItem>().Select(x => x.Text).Where(s => !string.IsNullOrEmpty(s)),
                    JarArguments = lvJarArgument.Items.Cast<ListViewItem>().Select(x => x.Text).Where(s => !string.IsNullOrEmpty(s))
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnServerJar_Click(object sender, EventArgs e)
        {
            if (ofdServerJar.ShowDialog() != DialogResult.OK)
                return;
            txtServerJar.setText(ofdServerJar.FileName);
            if (string.IsNullOrEmpty(txtTitle.Text))
                txtTitle.setText(Path.GetFileNameWithoutExtension(ofdServerJar.FileName));
            if (string.IsNullOrEmpty(txtDirectory.Text))
            {
                txtDirectory.setText(Path.GetDirectoryName(ofdServerJar.FileName));
                fbdDirectory.SelectedPath = txtDirectory.Text;
            }
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (fbdDirectory.ShowDialog() != DialogResult.OK)
                return;
            txtDirectory.setText(fbdDirectory.SelectedPath);
            if (string.IsNullOrEmpty(txtTitle.Text))
                ofdServerJar.InitialDirectory = fbdDirectory.SelectedPath;
        }

        ListView? _selectedListView;

        private void cmsArgument_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _selectedListView = (sender as ContextMenuStrip)?.SourceControl as ListView;
            cmsArgumentEdit.Enabled = _selectedListView?.SelectedItems?.Count == 1;
            cmsArgumentDelete.Enabled = _selectedListView?.SelectedItems?.Count > 0;
        }

        private void cmsArgumentAdd_Click(object sender, EventArgs e)
        {
            var item = _selectedListView?.Items?.Add(string.Empty);
            item?.BeginEdit();
        }

        private void cmsArgumentEdit_Click(object sender, EventArgs e)
        {
            _selectedListView?.SelectedItems?.Cast<ListViewItem>()?.Single()?.BeginEdit();
        }

        private void cmsArgumentDelete_Click(object sender, EventArgs e)
        {
            _selectedListView?.SelectedItems?.Cast<ListViewItem>()?.ToList()?.ForEach(x => x.Remove());
        }
    }
}
