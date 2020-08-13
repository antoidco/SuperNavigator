﻿using Newtonsoft.Json;
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
                JObject obj = JObject.Parse(File.ReadAllText(navigator.FileWorker.AppDirectory + "\\" + settings_filename));
                navigator.FileWorker.KtVizDirectory = obj["KtVizDirectory"].Value<string>();
                navigator.FileWorker.UsvDirectory = obj["UsvDirectory"].Value<string>();
                navigator.FileWorker.WorkingDirectory = obj["WorkingDirectory"].Value<string>();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private void SaveSettings()
        {
            JObject obj = new JObject();
            obj.Add("KtVizDirectory", navigator.FileWorker.KtVizDirectory);
            obj.Add("UsvDirectory", navigator.FileWorker.UsvDirectory);
            obj.Add("WorkingDirectory", navigator.FileWorker.WorkingDirectory);
            using (StreamWriter file = File.CreateText(navigator.FileWorker.AppDirectory + "\\" + settings_filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }
        private void UpdateFields()
        {
            tb_ktviz_dir.Text = navigator.FileWorker.KtVizDirectory;
            tb_usv_dir.Text = navigator.FileWorker.UsvDirectory;
            tb_working_dir.Text = navigator.FileWorker.WorkingDirectory;
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
            string args = navigator.FileWorker.KtVizDirectory + "\\" + app_py_filename;
            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args, true);
            return result.ExitCode == 0;
        }

        private void btn_Set_USV_Directory_Click(object sender, EventArgs e)
        {
            navigator.FileWorker.UsvDirectory = ChangeDirectory(navigator.FileWorker.UsvDirectory);
            UpdateFields();
        }

        private void btn_Set_Working_Directory_Click(object sender, EventArgs e)
        {
            navigator.FileWorker.WorkingDirectory = ChangeDirectory(navigator.FileWorker.WorkingDirectory);
            UpdateFields();
        }

        private void btn_Set_KTViz_Directory_Click(object sender, EventArgs e)
        {
            navigator.FileWorker.KtVizDirectory = ChangeDirectory(navigator.FileWorker.KtVizDirectory);
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
            if (result.Output != null) tb_output.AppendText(System.Environment.NewLine + result.Output);

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

        private async void btn_actual_Click(object sender, EventArgs e)
        {
            btn_actual.Enabled = false;
            // Maneuver result
            var result = await navigator.Actual();

            // Check maneuver result
            tb_output.AppendText(System.Environment.NewLine + "EXIT CODE:" + result.ToString());
            btn_actual.Enabled = true;
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            navigator.SaveFilesAsInit();
        }

        private void btn_toInit_Click(object sender, EventArgs e)
        {
            navigator.ReturnFilesToInit();
        }

        private void btn_followManeuver_Click(object sender, EventArgs e)
        {
            try
            {
                navigator.FollowManeuver(Convert.ToDouble(tb_timeStep.Text), rbToPrefer());
            }
            catch (Exception exception) 
            { 
                Console.WriteLine(exception.Message); 
            }
        }

        private void btn_follow_route_Click(object sender, EventArgs e)
        {
            try
            {
                navigator.FollowRoute(Convert.ToDouble(tb_timeStep.Text));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private async void btn_while_actual_Click(object sender, EventArgs e)
        {
            btn_while_actual.Enabled = false;
            try
            {
                var result = await navigator.SimulateWhileActual(Convert.ToDouble(tb_timeStep.Text), rbToPrefer());
                tb_output.AppendText(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                tb_output.AppendText("Got an exception" + exception.Message);
            }
            btn_while_actual.Enabled = true;
        }

        private AlgorithmPrefer rbToPrefer()
        {
            return rb_base.Checked ? AlgorithmPrefer.PreferBase : AlgorithmPrefer.PreferRVO;
        }

        private async void btn_realTargets_Click(object sender, EventArgs e)
        {
            await navigator.CreateLinearTargetsManeuvers();
        }
    }
}
