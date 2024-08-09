using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace steamvr_manager
{
    public partial class Changelog : Form
    {

        // 0 Latest
        // 1 Release
        // 2 Nightly

        private static System.Timers.Timer? CooldownTimer;
        private static bool CooldownActive = false;
        private static int Cooldown = 2000;

        #pragma warning disable CS0162 // Disable unreachable code warning, since it'll be reachable when changing VersionInfo.Version
        public Changelog()
        {
            InitializeComponent();
            current_version.Text = "Current Version: " + VersionInfo.Version;
            current_build.Text = "Current Build: " + VersionInfo.Build;

            if (VersionInfo.Build == "release") { 
                get_build_selection.SelectedIndex = 1;
            }
            else if (VersionInfo.Build == "nightly")
            {
                get_build_selection.SelectedIndex = 2;
            }
            else
            {
                get_build_selection.SelectedIndex = 0;
            }
        }

        private async void check_for_updates_Click(object sender, EventArgs e)
        {
            if (!CooldownActive)
            {
                check_for_updates.Enabled = false;
                changelog_info.Text = "Fetching...";
                var CheckForUpdates = new Updater();
                string Updates = "";

                if (get_build_selection.SelectedIndex == 0)
                {
                    Updates = await CheckForUpdates.FetchReleasesAsync("");
                }
                else if (get_build_selection.SelectedIndex == 2)
                {
                    Updates = await CheckForUpdates.FetchReleasesAsync("develop-");
                }
                else
                {
                    Updates = await CheckForUpdates.FetchReleasesAsync("release-");
                }

                changelog_info.Text = Updates;

                // Initiate a cooldown to prevent spamming
                CooldownActive = true;
                CooldownTimer = new System.Timers.Timer(Cooldown);
                CooldownTimer.Elapsed += CooldownEnded!;
                CooldownTimer.AutoReset = false;
                CooldownTimer.Start();
            }
        }

        private void CooldownEnded(object sender, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    CooldownActive = false;
                    CooldownTimer!.Dispose();
                    check_for_updates.Enabled = true;
                }));
            }
            else
            {
                CooldownActive = false;
                CooldownTimer!.Dispose();
                check_for_updates.Enabled = true;
            }
        }
    }
}
