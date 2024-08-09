using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steamvr_manager
{
    internal class Manager
    {
        public static string steamvr_path = Settings.GetValue("steamvr_path").ToString()!;
        private static string Win64 = "\\bin\\win64";
        private static string FullPath = steamvr_path + Win64;

        // Returns vrserver.exe state, if it's renamed to vrserver.exe.disabled returns false
        public bool IsEnabled()
        {
            try
            {
                if (!ValidatePath(steamvr_path)) { return false; }
                if (File.Exists(FullPath + "\\vrserver.exe")) { return true; }
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Failed to get the enabled state of SteamVR.\n \nException:\n{ex.Message}");
            }
            return false;
        }

        // Set the vrserver.exe state, if the (bool State) is true, we'll rename it to vrserver.exe otherwise vrserver.exe.disabled
        public bool SetEnabled(bool State)
        {

            try
            {
                if (IsEnabled() && State == false)
                {
                    // Removes vrserver.exe.disabled if we already have a vrserver.exe to prevent problems
                    if (File.Exists(FullPath + "\\vrserver.exe.disabled")) { File.Delete(FullPath + "\\vrserver.exe.disabled"); }
                    File.Move(FullPath + "\\vrserver.exe", FullPath + "\\vrserver.exe.disabled");
                    return false;
                }
                else if (!IsEnabled() && State == true)
                {
                    if (File.Exists(FullPath + "\\vrserver.exe.disabled") && File.Exists(FullPath + "\\vrserver.exe"))
                    {
                        File.Delete(FullPath + "\\vrserver.exe.disabled");
                    }
                    else if (File.Exists(FullPath + "\\vrserver.exe.disabled"))
                    {
                        File.Move(FullPath + "\\vrserver.exe.disabled", FullPath + "\\vrserver.exe");
                    }
                    return true;
                }
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Failed to change the enabled state of SteamVR.\n \nException:\n{ex.Message}");
            }
            return IsEnabled();
        }

        // Prompt the user for their SteamVR Installation location
        // If AskOnce is true, we'll re-open the prompt until they select the right directory or clicks 'Cancel'
        public (bool, string?) AskForPath(bool AskOnce)
        {
            FolderBrowserDialog Dialog = new FolderBrowserDialog();
            DialogResult Result = DialogResult.None;
            Dialog.ShowNewFolderButton = false;

            Result = Dialog.ShowDialog();
            if (Result == DialogResult.OK && ValidatePath(Dialog.SelectedPath))
            {
                steamvr_path = Dialog.SelectedPath;
                Settings.SetValue("steamvr_path", Dialog.SelectedPath);
                return (true, steamvr_path);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("\"" + Dialog.SelectedPath + "\" is not a valid SteamVR directory!");
            }

            if (!AskOnce)
            {
                while (!ValidatePath(Dialog.SelectedPath))
                {
                    Result = Dialog.ShowDialog();
                    if (Result == DialogResult.OK && ValidatePath(Dialog.SelectedPath))
                    {
                        steamvr_path = Dialog.SelectedPath;
                        Settings.SetValue("steamvr_path", Dialog.SelectedPath);
                        return (true, steamvr_path);
                    }
                    else if (Result == DialogResult.Cancel) { break; }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("\"" + Dialog.SelectedPath + "\" is not a valid SteamVR directory!");
                    }
                }
            }

            return (false, null);
        }

        // Check if the path contains the correct files if it's a SteamVR Folder, returns true if those files exist
        public bool ValidatePath(String path)
        {
            try
            {
                if (path == null) { return false; }
                if (!Directory.Exists(path)) { return false; }
                if (File.Exists(path + "\\bin\\win64\\vrserver.exe") || File.Exists(path + "\\bin\\win64\\vrserver.exe.disabled")) { return true; }
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Failed to validate a given path.\n \nException:\n{ex.Message}");
            }
            return false;
        }

    }
}