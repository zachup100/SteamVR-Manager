using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace steamvr_controller
{
    public partial class Form1 : Form
    {

        // Figure out how to stop SteamVR from running when OS is 32-bit.
        About AboutForm = new About();
        private bool Is64Bit = Environment.Is64BitOperatingSystem;
        private static FolderBrowserDialog UserBrowserDialog = new FolderBrowserDialog();
        private String steamvr_path = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\SteamVR\\";
        //System.Windows.Forms.MessageBox.Show("");

        public Form1()
        {
            InitializeComponent();
            if (!ValidatePath(steamvr_path)) {
                steamvr_directory.Text = "SteamVR not found!";
            } else {
                steamvr_directory.Text = steamvr_path;
                if (GetEnabledStatus()) { steamvr_toggle.Text = "Disable SteamVR"; }
            }
            this.Shown += new EventHandler(FormReady);
        }

        private void FormReady(object sender, EventArgs e)
        {
            if (!ValidatePath(steamvr_path))
            {
                System.Windows.Forms.MessageBox.Show("Please select where your SteamVR folder is located");
                FolderBrowserDialog FolderSelect = new FolderBrowserDialog();
                DialogResult Result = DialogResult.None;
                while (!ValidatePath(steamvr_path))
                {
                    Result = FolderSelect.ShowDialog();
                    if (Result == DialogResult.OK && ValidatePath(FolderSelect.SelectedPath))
                    {
                        steamvr_path = FolderSelect.SelectedPath;
                    }
                    else if (Result == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
            steamvr_enabled.Checked = GetEnabledStatus();
        }

        private bool ValidatePath(String path)
        {
            if (path == null) { return false; }
            if (!Directory.Exists(path)) { return false; }
            if (File.Exists(path + "\\bin\\win64\\vrserver.exe") || File.Exists(path + "\\bin\\win64\\vrserver.exe.disabled")) { return true; }
            return false;
        }

        private bool GetEnabledStatus()
        {
            if (!ValidatePath(steamvr_path)) { return false; }
            String Win64 = steamvr_path + "\\bin\\win64";
            if (File.Exists(Win64 + "\\vrserver.exe")) { return true; }
            return false;
        }

        private void select_directory_Click(object sender, EventArgs e)
        {
            DialogResult result = UserBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                steamvr_path = UserBrowserDialog.SelectedPath;
                steamvr_directory.Text = steamvr_path;
            }
        }

        private void exit_menu_item_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void about_menu_item_Click(object sender, EventArgs e)
        {
            AboutForm.ShowDialog();
        }

        private void steamvr_toggle_Click(object sender, EventArgs e)
        {
            String Win64 = steamvr_path + "\\bin\\win64\\";
            if (GetEnabledStatus()) {
                if (File.Exists(Win64 + "\\vrserver.exe.disabled")) { File.Delete(Win64 + "\\vrserver.exe.disabled"); }
                File.Move(Win64 + "\\vrserver.exe", Win64 + "\\vrserver.exe.disabled");
                steamvr_enabled.Checked = GetEnabledStatus();
                if (!steamvr_enabled.Checked) { steamvr_toggle.Text = "Enable SteamVR"; }
            } else {
                if (File.Exists(Win64 + "\\vrserver.exe.disabled") && File.Exists(Win64 + "\\vrserver.exe")) {
                    File.Delete(Win64 + "\\vrserver.exe.disabled");
                } else if (File.Exists(Win64 + "\\vrserver.exe.disabled")) {
                    File.Move(Win64 + "\\vrserver.exe.disabled", Win64 + "\\vrserver.exe");
                }
                steamvr_enabled.Checked = GetEnabledStatus();
                if (steamvr_enabled.Checked) { steamvr_toggle.Text = "Disable SteamVR"; }
            }
        }
    }
}
