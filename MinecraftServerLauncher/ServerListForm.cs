using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MinecraftServerLauncher
{
    public partial class ServerListForm : Form
    {
        private List<Server>? servers = null;
        private const string serverFile = "server.dat";
        private AddServerDialog _addServerDialog = new AddServerDialog();

        public ServerListForm()
        {
            InitializeComponent();
            loadServers();
        }

        private void loadServers()
        {
            if (File.Exists(serverFile))
                servers = Server.ReadFromFile(serverFile);
            else
                servers = new List<Server>();
            foreach (var server in servers)
                addItem(server);
        }

        private void addItem(Server server)
        {
            lvServerList.Items.Add(new ListViewItem($"{server.Title}\t({server.WorkingDirectory})"));
        }

        private void cmsServerList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsServerListOpen.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsServerListEdit.Enabled = lvServerList.SelectedItems.Count == 1;
            cmsServerListDelete.Enabled = lvServerList.SelectedItems.Count > 0;
        }

        private void cmsServerListOpen_Click(object sender, EventArgs e)
        {
            new ServerTab(lvServerList.SelectedIndices.Cast<int>().Select(t => servers[t]).Single(), tbcServer);
        }

        private void cmsServerListAdd_Click(object sender, EventArgs e)
        {
            _addServerDialog.Server = null;
            if (_addServerDialog.ShowDialog() == DialogResult.OK)
            {
                Server server = _addServerDialog.Server;
                servers.Add(server);
                addItem(server);
            }
        }

        private void cmsServerListEdit_Click(object sender, EventArgs e)
        {
            int index = lvServerList.SelectedIndices.Cast<int>().Single();
            _addServerDialog.Server = servers[index];
            if (_addServerDialog.ShowDialog() == DialogResult.OK)
            {
                Server server = _addServerDialog.Server;
                servers[index] = server;
                lvServerList.Items[index].Text = $"{server.Title}\t({server.WorkingDirectory})";
            }
        }

        private void cmsServerListDelete_Click(object sender, EventArgs e)
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
    }
}
