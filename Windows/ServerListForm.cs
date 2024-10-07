using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AHSHQHIR.MinecraftServerLauncher.Windows
{
    public partial class ServerListForm : Form
    {
        #region constants

        private const string serverFile = "server.dat";

        #endregion

        #region fields

        private List<Server> servers;
        private readonly AddServerDialog _addServerDialog = new AddServerDialog();

        #endregion

        #region constructors

        public ServerListForm()
        {
            InitializeComponent();

            servers = new List<Server>();
            LoadServers();
        }

        #endregion

        #region methods

        private void LoadServers()
        {
            if (File.Exists(serverFile))
                servers = Server.ReadFromFile(serverFile);
            foreach (var server in servers)
                AddItem(server);
        }

        private void AddItem(Server server)
        {
            lvServerList.Items.Add(new ListViewItem($"{server.Title}\t({server.WorkingDirectory})"));
        }

        #endregion

        #region event handlers

        private void CmsServerList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsServerListOpen.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsServerListEdit.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsServerListDelete.Enabled = lvServerList.SelectedItems.Count > 0;
        }

        private void CmsServerListOpen_Click(object sender, EventArgs e)
        {
            new ServerTab(lvServerList.SelectedIndices.Cast<int>().Select(t => servers[t]).Single(), tbcServer);
        }

        private void CmsServerListAdd_Click(object sender, EventArgs e)
        {
            _addServerDialog.Server = null;
            if (_addServerDialog.ShowDialog() == DialogResult.OK)
            {
                Server? server = _addServerDialog.Server;
                if (server == null)
                    return;
                servers.Add(server);
                AddItem(server);
            }
        }

        private void CmsServerListEdit_Click(object sender, EventArgs e)
        {
            int index = lvServerList.SelectedIndices.Cast<int>().Single();
            _addServerDialog.Server = servers[index];
            if (_addServerDialog.ShowDialog() == DialogResult.OK)
            {
                Server? server = _addServerDialog.Server;
                if (server == null)
                    return;
                servers[index] = server;
                lvServerList.Items[index].Text = $"{server.Title}\t({server.WorkingDirectory})";
            }
        }

        private void CmsServerListDelete_Click(object sender, EventArgs e)
        {
            lvServerList.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList().ForEach(i =>
            {
                servers.RemoveAt(i);
                lvServerList.Items.RemoveAt(i);
            });
        }

        private void ServerListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var tab in tbcServer.TabPages)
                if (tab is ServerTab serverTab)
                    serverTab.Close();
            Server.WriteToFile(serverFile, servers);
        }

        #endregion
    }
}
