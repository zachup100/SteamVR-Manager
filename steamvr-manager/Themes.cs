using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace steamvr_manager
{

    internal class Themes
    {
        private static string RootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "steamvr_manager");
        private static string ThemeFolder = Path.Combine(RootFolder, "themes");
        private static string Default = "DefaultLight";
        public static string Current = UserSettings.GetValue("use_theme").ToString()!;

        protected virtual void onThemeApplied(XmlDocument Theme) { Applied?.Invoke(this, new ThemeAppliedEventArgs(Theme)); }
        public delegate void ThemeAppliedEvent(object sender, ThemeAppliedEventArgs e);
        public static event ThemeAppliedEvent Applied;

        public delegate void ThemesReadyEvent(object sender, EventArgs e);
        public static event ThemesReadyEvent Ready;

        public void Initialize()
        {
            if (!Directory.Exists(ThemeFolder))
            {
                Directory.CreateDirectory(ThemeFolder);
                CreateDefaultThemes();
            }

            Ready?.Invoke(this, EventArgs.Empty);
        }

        public bool ApplyTheme(string Theme)
        {
            try
            {
                string ThemeFile = Path.Combine(ThemeFolder, $"{Theme}.xml");
                if (File.Exists(ThemeFile))
                {
                    XmlDocument theme = new XmlDocument();
                    theme.Load(ThemeFile);
                    Applied?.Invoke(this, new ThemeAppliedEventArgs(theme));
                    //onThemeApplied(theme);
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"[ApplyTheme] Uncaught exception:\n {ex}");
            }

            return false;
        }

        public List<string>? ListThemes()
        {
            try
            {
                List<string> Files = Directory.GetFiles(ThemeFolder).ToList();
                List<string> Themes = new List<string>();
                foreach (string File in Files)
                {
                    string ThemeName = File.Replace($"{ThemeFolder}\\", string.Empty);
                    ThemeName = ThemeName.Replace(".xml", string.Empty);
                    Themes.Add(ThemeName);
                }
                return Themes;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"[ListThemes] Uncaught exception:\n {ex}");
            }

            return null;
        }

        public static Color ParseHex(string Hex)
        {
            Hex = Hex.TrimStart('#');
            if (Hex.Length == 0 || Hex.Length != 6)
            {
                return Color.FromArgb(255, 255, 255); // White
            }

            byte R = byte.Parse(Hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte G = byte.Parse(Hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte B = byte.Parse(Hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(R,G,B);
        }

        private static void CreateDefaultThemes()
        {
            try
            {
                // Light mode
                XmlDocument LightTheme = new XmlDocument();
                XmlElement Root = LightTheme.CreateElement("Theme");
                LightTheme.AppendChild(Root);

                XmlElement Main = LightTheme.CreateElement("Main");
                Root.AppendChild(Main);

                String white = $"#{Color.White.R:X2}{Color.White.G:X2}{Color.White.B:X2}";
                String black = $"#{Color.Black.R:X2}{Color.Black.G:X2}{Color.Black.B:X2}";

                // # Main Window
                // Titlebar Color
                XmlElement titlebar_color = LightTheme.CreateElement("Titlebar_Color");
                titlebar_color.InnerText = white;
                Main.AppendChild(titlebar_color);

                // Main Background
                XmlElement main_background_color = LightTheme.CreateElement("Background_Color");
                main_background_color.InnerText = white;
                Main.AppendChild(main_background_color);

                // Main Font Color
                XmlElement main_font_color = LightTheme.CreateElement("Font_Color");
                main_font_color.InnerText = black;
                Main.AppendChild(main_font_color);

                // Topbar Background
                XmlElement topbar_background_color = LightTheme.CreateElement("Topbar_Background_Color");
                topbar_background_color.InnerText = white;
                Main.AppendChild(topbar_background_color);

                LightTheme.Save(Path.Combine(ThemeFolder, "DefaultLight.xml"));
            } 
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            try
            {
                // Dark mode
                XmlDocument DarkTheme = new XmlDocument();
                XmlElement Root = DarkTheme.CreateElement("Theme");
                DarkTheme.AppendChild(Root);

                XmlElement Main = DarkTheme.CreateElement("Main");
                Root.AppendChild(Main);

                // # Main Window
                // Titlebar Color
                XmlElement titlebar_color = DarkTheme.CreateElement("Titlebar_Color");
                titlebar_color.InnerText = "#2E2E2E";
                Main.AppendChild(titlebar_color);

                // Main Background
                XmlElement main_background_color = DarkTheme.CreateElement("Background_Color");
                main_background_color.InnerText = "#2E2E2E";
                Main.AppendChild(main_background_color);

                // Main Font Color
                XmlElement main_font_color = DarkTheme.CreateElement("Font_Color");
                main_font_color.InnerText = "#FFFFFF";
                Main.AppendChild(main_font_color);

                // Topbar Background
                XmlElement topbar_background_color = DarkTheme.CreateElement("Topbar_Background_Color");
                topbar_background_color.InnerText = "#242424";
                Main.AppendChild(topbar_background_color);

                // Topbar Hover Background
                XmlElement topbar_hover_background_color = DarkTheme.CreateElement("Topbar_Hover_Background_Color");
                topbar_hover_background_color.InnerText = "#242424";
                Main.AppendChild(topbar_hover_background_color);

                DarkTheme.Save(Path.Combine(ThemeFolder, "DefaultDark.xml")); // Placeholder just to have two files
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
    // End of 'internal class Themes'

    public class ThemeAppliedEventArgs : EventArgs
    {
        public XmlDocument Theme { get; }

        public ThemeAppliedEventArgs(XmlDocument theme)
        {
            Theme = theme;
        }
    }
}
