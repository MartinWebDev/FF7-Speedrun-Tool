using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using FF7_Speedrun_Control_UI_Forms.Models;
using FF7_Speedrun_Control_Logic.Repositories;
using FF7_Speedrun_Control_Logic.Utils;

namespace FF7_Speedrun_Control_UI_Forms
{
    public partial class frmMain : Form
    {
        private HexConverter hex;
        private ConfigRepository config;
        private FPSFixRepository fpsFixRepository;
        private ProcessRepository gameProcessRepository;
        private ProcessRepository fpsFixProcessRepository;
        private List<Tuple<string, bool>> formState = new List<Tuple<string, bool>>();
        private PreflightCheckModel preflightCheckModel;

        CancellationTokenSource cts = new CancellationTokenSource();

        public frmMain()
        {
            InitializeComponent();
            hex = new HexConverter();
            config = new ConfigRepository();
            fpsFixRepository = new FPSFixRepository(config, hex);
            gameProcessRepository = new ProcessRepository(config.Get("FF7ProcessName"));
            fpsFixProcessRepository = new ProcessRepository(config.Get("FPSFixExecutable"));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var lines = new List<string>();
            lines.Add("Initialised");
            
            if (!IsAdministrator())
            {
                MessageBox.Show("If you run this application as administrator, you will not be prompted to grant admin permission to FPSFix, resulting in quicker relaunch times!", "Run this app as adminstrator for better experience!");
            }

            preflightCheckModel = new PreflightCheckModel(config).Run();
            if (!preflightCheckModel.IsSuccess)
            {
                lines.AddRange(preflightCheckModel.Errors);
                MessageBox.Show("Errors were found. Please check log window.");
                DisableForm();
            }
            else
            {
                LoadFPSFixValue();
                ResetForm();
                lines.Add("Ready to go!");
            }

            txtLog.Lines = lines.ToArray();
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void ResetForm()
        {
            btnEndRun.Enabled = false;
            btnSaveFrameLock.Enabled = false;
            btnLaunchFPSFix.Enabled = true;
            btnStartRun.Enabled = true;
        }

        private void LockForm()
        {
            // Save current state
            formState.Add(new Tuple<string, bool>("btnLaunchGame", btnLaunchFPSFix.Enabled));
            formState.Add(new Tuple<string, bool>("btnSaveFrameLock", btnSaveFrameLock.Enabled));
            formState.Add(new Tuple<string, bool>("txtFrameLock", txtFrameLock.Enabled));
            formState.Add(new Tuple<string, bool>("btnStartRun", btnStartRun.Enabled));
            // Lock fields
            btnLaunchFPSFix.Enabled = false;
            btnSaveFrameLock.Enabled = false;
            txtFrameLock.Enabled = false;
        }

        private void UnlockForm()
        {
            // Unload state into form
            btnLaunchFPSFix.Enabled = formState.FirstOrDefault(x => x.Item1 == "btnLaunchGame").Item2;
            btnSaveFrameLock.Enabled = formState.FirstOrDefault(x => x.Item1 == "btnSaveFrameLock").Item2;
            txtFrameLock.Enabled = formState.FirstOrDefault(x => x.Item1 == "txtFrameLock").Item2;
            btnStartRun.Enabled = formState.FirstOrDefault(x => x.Item1 == "btnStartRun").Item2;
            // Clear state
            formState.Clear();
        }

        private void DisableForm()
        {
            LockForm();
            btnStartRun.Enabled = false;
            btnEndRun.Enabled = false;
        }

        private void LoadFPSFixValue()
        {
            int frameLock = fpsFixRepository.GetFPSFIXValue();
            txtFrameLock.Text = frameLock.ToString();
        }

        private void SaveFPSFixValue(int frameLock)
        {
            fpsFixRepository.SaveFPSFixValue(frameLock);
        }

        private void txtFrameLock_TextChanged(object sender, EventArgs e)
        {
            btnSaveFrameLock.Enabled = true;
            btnLaunchFPSFix.Enabled = false;
            btnStartRun.Enabled = false;
        }

        private void btnSaveFrameLock_Click(object sender, EventArgs e)
        {
            try
            {
                int frameLock = int.Parse(txtFrameLock.Text);
                if (frameLock < 0 || frameLock > 255) throw new ArgumentOutOfRangeException();
                SaveFPSFixValue(frameLock);
                ResetForm();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Please enter a number between 0 and 255");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter a whole number only");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private async void btnStartRun_Click(object sender, EventArgs e)
        {
            LockForm();
            btnStartRun.Enabled = false;
            btnEndRun.Enabled = true;
            txtLog.Clear();

            try
            {
                Progress<string[]> progress = new Progress<string[]>();
                progress.ProgressChanged += ReportProgress;
                LaunchFPSFix();
                await RunGame(progress, cts.Token);
            }
            catch (OperationCanceledException)
            {
                string[] lines = new string[1];
                lines[0] = "Run Ended";
                txtLog.Lines = txtLog.Lines.Concat(lines).ToArray();
            }
        }

        private void btnEndRun_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            btnStartRun.Enabled = true;
            btnEndRun.Enabled = false;
            UnlockForm();
        }

        private void btnLaunchGame_Click(object sender, EventArgs e)
        {
            LaunchFPSFix();
        }




        // Game manager properties - Move to own class with later refactoring
        private async Task RunGame(IProgress<string[]> progress, CancellationToken cancellationToken)
        {
            for (;;)
            {
                cancellationToken.ThrowIfCancellationRequested();
                // Wait for game exit
                await Task.Run(() => WatchForGameClose());
                string[] report = new string[2];
                report[0] = "Game exit detected, relaunching FPSFix.";
                report[1] = "FPSFix running, please restart your game.";
                // Relaunch FPSFix
                cancellationToken.ThrowIfCancellationRequested();
                LaunchFPSFix();
                progress.Report(report);
            }
        }

        private async Task WatchForGameClose()
        {
            await Task.Run(() => gameProcessRepository.WaitForClose());
        }

        private void ReportProgress(object sender, string[] report)
        {
            txtLog.Lines = txtLog.Lines.Concat(report).ToArray();
        }

        private void LaunchFPSFix()
        {
            fpsFixProcessRepository.LaunchProcess();
        }
    }
}
