using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AHSHQHIR.MinecraftServerLauncher.Windows
{
    public class ServerTab : TabPage
    {
        #region types

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        #endregion

        #region externs

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetCursorInfo(out CURSORINFO pci);

        #endregion

        #region constants

        // Window Styles
        private const int GWL_STYLE = -16;
        private const int WS_BORDER = 0x00800000;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_SIZEBOX = 0x00040000;

        // Messages
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;
        private const uint WM_RBUTTONDOWN = 0x0204;
        private const uint WM_RBUTTONUP = 0x0205;

        // Cursor flags
        private const int CURSOR_SHOWING = 0x00000001;

        #endregion

        #region fields

        private readonly Server _server;
        private readonly Process _serverProcess;
        private IntPtr _serverMainWin = IntPtr.Zero;
        private readonly TabControl _container;
        private nint _handle;
        private bool _closed = false;

        #endregion

        #region constructors

        public ServerTab(Server? server, TabControl container) : base(server?.Title ?? "")
        {
            if (server == null)
                throw new ArgumentNullException(nameof(server));
            _container = container;
            _container.TabPages.Add(this);
            _server = server;
            _serverProcess = OpenServer();
            _handle = this.Handle;
            Thread thread = new Thread(Calibrate);
            thread.Start();
            this.Resize += Tab_Resized;
            this.MouseMove += Tab_MouseMove;
            this.MouseDown += Tab_MouseDown;
            this.MouseUp += Tab_MouseUp;
            this.KeyDown += Tab_KeyDown;
            this.KeyUp += Tab_KeyUp;
            _container.SelectedTab = this;
        }

        #endregion

        #region methods

        private Process OpenServer()
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = _server.GetArguments(),
                    WorkingDirectory = _server.WorkingDirectory,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            proc.ErrorDataReceived += Srver_ErrorReceived;
            proc.Start();
            proc.BeginErrorReadLine();
            return proc;
        }

        private void Calibrate()
        {
            while (_serverMainWin == IntPtr.Zero)
            {
                if (_serverProcess.HasExited)
                    return;
                System.Threading.Thread.Sleep(100);
                _serverProcess.Refresh();
                _serverMainWin = _serverProcess.MainWindowHandle;
            }

            int style = GetWindowLong(_serverMainWin, GWL_STYLE);
            SetWindowLong(_serverMainWin, GWL_STYLE, style & ~WS_BORDER & ~WS_CAPTION & ~WS_SIZEBOX);
            SetParent(_serverMainWin, _handle);
            MoveWindow(_serverMainWin, 0, 0, 1085, 646, true);
            _serverProcess.Refresh();

            while (!_serverProcess.HasExited)
            {
                Invoke(new Action(Focus));
                System.Threading.Thread.Sleep(100);
            }

            if (!_closed)
                Invoke(new Action(Close));
        }

        public new void Focus()
        {
            if (_container.SelectedTab == this)
                base.Focus();
        }

        public void Close()
        {
            if (_closed)
                return;
            _closed = true;
            _container.TabPages.Remove(this);
            if (!_serverProcess.HasExited)
                _serverProcess.Kill();
            this.Dispose();
        }

        private static IntPtr MakeLParam(int low, int high)
        {
            return (IntPtr)((high << 16) | (low & 0xFFFF));
        }

        private void UpdateCursorFromProcess()
        {
            CURSORINFO cursorInfo = new CURSORINFO();
            cursorInfo.cbSize = Marshal.SizeOf(cursorInfo);

            if (GetCursorInfo(out cursorInfo) && cursorInfo.flags == CURSOR_SHOWING)
            {
                Cursor = new Cursor(cursorInfo.hCursor);
            }
        }

        #endregion

        #region event handlers

        private void Srver_ErrorReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                MessageBox.Show(e.Data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Tab_Resized(object? sender, EventArgs e)
        {
            if (_serverMainWin != IntPtr.Zero)
            {
                MoveWindow(_serverProcess.MainWindowHandle, 0, 0, this.ClientSize.Width, this.ClientSize.Height, true);
                _serverProcess.Refresh();
            }
        }

        private void Tab_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_serverMainWin != IntPtr.Zero)
            {
                PostMessage(_serverMainWin, WM_MOUSEMOVE, IntPtr.Zero, MakeLParam(e.X, e.Y));
                UpdateCursorFromProcess();
            }
        }

        private void Tab_MouseDown(object? sender, MouseEventArgs e)
        {
            if (_serverMainWin != IntPtr.Zero)
            {
                if (e.Button == MouseButtons.Left)
                    PostMessage(_serverMainWin, WM_LBUTTONDOWN, IntPtr.Zero, MakeLParam(e.X, e.Y));
                else if (e.Button == MouseButtons.Right)
                    PostMessage(_serverMainWin, WM_RBUTTONDOWN, IntPtr.Zero, MakeLParam(e.X, e.Y));
                UpdateCursorFromProcess();
            }
        }

        private void Tab_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_serverMainWin != IntPtr.Zero)
            {
                if (e.Button == MouseButtons.Left)
                    PostMessage(_serverMainWin, WM_LBUTTONUP, IntPtr.Zero, MakeLParam(e.X, e.Y));
                else if (e.Button == MouseButtons.Right)
                    PostMessage(_serverMainWin, WM_RBUTTONUP, IntPtr.Zero, MakeLParam(e.X, e.Y));
                UpdateCursorFromProcess();
            }
        }

        private void Tab_KeyDown(object? sender, KeyEventArgs e)
        {
            if (_serverMainWin != IntPtr.Zero)
                PostMessage(_serverMainWin, WM_KEYDOWN, (IntPtr)e.KeyCode, IntPtr.Zero);
        }

        private void Tab_KeyUp(object? sender, KeyEventArgs e)
        {
            if (_serverMainWin != IntPtr.Zero)
                PostMessage(_serverMainWin, WM_KEYUP, (IntPtr)e.KeyCode, IntPtr.Zero);
        }

        #endregion
    }
}
