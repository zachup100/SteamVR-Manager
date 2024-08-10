using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace steamvr_manager
{
    internal class UserSettings
    {
        private static string RootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "steamvr_manager");
        private static string ConfigFile = Path.Combine(RootFolder, "user.config");

        private static Dictionary<string, string> DefaultSettings = new Dictionary<string, string>
        {
            { "steamvr_path", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\SteamVR\\" },
            { "use_theme", "DefaultLight" }
        };


        // Load config into memory
        public static void Initiate()
        {
            // Create new steamvr_manager Directory if it doesn't exist
            if (!Directory.Exists(RootFolder)) { Directory.CreateDirectory(RootFolder); }

            // Auto generate new config file based on Dictionary DefaultSettings
            if (!File.Exists(ConfigFile))
            {
                CreateDefaultConfig();
            }
            else
            {

                XmlDocument Config = new XmlDocument();
                try
                {
                    Config.Load(ConfigFile);

                    XmlNode? Root = Config.SelectSingleNode("Settings");
                    if (Root == null) { Root = Config.CreateElement("Settings"); }

                    // Check for any missing settings from ConfigFile
                    foreach (KeyValuePair<string, string> Index in DefaultSettings)
                    {
                        XmlNode? Setting = Root.SelectSingleNode($"{Index.Key}");
                        if (Setting == null)
                        {
                            XmlElement new_setting = Config.CreateElement($"{Index.Key}");
                            new_setting.InnerText = Index.Value;
                            Root.AppendChild(new_setting);
                        }
                    }

                    try
                    {
                        Config.Save(ConfigFile);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show($"Failed to save Settings file due to an Uncaught Exception please tread carefully!\n \n Exception:\n{ex}");
                    }
                }
                catch (XmlException ex)
                {
                    if (File.Exists(ConfigFile + ".backup")) { File.Delete(ConfigFile + ".backup"); }
                    File.Move(ConfigFile, ConfigFile + ".backup");
                    CreateDefaultConfig();
                    System.Windows.Forms.MessageBox.Show($"Failed to load Settings file, your old settings file was renamed to preserve it.\n \n Exception:\n{ex}");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Failed to load Settings file due to an Uncaught Exception please tread carefully!\n \n Exception:\n{ex}");
                }
            }
        }

        // Overwrite key in config with a new value
        public static bool SetValue(String key, String value)
        {
            XmlDocument Config = new XmlDocument();

            try
            {
                Config.Load(ConfigFile);

                XmlNode? Root = Config.SelectSingleNode("Settings");
                if (Root == null) { return false; }

                XmlNode? Setting = Root.SelectSingleNode(key);
                if (Setting == null) { return false; }

                if (Setting.InnerText != value)
                {
                    Setting.InnerText = value;
                    try
                    {
                        Config.Save(ConfigFile);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show($"Failed to save Settings file due to an Uncaught Exception please tread carefully!\n \n Exception:\n{ex}");
                    }
                }

                return true;
            }
            catch (XmlException ex)
            {
                if (File.Exists(ConfigFile + ".backup")) { File.Delete(ConfigFile + ".backup"); }
                File.Move(ConfigFile, ConfigFile + ".backup");
                CreateDefaultConfig();
                System.Windows.Forms.MessageBox.Show($"Failed to load Settings file, your old settings file was renamed to preserve it.\n \n Exception:\n{ex}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Failed to load Settings file due to an Uncaught Exception please tread carefully!\n \n Exception:\n{ex}");
            }

            return false;
        }

        // Returns the value of a given key, if no key is found we'll return null
        public static object GetValue(String? key)
        {
            XmlDocument Config = new XmlDocument();

            try
            {
                Config.Load(ConfigFile);

                XmlNode? Root = Config.SelectSingleNode("Settings");
                if (Root == null) { return null!; }

                XmlNode? Setting = Root.SelectSingleNode(key!);
                if (Setting == null) { return null!; }
                String value = Setting.InnerText;
                Config = null!;
                if (value == "True" || value == "False")
                {
                    bool Result = bool.Parse(value);
                    return Result;
                }
                return value;
            }
            catch (XmlException ex)
            {
                if (File.Exists(ConfigFile + ".backup")) { File.Delete(ConfigFile + ".backup"); }
                File.Move(ConfigFile, ConfigFile + ".backup");
                CreateDefaultConfig();
                System.Windows.Forms.MessageBox.Show($"Failed to load Settings file, your old settings file was renamed to preserve it.\n \n Exception:\n{ex}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Failed to load Settings file due to an Uncaught Exception please tread carefully!\n \n Exception:\n{ex}");
            }

            return null!;
        }

        // Generates a default config using Dictionary DefaultSettings
        private static void CreateDefaultConfig()
        {
            XmlDocument Config = new XmlDocument();
            XmlElement Root = Config.CreateElement("Settings");
            Config.AppendChild(Root);

            foreach (KeyValuePair<string, string> Index in DefaultSettings)
            {
                XmlElement new_setting = Config.CreateElement($"{Index.Key}");
                new_setting.InnerText = Index.Value;
                Root.AppendChild(new_setting);
            }

            try
            {
                Config.Save(ConfigFile);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Failed to create Default Settings file due to an Uncaught Exception please tread carefully!\n \n Exception:\n{ex}");
            }
        }
    }
}
