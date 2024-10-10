namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    public partial class ServerListForm : Form
    {
        #region constants

        private const string savePath = "data.dat";

        #endregion

        #region fields

        private readonly AddServerDialog _addServerDialog = new();
        private readonly AddJavaDialog _addJavaDialog = new();
        private readonly FileInfo _file = new(savePath);

        #endregion

        #region properties

        public static List<Server> Servers { get; set; } = [];
        public static List<Java> Javas { get; set; } = [];

        #endregion

        #region constructors

        public ServerListForm()
        {
            InitializeComponent();
            LoadFile();
        }

        #endregion

        #region methods

        private void LoadFile()
        {
            if (_file.Exists)
            {
                FileStream? stream = null;
                StreamReader? reader = null;
                try
                {
                    stream = _file.OpenRead();
                    reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {
                        switch (reader.ReadLine())
                        {
                            case "[Javas]":
                                Javas = Java.ReadFromFile(reader);
                                _addServerDialog.Javas = Javas;
                                break;
                            case "[Servers]":
                                Servers = Server.ReadFromFile(reader, Javas);
                                break;
                            default:
                                throw new WrongFileFormatException();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                        reader.Dispose();
                    }
                    if (stream != null)
                    {
                        stream.Close();
                        stream.Dispose();
                    }
                }
            }
            foreach (var server in Servers)
                AddItem(server);
            foreach (var java in Javas)
                AddItem(java);
        }

        private void AddItem(Server server)
        {
            lvServerList.Items.Add(new ListViewItem($"{server.Title}"));
        }

        private void AddItem(Java java)
        {
            lvJavaList.Items.Add(new ListViewItem($"{java.Title}"));
        }

        #endregion

        #region event handlers

        private void CmsServerList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsServerListOpen.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsServerListEdit.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsServerListDelete.Enabled = lvServerList.SelectedItems.Count > 0;
        }

        private void CmsJavaList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsJavaListEdit.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsJavaListDelete.Enabled = lvServerList.SelectedItems.Count > 0;
        }

        private void CmsServerListOpen_Click(object sender, EventArgs e)
        {
            _ = new ServerTab(lvServerList.SelectedIndices.Cast<int>().Select(t => Servers[t]).Single(), tbcServer);
        }

        private void CmsServerListAdd_Click(object sender, EventArgs e)
        {
            _addServerDialog.Server = null;
            if (_addServerDialog.ShowDialog() == DialogResult.OK)
            {
                Server? server = _addServerDialog.Server;
                if (server == null)
                    return;
                Servers.Add(server);
                AddItem(server);
            }
        }

        private void CmsJavaListAdd_Click(object sender, EventArgs e)
        {
            _addJavaDialog.Java = null;
            if (_addJavaDialog.ShowDialog() == DialogResult.OK)
            {
                Java? java = _addJavaDialog.Java;
                if (java == null)
                    return;
                Javas.Add(java);
                AddItem(java);
            }
        }

        private void CmsServerListEdit_Click(object sender, EventArgs e)
        {
            int index = lvServerList.SelectedIndices.Cast<int>().Single();
            _addServerDialog.Server = Servers[index];
            if (_addServerDialog.ShowDialog() == DialogResult.OK)
            {
                Server? server = _addServerDialog.Server;
                if (server == null)
                    return;
                Servers[index] = server;
                lvServerList.Items[index].Text = $"{server.Title}";
            }
        }

        private void CmsJavarListEdit_Click(object sender, EventArgs e)
        {
            int index = lvJavaList.SelectedIndices.Cast<int>().Single();
            _addJavaDialog.Java = Javas[index];
            if (_addJavaDialog.ShowDialog() == DialogResult.OK)
            {
                Java? java = _addJavaDialog.Java;
                if (java == null)
                    return;
                Javas[index] = java;
                lvJavaList.Items[index].Text = $"{java.Title}";
            }
        }

        private void CmsServerListDelete_Click(object sender, EventArgs e)
        {
            lvServerList.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList().ForEach(i =>
            {
                Servers.RemoveAt(i);
                lvServerList.Items.RemoveAt(i);
            });
        }

        private void CmsJavaListDelete_Click(object sender, EventArgs e)
        {
            lvJavaList.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList().ForEach(i =>
            {
                Javas.RemoveAt(i);
                lvJavaList.Items.RemoveAt(i);
            });
        }

        private void ServerListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var tab in tbcServer.TabPages)
                if (tab is ServerTab serverTab)
                    serverTab.Close();
            FileStream? stream = null;
            StreamWriter? writer = null;
            try
            {
                if (_file.Exists)
                    stream = _file.Open(FileMode.Truncate);
                else
                    stream = _file.Create();
                writer = new StreamWriter(stream);
                Java.WriteToFile(writer, Javas);
                Server.WriteToFile(writer, Servers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        private void TbcServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnKill.Enabled = btnKill.Visible = tbcServer.SelectedTab is ServerTab;
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (tbcServer.SelectedTab is ServerTab serverTab)
                serverTab.Close();
        }

        #endregion
    }
}
