using steamvr_manager;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Transactions;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace steamvr_manager
{
    public partial class Form1 : Form
    {

        Changelog ChangelogForm = new Changelog();
        Manager Manager = new Manager();
        About AboutForm = new About();

        private bool Is64Bit = Environment.Is64BitOperatingSystem; // Placeholder for now

        public Form1()
        {
            Settings.Initiate();
            InitializeComponent();

            // Update the form to reflect changes based on the current settings

            if (!Manager.ValidatePath(Manager.steamvr_path))
            {
                steamvr_directory.Text = "SteamVR not found!";
            }
            else
            {
                steamvr_directory.Text = Manager.steamvr_path;
                steamvr_enabled.Checked = Manager.IsEnabled();
                steamvr_toggle.Text = Manager.IsEnabled() ? "Disable SteamVR" : "Enable SteamVR";
            }

            this.Shown += new EventHandler(FormReady!);
        }

        // The function that will run when the Form is ready, and is shown.
        private void FormReady(object sender, EventArgs e)
        {
            // Check to make sure the user's path they set is still the SteamVR directory
            string steamvr_path = Manager.steamvr_path;
            if (!Manager.ValidatePath(Manager.steamvr_path))
            {
                var (Success, Path) = Manager.AskForPath(false);
                if (Success) { steamvr_path = Path; }
            }

            // Separate if statement just in case the user chooses not to tell the program where SteamVR is located
            if (Manager.ValidatePath(Manager.steamvr_path)) {
                steamvr_directory.Text = steamvr_path;
                steamvr_enabled.Checked = Manager.IsEnabled();
                steamvr_toggle.Text = Manager.IsEnabled() ? "Disable SteamVR" : "Enable SteamVR";
            }
        }

        // Check if the path is pointing to the SteamVR Directory
        private bool ValidatePath(String path)
        {
            if (path == null) { return false; }
            if (!Directory.Exists(path)) { return false; }
            if (File.Exists(path + "\\bin\\win64\\vrserver.exe") || File.Exists(path + "\\bin\\win64\\vrserver.exe.disabled")) { return true; }
            return false;
        }

        private void select_directory_Click(object sender, EventArgs e)
        {
            // Prompts the user once for their SteamVR directory, and update accordingly
            var (Success, Path) = Manager.AskForPath(true);
            if (Success)
            {
                steamvr_enabled.Checked = Manager.IsEnabled();
                steamvr_toggle.Text = Manager.IsEnabled() ? "Disable SteamVR" : "Enable SteamVR";
            }
        }

        // Close the application, not sure what to put in that menu for now
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
            Manager.SetEnabled(!Manager.IsEnabled());
            steamvr_enabled.Checked = Manager.IsEnabled();
            steamvr_toggle.Text = Manager.IsEnabled() ? "Disable SteamVR" : "Enable SteamVR";
        }

        private void check_for_updates_Click(object sender, EventArgs e)
        {
            ChangelogForm.ShowDialog();
        }
    }
}
