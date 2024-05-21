using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using Soundify.NET.MediaController;
using Soundify.NET.OSC;
using Soundify.NET.Utils;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Soundify.NET
{
    public partial class MainForm : Form
    {
        public const string AppVersion = "1.0.0.1";

        //Credits to Jonas Kohl for dark title bar
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }

        //1000, 700
        public MainForm()
        {
            UseImmersiveDarkMode(handle: Handle, true);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MinimumSize = new(1000, 700);
            MaximumSize = new(9999, 9999);
            MaximizeBox = true;
            MinimizeBox = true;
            StartPosition = FormStartPosition.CenterParent;

            //load WebViews
            try { SpotifyWebView.Source = new("https://open.spotify.com/"); } catch { }
            try { SoundCloudWebView.Source = new("https://soundcloud.com/discover"); } catch { }

            //Timers
            MainTimer.Enabled = true;
            MainTimer.Interval = 1000;
            OSCTimer.Enabled = true;
            OSCTimer.Interval = 1355; //1.3 rate limit

            //Setup Form console
            var rtbc = new TextBoxLog(RichTextBoxConsole);
            Console.SetOut(rtbc);
            ConsoleLog.TBLog = rtbc;
            RichTextBoxConsole.ReadOnly = true;
            RichTextBoxConsole.Cursor = Cursors.No;
            RichTextBoxConsole.BackColor = Color.Black;
            RichTextBoxConsole.ForeColor = Color.White;

            //Chatbox
            OscExampleTextBox.ReadOnly = true;
            OscExampleTextBox.Cursor = Cursors.No;
            OscExampleTextBox.BackColor = Color.Black;

            //Osc
            SoundifyOSC.Setup("127.0.0.1", 9000);

            //Other
            VERSIONTEXT.Text = AppVersion;
            Directories.Load();
            Controller.Init();
            Controller.UpdateThread.Start();
            Controller.CoreDevice = new CoreAudioController().DefaultPlaybackDevice;
            VolumeTrackBar.Value = 15;
            OSCHandler.OscTextBox = OscExampleTextBox;
            MediaTimelineBar.Value = 0;
            RichTextBoxConsole.Clear();
            Controller.TimelineBar = MediaTimelineBar;
        }

        private void DisposeAll()
        {
            MainTimer.Dispose();
            SpotifyWebView.Dispose();
            SoundCloudWebView.Dispose();
            CustomWebView.Dispose();
            SoundifyOSC.Dispose();
            OSCTimer.Dispose();
            Controller.Dispose();
        }

        //Constant timer
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (ShowSongNameCheckBox.Checked) { OSCToggles.SongNameTog = true; } else { OSCToggles.SongNameTog = false; }
            if (SoundifyNameCheckBox.Checked) { OSCToggles.SoundifyNameTog = true; } else { OSCToggles.SoundifyNameTog = false; }
            if (ListeningToCheckBox.Checked) { OSCToggles.ListeningToMediaTog = true; } else { OSCToggles.ListeningToMediaTog = false; }
            if (BorderTextCheckBox.Checked) { OSCToggles.BorderFXTog = true; } else { OSCToggles.BorderFXTog = false; }
            if (TopMostCheckBox.Checked) { AppToggles.TopMostTog = true; } else { AppToggles.TopMostTog = false; }
            if (NotifsCheckBox.Checked) { AppToggles.NotifsTog = true; } else { AppToggles.NotifsTog = false; }
            if (SoundFXCheckBox.Checked) { AppToggles.AppSoundsTog = true; } else { AppToggles.AppSoundsTog = false; }
            if (LogsCheckBox.Checked) { AppToggles.ConsoleLogTog = true; } else { AppToggles.ConsoleLogTog = false; }
            if (SaveLogsCloseCheckBox.Checked) { AppToggles.SaveLogsTog = true; } else { AppToggles.SaveLogsTog = false; }
            if(UntrustedUrisCheckBox.Checked) { AppToggles.UntrustedUrisTog = true; } else { AppToggles.UntrustedUrisTog = false; }

            TopMost = AppToggles.TopMostTog;
        }

        //OSC
        private void OSCTimer_Tick(object sender, EventArgs e)
        {
            if (OSCToggles.MainOSCTog) { Send.SendOSC(); }
        }

        private void LogoBox_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://github.com/scrim-dev"); } catch { }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppToggles.SaveLogsTog)
            {
                if (!File.Exists($"{Directories.AppFolder}\\Logs.txt"))
                {
                    try { File.WriteAllText($"{Directories.AppFolder}\\Logs.txt", RichTextBoxConsole.Text); } catch { }
                }
                else
                {
                    File.WriteAllText($"{Directories.AppFolder}\\Logs.txt", RichTextBoxConsole.Text);
                }
            }

            DisposeAll();
            Process.GetCurrentProcess().Kill();
        }

        private void ScrimLogoBox_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://github.com/scrim-dev"); } catch { }
        }

        private void GithubPicBox_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://github.com/scrim-dev"); } catch { }
        }

        private void WebsitePicBox_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://www.scrim.cc/"); } catch { }
        }

        private void YoutubePicBox_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://www.youtube.com/channel/UC47ldRzs1HoJiib7oPew8JQ"); } catch { }
        }

        private void DiscordPicBox_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://discord.com/invite/GGFQtgDuQR"); } catch { }
        }

        private void UpdateCheckBtn_Click(object sender, EventArgs e)
        {
            /*Hide();
            DisposeAll();
            UpdateForm form = new();
            form.Show();
            form.Focus();*/

            MessageBox.Show("This is still being worked on!");
        }

        private void RestartAppBtn_Click(object sender, EventArgs e)
        {
            DisposeAll();
            Application.Restart();
        }

        private void ClearWebCacheBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Directories.WebView2Folder))
            {
                try { Directory.Delete(Directories.WebView2Folder, true); } 
                catch { }
            }
        }

        private void ClearConsoleBtn_Click(object sender, EventArgs e)
        {
            RichTextBoxConsole.Clear();
        }

        private void SaveCurConsLogsBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists($"{Directories.AppFolder}\\Logs.txt"))
            {
                try { File.WriteAllText($"{Directories.AppFolder}\\Logs.txt", RichTextBoxConsole.Text); } catch { }
            }
            else
            {
                File.WriteAllText($"{Directories.AppFolder}\\Logs.txt", RichTextBoxConsole.Text);
            }
        }

        private static string? Newuri { get; set; } = null;
        private void SetCustomUrlBtn_Click(object sender, EventArgs e)
        {
            if (AppToggles.UntrustedUrisTog)
            {
                CustomWebView.Enabled = true;
                try { CustomWebView.Source = new(CustomURLTextBox.Text); } catch { }
                CustomWebView.Size = new(835, 607);
                CustomWebView.Dock = DockStyle.Fill;
                try { CustomWebView.Reload(); } catch { }
                CustomWebView.ZoomFactor = 1;
            }
            else
            {
                Newuri = CustomURLTextBox.Text;
                if (!string.IsNullOrEmpty(Newuri))
                {
                    if (URLs.WhitelistedMedia.Any(uri => Newuri.Contains(uri)))
                    {
                        CustomWebView.Size = new Size(838, 647);
                        CustomWebView.Dock = DockStyle.Fill;
                        try { CustomWebView.Source = new Uri(Newuri); }
                        catch
                        {
                            MessageBox.Show("Check console","ERROR");
                            ConsoleLog.Error("Failed to load URL (Make sure to add https://)\n" +
                            "If you keep getting this error contact Scrim or go to the Support channel on discord");
                        }
                        CustomWebView.ZoomFactor = 0.9;
                    }
                    else
                    {
                        MessageBox.Show("Check console", "ERROR");
                        ConsoleLog.Error("Failed to load URL! The URL is not whitelisted or typed incorrectly!");
                    }
                }
            }
        }

        private void SaveCustomUrlBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists($"{Directories.AppFolder}\\CustomUrl.db"))
            {
                try { File.WriteAllText($"{Directories.AppFolder}\\customurl.db", CustomURLTextBox.Text); } catch { }
            }
            else
            {
                File.WriteAllText($"{Directories.AppFolder}\\customurl.db", CustomURLTextBox.Text);
            }
        }

        private void ResetCustomUrlBtn_Click(object sender, EventArgs e)
        {
            CustomWebView.Enabled = false;
            try { CustomWebView.Dispose(); } catch { }
            CustomWebView.Size = new(10, 10);
            CustomWebView.Dock = DockStyle.None;
            try { CustomWebView.Reload(); } catch { }
            CustomWebView.ZoomFactor = 0;
        }

        private void EnableOscBtn_Click(object sender, EventArgs e)
        {
            var red = Color.FromArgb(255, 0, 43);
            var yellow = Color.FromArgb(255, 179, 0);
            OSCToggles.MainOSCTog = true;
            EnableOscBtn.PrimaryColor = red;
            DisableOscBtn.PrimaryColor = yellow;
            Alerts.Success();
        }

        //64, 158, 255
        private void DisableOscBtn_Click(object sender, EventArgs e)
        {
            var defaultcolor = Color.FromArgb(64, 158, 255);
            OSCToggles.MainOSCTog = false;
            EnableOscBtn.PrimaryColor = defaultcolor;
            DisableOscBtn.PrimaryColor = defaultcolor;
            Alerts.SFX();
        }

        private void PrevMediaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var session = Controller.Manager.WindowsSessionManager.GetCurrentSession();
                _ = session.TrySkipPreviousAsync();
            }
            catch { }
        }

        private void PlayMediaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var session = Controller.Manager.WindowsSessionManager.GetCurrentSession();
                _ = session.TryPlayAsync();
            }
            catch { }
        }

        private void PauseMediaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var session = Controller.Manager.WindowsSessionManager.GetCurrentSession();
                _ = session.TryPauseAsync();
            }
            catch { }
        }

        private void StopMediaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var session = Controller.Manager.WindowsSessionManager.GetCurrentSession();
                _ = session.TryStopAsync();
            }
            catch { }
        }

        private void NextMediaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var session = Controller.Manager.WindowsSessionManager.GetCurrentSession();
                _ = session.TrySkipNextAsync();
            }
            catch { }
        }

        private void ApplyVolumeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.CoreDevice.Volume = VolumeTrackBar.Value;
            }
            catch { }
        }

        private void ResetVolumeBtn_Click(object sender, EventArgs e)
        {
            VolumeTrackBar.Value = 15;
            try
            {
                Controller.CoreDevice.Volume = VolumeTrackBar.Value;
            }
            catch { }
        }
    }
}
