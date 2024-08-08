using steamvr_manager;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Xml;

namespace steamvr_manager
{
    public partial class Form1 : Form
    {

        private bool Is64Bit = Environment.Is64BitOperatingSystem; // Placeholder for now
        private static String RootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "steamvr_manager");
        private static String ConfigFile = Path.Combine(RootFolder, "user.config");

        About AboutForm = new About();
        private String steamvr_path;

        public Form1()
        {
            // Check to see if our folder in AppData exists
            if (!Directory.Exists(RootFolder)) { Directory.CreateDirectory(RootFolder); }

            // Check if we have our user.config file, if not create a new one
            if (!File.Exists(ConfigFile))
            {
                XmlDocument newConfig = new XmlDocument();
                XmlElement Root = newConfig.CreateElement("Settings");
                newConfig.AppendChild(Root);

                XmlElement steamvr_path = newConfig.CreateElement("steamvr_path");
                steamvr_path.InnerText = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\SteamVR\\";
                Root.AppendChild(steamvr_path);

                newConfig.Save(ConfigFile);
                System.Windows.Forms.MessageBox.Show("Created new config file");
            }

            // Load our settings
            XmlDocument Config = new XmlDocument();
            Config.Load(ConfigFile);

            var settings_steamvr_path = Config.SelectSingleNode("/Settings/steamvr_path");
            if (settings_steamvr_path != null) {
                steamvr_path = Config.SelectSingleNode("/Settings/steamvr_path").InnerText;
            } else {
                steamvr_path = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\SteamVR";
            }

            // Update the form to reflect changes based on the current settings
            if (!ValidatePath(steamvr_path))
            {
                steamvr_directory.Text = "SteamVR not found!";
            }
            else
            {
                steamvr_directory.Text = steamvr_path;
                if (GetEnabledStatus()) { steamvr_toggle.Text = "Disable SteamVR"; }
            }

            InitializeComponent();
            this.Shown += new EventHandler(FormReady);
        }

        // The function that will run when the Form is ready, and is shown.
        private void FormReady(object sender, EventArgs e)
        {
            // Check to make sure the user's path they set is still the SteamVR directory
            if (!ValidatePath(steamvr_path))
            {
                // Failed to find specific files usually in the SteamVR Directory, so we'll ask where it's at
                System.Windows.Forms.MessageBox.Show("Please select where your SteamVR folder is located");
                FolderBrowserDialog FolderSelect = new FolderBrowserDialog();
                DialogResult Result = DialogResult.None;

                // Looping function to ask for the correct directory until the user cancels the request
                while (!ValidatePath(steamvr_path))
                {
                    Result = FolderSelect.ShowDialog();
                    if (Result == DialogResult.OK && ValidatePath(FolderSelect.SelectedPath))
                    {
                        steamvr_path = FolderSelect.SelectedPath;
                        steamvr_directory.Text = FolderSelect.SelectedPath;

                        var newConfig = new XmlDocument();
                        newConfig.Load(ConfigFile);
                        XmlNode settings_steamvr_path = newConfig.SelectSingleNode("/Settings/steamvr_path");
                        settings_steamvr_path.InnerText = FolderSelect.SelectedPath;
                        newConfig.Save(ConfigFile);
                        break;
                    }
                    else if (Result == DialogResult.Cancel)
                    {
                        break;
                    }
                    System.Windows.Forms.MessageBox.Show("\"" + FolderSelect.SelectedPath + "\" is not a valid SteamVR directory!");
                }
            }
            steamvr_enabled.Checked = GetEnabledStatus();
        }

        // Check if the path is pointing to the SteamVR Directory
        private bool ValidatePath(String path)
        {
            if (path == null) { return false; }
            if (!Directory.Exists(path)) { return false; }
            if (File.Exists(path + "\\bin\\win64\\vrserver.exe") || File.Exists(path + "\\bin\\win64\\vrserver.exe.disabled")) { return true; }
            return false;
        }

        // Check if the program has found the vrserver.exe, usually meaning it's enabled
        private bool GetEnabledStatus()
        {
            if (!ValidatePath(steamvr_path)) { return false; }
            String Win64 = steamvr_path + "\\bin\\win64";
            if (File.Exists(Win64 + "\\vrserver.exe")) { return true; }
            return false;
        }

        private void select_directory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog UserBrowserDialog = new FolderBrowserDialog();
            DialogResult result = UserBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && ValidatePath(UserBrowserDialog.SelectedPath))
            {
                steamvr_path = UserBrowserDialog.SelectedPath;
                steamvr_directory.Text = steamvr_path;
            } else
            {
                System.Windows.Forms.MessageBox.Show("\"" + UserBrowserDialog.SelectedPath + "\" is not a valid SteamVR directory!");
            }
        }

        // Close the application
        private void exit_menu_item_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Opens the about window, displaying information about the program
        private void about_menu_item_Click(object sender, EventArgs e)
        {
            AboutForm.ShowDialog();
        }

        // Changes the state if SteamVR is enabled or not
        private void steamvr_toggle_Click(object sender, EventArgs e)
        {
            String Win64 = steamvr_path + "\\bin\\win64\\";
            if (GetEnabledStatus())
            {
                if (File.Exists(Win64 + "\\vrserver.exe.disabled")) { File.Delete(Win64 + "\\vrserver.exe.disabled"); }
                File.Move(Win64 + "\\vrserver.exe", Win64 + "\\vrserver.exe.disabled");
                steamvr_enabled.Checked = GetEnabledStatus();
                if (!steamvr_enabled.Checked) { steamvr_toggle.Text = "Enable SteamVR"; }
            }
            else
            {
                if (File.Exists(Win64 + "\\vrserver.exe.disabled") && File.Exists(Win64 + "\\vrserver.exe"))
                {
                    File.Delete(Win64 + "\\vrserver.exe.disabled");
                }
                else if (File.Exists(Win64 + "\\vrserver.exe.disabled"))
                {
                    File.Move(Win64 + "\\vrserver.exe.disabled", Win64 + "\\vrserver.exe");
                }
                steamvr_enabled.Checked = GetEnabledStatus();
                if (steamvr_enabled.Checked) { steamvr_toggle.Text = "Disable SteamVR"; }
            }
        }
    }
}
