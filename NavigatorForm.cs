using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperNavigator
{
    public partial class NavigatorForm : Form
    {
        const string settings_filename = "settings.json";
        const string app_py_filename = "app.py";
        Navigator navigator;
        public NavigatorForm()
        {
            InitializeComponent();

            // get app location
            string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            navigator = new Navigator(System.IO.Path.GetDirectoryName(applicationLocation));

            // use json settings if exist
            LoadSettings();

            // update fields
            UpdateFields();
        }
        private void LoadSettings()
        {
            try
            {
                JObject obj = JObject.Parse(File.ReadAllText(navigator.AppDirrectory + "\\" + settings_filename));
                navigator.KtVizDirrectory = obj["KtVizDirrectory"].Value<string>();
                navigator.UsvDirrectory = obj["UsvDirrectory"].Value<string>();
                navigator.WorkingDirrectory = obj["WorkingDirrectory"].Value<string>();
            }
            catch { }
        }
        private void SaveSettings()
        {
            JObject obj = new JObject();
            obj.Add("KtVizDirrectory", navigator.KtVizDirrectory);
            obj.Add("UsvDirrectory", navigator.UsvDirrectory);
            obj.Add("WorkingDirrectory", navigator.WorkingDirrectory);
            using (StreamWriter file = File.CreateText(navigator.AppDirrectory + "\\" + settings_filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }
        private void UpdateFields()
        {
            tb_ktviz_dir.Text = navigator.KtVizDirrectory;
            tb_usv_dir.Text = navigator.UsvDirrectory;
            tb_working_dir.Text = navigator.WorkingDirrectory;
        }

        private string ChangeDirectory(string prevValue)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            return prevValue;
        }
        private async Task<bool> RunStartKtVizAsync()
        {
            string command = "python";
            string args = navigator.KtVizDirrectory + "\\" + app_py_filename;
            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args, true);
            return result.ExitCode == 0;
        }

        private void btn_Set_USV_Directory_Click(object sender, EventArgs e)
        {
            navigator.UsvDirrectory = ChangeDirectory(navigator.UsvDirrectory);
            UpdateFields();
        }

        private void btn_Set_Working_Directory_Click(object sender, EventArgs e)
        {
            navigator.WorkingDirrectory = ChangeDirectory(navigator.WorkingDirrectory);
            UpdateFields();
        }

        private void btn_Set_KTViz_Directory_Click(object sender, EventArgs e)
        {
            navigator.KtVizDirrectory = ChangeDirectory(navigator.KtVizDirrectory);
            UpdateFields();
        }

        private async void btn_RunViz_Click(object sender, EventArgs e)
        {
            btn_RunViz.Enabled = false;
            var result = await RunStartKtVizAsync();
            btn_RunViz.BackColor = result ? Color.Green : Color.Red;
            btn_RunViz.Enabled = true;
        }

        private void NavigatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private async void btn_analyze_Click(object sender, EventArgs e)
        {
            btn_analyze.Enabled = false;
            // Analyze result
            var result = await navigator.Analyze();
            if (result.Output != null) tb_output.AppendText(result.Output);

            // Check analyze report
            tb_output.AppendText(System.Environment.NewLine + (navigator.GetAnalyzeReportDangerous() ? "DANGER" : "SAFE"));
            btn_analyze.Enabled = true;
        }

        private async void btn_maneuver_Click(object sender, EventArgs e)
        {
            btn_maneuver.Enabled = false;
            // Maneuver result
            var result = await navigator.Maneuver();

            // Check maneuver result
            tb_output.AppendText(System.Environment.NewLine + "EXIT CODE:" + result.ToString());
            btn_maneuver.Enabled = true;
        }
    }
}
