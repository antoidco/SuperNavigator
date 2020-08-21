using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperNavigator.Simulator;
using SuperNavigator.Visuals;
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
        const string bks_pic_py_filename = "bks-pic.py";
        private Navigator navigator;
        private KTVizPicture kTVizPicture;
        private Result _currentResult;
        private Image _showingImage;
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

            SetPrediction();
            SetPrefer();

            kTVizPicture = new KTVizPicture(navigator.FileWorker.KtVizDirectory + "\\" + bks_pic_py_filename,
                FileWorker.maneuver_json);
            _currentResult = new Result();
        }
        private void LoadSettings()
        {
            try
            {
                JObject obj = JObject.Parse(File.ReadAllText(navigator.FileWorker.AppDirectory + "\\" + settings_filename));
                navigator.FileWorker.KtVizDirectory = obj["KtVizDirectory"].Value<string>();
                navigator.FileWorker.UsvDirectory = obj["UsvDirectory"].Value<string>();
                navigator.FileWorker.WorkInitPath = obj["WorkingDirectory"].Value<string>();
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
            obj.Add("WorkingDirectory", navigator.FileWorker.WorkInitPath);
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
            tb_working_dir.Text = navigator.FileWorker.WorkInitPath;
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
            string args = $"\"{navigator.FileWorker.KtVizDirectory}\\{app_py_filename}\"";
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
            navigator.FileWorker.WorkInitPath = ChangeDirectory(navigator.FileWorker.WorkInitPath);
            panel_debug.Enabled = false;
            panel_simulate.Enabled = false;
            UpdateFields();
        }

        private void btn_Set_KTViz_Directory_Click(object sender, EventArgs e)
        {
            navigator.FileWorker.KtVizDirectory = ChangeDirectory(navigator.FileWorker.KtVizDirectory);
            kTVizPicture = new KTVizPicture(navigator.FileWorker.KtVizDirectory + "\\" + bks_pic_py_filename,
                FileWorker.maneuver_json);
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

        private void btn_backup_Click(object sender, EventArgs e)
        {
            navigator.SaveFilesAsInit();
        }

        private void btn_toInit_Click(object sender, EventArgs e)
        {
            navigator.ReturnFilesToInit();
        }

        private void btn_followOngoing_Click(object sender, EventArgs e)
        {
            try
            {
                navigator.FollowOngoing(Convert.ToDouble(tb_timeStep.Text));
                tb_output.AppendText(System.Environment.NewLine + "Follow maneuver end");
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
                tb_output.AppendText(System.Environment.NewLine + "Follow route end");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private async void btn_simulate_Click(object sender, EventArgs e)
        {
            btn_Simulate.Enabled = false;
            try
            {
                var result = await navigator.Simulate(Convert.ToDouble(tb_timeStep.Text));
                tb_output.AppendText(System.Environment.NewLine + result.Output);
                _currentResult = result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                tb_output.AppendText(System.Environment.NewLine + "Got an exception" + exception.Message);
            }
            btn_Simulate.Enabled = true;
        }

        private async void btn_realTargets_Click(object sender, EventArgs e)
        {
            var result = await navigator.CreateLinearTargetsManeuvers();
            tb_output.AppendText(System.Environment.NewLine + "Exit code (-1 expected from USV for some reason): " + result.ToString());
        }

        private void cb_noPrediction_CheckedChanged(object sender, EventArgs e)
        {
            SetPrediction();
        }

        private void rb_prefer_CheckedChanged(object sender, EventArgs e)
        {
            SetPrefer();
        }
        private void SetPrediction()
        {
            if (cb_noPrediction.Checked) navigator.Settings.PredictionType = PredictionType.Linear;
            else navigator.Settings.PredictionType = PredictionType.Full;
        }
        private void SetPrefer()
        {
            if (rb_base.Checked) navigator.Settings.AlgorithmPrefer = AlgorithmPrefer.PreferBase;
            if (rb_rvo.Checked) navigator.Settings.AlgorithmPrefer = AlgorithmPrefer.PreferRVO;
        }

        private void startFileWorker(object sender, EventArgs e)
        {
            navigator.FileWorker.Start();
            if (navigator.FileWorker.WorkStarted)
            {
                panel_simulate.Enabled = true;
                panel_debug.Enabled = true;
                tb_output.AppendText(System.Environment.NewLine + "Work started, new folder created");
            }
        }

        private async void btn_GenerateBitmaps_Click(object sender, EventArgs e)
        {
            track_images.Value = 0;
            tb_output.AppendText(System.Environment.NewLine + await kTVizPicture.CreatePictures(_currentResult));
            track_images.Maximum = Math.Max(0, kTVizPicture.Images.Count);
        }

        private void track_images_Scroll(object sender, EventArgs e)
        {
            if (track_images.Value > 0)
            {
                var img = kTVizPicture.Images[track_images.Value - 1];
                try
                {
                    pb_Viz.Image = Helpers.ResizeImage(img, pb_Viz.Width, pb_Viz.Height);
                } catch (Exception) { }
                _showingImage = new Bitmap(img);
            }
        }

        private void pb_Viz_SizeChanged(object sender, EventArgs e)
        {
            if (_showingImage != null)
            {
                try
                {
                    pb_Viz.Image = Helpers.ResizeImage(_showingImage, pb_Viz.Width, pb_Viz.Height);
                }
                catch (Exception) { }
            }
        }
    }
}
