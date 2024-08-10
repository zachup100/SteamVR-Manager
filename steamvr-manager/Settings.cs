using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamvr_manager
{
    public partial class Settings : Form
    {
        Themes Themes = new Themes();

        public Settings()
        {
            InitializeComponent();
            this.Shown += onWindowShown;
        }

        private void theme_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Selected = theme_list.SelectedItem.ToString()!;
            Themes.ApplyTheme(Selected);
            UserSettings.SetValue("use_theme", Selected);
        }

        private void onWindowShown(object sender, EventArgs e)
        {
            theme_list.Items.Clear();
            List<string> ThemesList = Themes.ListThemes()!;
            ThemesList.ForEach(theme => { theme_list.Items.Add(theme); });
        }

    }
}
