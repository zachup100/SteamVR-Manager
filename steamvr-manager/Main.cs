using steamvr_manager;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Transactions;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace steamvr_manager
{
    public partial class Main : Form
    {

        private Changelog ChangelogForm = new Changelog();
        private Settings Settings = new Settings();
        private Manager Manager = new Manager();
        private About AboutForm = new About();
        private Themes Themes = new Themes();

        private bool Is64Bit = Environment.Is64BitOperatingSystem; // Placeholder for now
        private void about_menu_item_Click(object sender, EventArgs e) { AboutForm.ShowDialog(); }
        private void check_for_updates_Click(object sender, EventArgs e) { ChangelogForm.ShowDialog(); }
        private void settings_Click(object sender, EventArgs e) { Settings.ShowDialog(); }
        // Close the application, not sure what to put in that menu for now
        private void exit_menu_item_Click(object sender, EventArgs e) { Application.Exit(); }

        // TESTING STUFF
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;
        private struct MARGINS { public int Left; public int Right; public int Top; public int Bottom; }



        public Main()
        {
            // TESTING STUFF
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            this.BackColor = Color.FromArgb(30, 30, 30); // Set a custom color for the title bar
            MARGINS margins = new MARGINS { Left = 0, Right = 0, Top = 1, Bottom = 0 };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);

            int color = ColorTranslator.ToWin32(this.BackColor);
            DwmSetWindowAttribute(this.Handle, color, ref color, sizeof(int));

            this.StartPosition = FormStartPosition.Manual;

            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle screenBounds = primaryScreen.Bounds;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenBounds.Width - (formWidth+100)) / 2, (screenBounds.Height - (formHeight-50)) / 2);

            // end of test
            UserSettings.Initiate();
            Themes.Applied += ThemeApplied;
            Themes.Initialize();
            InitializeComponent();

            this.Shown += new EventHandler(FormReady!);
        }

        // The function that will run when the Form is ready, and is shown.
        private void FormReady(object sender, EventArgs e)
        {
            string CurrentTheme = UserSettings.GetValue("use_theme").ToString()!;
            Themes.ApplyTheme(CurrentTheme);

            // Check to make sure the user's path they set is still the SteamVR directory
            string steamvr_path = Manager.steamvr_path;
            if (!Manager.ValidatePath(Manager.steamvr_path))
            {
                System.Windows.Forms.MessageBox.Show("Please select where your SteamVR install is located!");
                var (Success, Path) = Manager.AskForPath(false);
                if (Success)
                {
                    steamvr_path = Path!;
                    return;
                }
            }

            // Separate if statement just in case the user chooses not to tell the program where SteamVR is located
            if (Manager.ValidatePath(Manager.steamvr_path))
            {
                steamvr_directory.Text = steamvr_path;
                steamvr_enabled.Checked = Manager.IsEnabled();
                steamvr_toggle.Text = Manager.IsEnabled() ? "Disable SteamVR" : "Enable SteamVR";
                return;
            }
            steamvr_directory.Text = "SteamVR not found!";
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

        // Changes the state if SteamVR is enabled or not
        private void steamvr_toggle_Click(object sender, EventArgs e)
        {
            Manager.SetEnabled(!Manager.IsEnabled());
            steamvr_enabled.Checked = Manager.IsEnabled();
            steamvr_toggle.Text = Manager.IsEnabled() ? "Disable SteamVR" : "Enable SteamVR";
        }

        private void ThemeApplied(object sender, ThemeAppliedEventArgs e)
        {
            if (e.Theme != null)
            {
                XmlDocument Theme = e.Theme;
                XmlNode MainWindow = Theme.SelectSingleNode("/Theme/Main")!;
                if (MainWindow != null)
                {

                    XmlNode TitleBGC = MainWindow.SelectSingleNode("Titlebar_Color")!;
                    Color title_color = ColorTranslator.FromHtml(TitleBGC.InnerText);
                    int title_color_value = ColorTranslator.ToWin32(title_color);
                    DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref title_color_value, sizeof(int));


                    XmlNode MainBGC = MainWindow.SelectSingleNode("Background_Color")!;
                    this.BackColor = Themes.ParseHex(MainBGC.InnerText);
                    XmlNode TopbarBGC = MainWindow.SelectSingleNode("Topbar_Background_Color")!;
                    topbar.BackColor = Themes.ParseHex(TopbarBGC.InnerText);
                    XmlNode FontColor = MainWindow.SelectSingleNode("Font_Color")!;
                    steamvr_enabled_label.ForeColor = Themes.ParseHex(FontColor.InnerText);
                    topbar.ForeColor = Themes.ParseHex(FontColor.InnerText);

                    // temp
                    steamvr_directory.BackColor = Themes.ParseHex(MainBGC.InnerText);
                    steamvr_directory.ForeColor = Themes.ParseHex(FontColor.InnerText);

                    select_directory.BackColor = Themes.ParseHex(TopbarBGC.InnerText);
                    select_directory.ForeColor = Themes.ParseHex(FontColor.InnerText);

                    steamvr_toggle.BackColor = Themes.ParseHex(TopbarBGC.InnerText);
                    steamvr_toggle.ForeColor = Themes.ParseHex(FontColor.InnerText);

                    
                }
            }
        }
    }
}

