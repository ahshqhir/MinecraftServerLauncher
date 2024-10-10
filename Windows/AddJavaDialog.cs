namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    public partial class AddJavaDialog : Form
    {
        #region properties

        public Java? Java { get; set; }

        #endregion

        #region constructors

        public AddJavaDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region event handlers

        private void AddJavaDialog_Load(object sender, EventArgs e)
        {
            if (Java == null)
                Text = "Add new java";
            else
                Text = "Edit java";
            txtJava.SetText(Java?.Path);
            txtTitle.SetText(Java?.Title);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtJava.Text) || Path.GetFileName(txtJava.Text) != "java.exe")
                MessageBox.Show("Invalid JAR path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrEmpty(txtTitle.Text))
                MessageBox.Show("Title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTitle.Text == "(Default)")
                MessageBox.Show("Title cannot be (Default)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ServerListForm.Javas.Select(j => j.Title).Where(t => t == txtTitle.Text).Count() > 0)
                MessageBox.Show("Title cannot be duplicated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Java = new Java
                {
                    Title = txtTitle.Text,
                    Path = txtJava.Text
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnJava_Click(object sender, EventArgs e)
        {
            if (ofdJava.ShowDialog() != DialogResult.OK)
                return;
            txtJava.SetText(ofdJava.FileName);
            if (string.IsNullOrEmpty(txtTitle.Text))
                txtTitle.SetText(new FileInfo(ofdJava.FileName).Directory?.Parent?.Name);
        }

        #endregion
    }
}
