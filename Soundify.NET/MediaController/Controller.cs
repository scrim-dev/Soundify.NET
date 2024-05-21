using AudioSwitcher.AudioApi.CoreAudio;
using ReaLTaiizor.Controls;
using Soundify.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Control;
using WindowsMediaController;

namespace Soundify.NET.MediaController
{
    internal class Controller
    {
        public static MediaManager? Manager { get; set; }
        public static CoreAudioDevice? CoreDevice { get; set; }
        public static PoisonProgressBar? TimelineBar { get; set; }

        public static void Init()
        {
            Manager = new MediaManager();

            Manager.OnAnySessionOpened += OnAnySessionOpened;
            Manager.OnAnySessionClosed += OnAnySessionClosed;
            Manager.OnFocusedSessionChanged += OnFocusedSessionChanged;
            Manager.OnAnyMediaPropertyChanged += OnAnyMediaPropertyChanged;
            Manager.OnAnyPlaybackStateChanged += OnAnyPlaybackStateChanged;
            Manager.OnAnyTimelinePropertyChanged += OnAnyTimelinePropertyChanged;

            Manager.Start();
        }

        public static CancellationTokenSource cts = new();
        public static readonly Thread UpdateThread = new(() => DoUpdate(cts.Token));
        private static void DoUpdate(CancellationToken tkn)
        {
            while (true)
            {
                Update(); //Force every second
                Thread.Sleep(1000);
            }
        }

        public static void DisposeUpdateThread()
        {
            cts.Cancel();
            //UpdateThread.Join();
        }

        public static void Update() { Manager.ForceUpdate(); }

        public static void Dispose()
        {
            try { Manager.Dispose(); } catch { }
            DisposeUpdateThread();
        }

        private static void OnAnySessionOpened(MediaManager.MediaSession mediaSession)
        {
            if (mediaSession != null) 
            {
                MediaInfo.ID = mediaSession.Id;
                ConsoleLog.Log($"Session Opened -> {mediaSession.Id}");
            }
        }

        private static void OnAnySessionClosed(MediaManager.MediaSession mediaSession)
        {
            if (mediaSession != null) 
            {
                ConsoleLog.Log($"Session Closed -> {mediaSession.Id}");
            }
        }

        private static void OnFocusedSessionChanged(MediaManager.MediaSession mediaSession)
        {
            if (mediaSession != null) 
            {
                //ConsoleLog.Warn($"Session Changed -> {mediaSession.ControlSession.GetPlaybackInfo}");
            }
        }

        private static void OnAnyMediaPropertyChanged(MediaManager.MediaSession mediaSession, GlobalSystemMediaTransportControlsSessionMediaProperties mediaProperties)
        {
            if (mediaSession != null || mediaProperties != null) 
            {
                MediaInfo.SongName = mediaProperties.Title;
                MediaInfo.SongArtist = mediaProperties.Artist;
                ConsoleLog.Log($"Session Playing -> {mediaProperties.Title} by {mediaProperties.Artist}");
            }
        }

        private static void OnAnyPlaybackStateChanged(MediaManager.MediaSession mediaSession, GlobalSystemMediaTransportControlsSessionPlaybackInfo playbackInfo)
        {
            if (mediaSession != null || playbackInfo != null)
            {
                ConsoleLog.Log($"Session State -> {playbackInfo.PlaybackType}");
            }
        }

        private static void OnAnyTimelinePropertyChanged(MediaManager.MediaSession mediaSession, GlobalSystemMediaTransportControlsSessionTimelineProperties timelineProperties)
        {
            if (mediaSession != null || timelineProperties != null)
            {
                TimelineBar.Value = 0;
                MediaInfo.TimelineMin = timelineProperties.StartTime.Minutes;
                MediaInfo.TimelineMax = timelineProperties.EndTime.Minutes;
                ConsoleLog.Log($"Timeline -> {timelineProperties.StartTime}/{timelineProperties.EndTime} ({timelineProperties.MinSeekTime}:{timelineProperties.MaxSeekTime})");
            }
        }
    }
}