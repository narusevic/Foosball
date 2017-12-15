using System;
using System.Collections.Generic;
using System.Json;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Content;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FoosballApp.Exceptions;
using Plugin.Media;
using System.IO;
using Android;

namespace FoosballApp
{
    [Activity(Label = "FoosballApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Lazy<MediaRecorder> _recorder = new Lazy<MediaRecorder>(() => new MediaRecorder());
        private Client _client = new Client();

        private int _scoreGuest = 0;
        private int _scoreHost = 0;
        private int _matchId = -1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var singl = FindViewById<ImageButton>(Resource.Id.imageButton1);
            var doubl = FindViewById<ImageButton>(Resource.Id.imageButton2);
            var troph = FindViewById<ImageButton>(Resource.Id.imageButton3);
            var webe = FindViewById<ImageButton>(Resource.Id.imageButton4);
            singl.Click += (s, arg) =>
            {
                SetContentView(Resource.Layout.QuickMatch);
                var name1 = FindViewById<EditText>(Resource.Id.editText1);
                var name2 = FindViewById<EditText>(Resource.Id.editText2);
                var submitQuickMatchbtn = FindViewById<Button>(Resource.Id.SumbitQuickMatch);
                var backQuickMatchbtn = FindViewById<Button>(Resource.Id.QuickMatchBack);
                backQuickMatchbtn.Click += delegate
                {
                    SetContentView(Resource.Layout.Main);
                };
                submitQuickMatchbtn.Click += delegate
                {
                    try
                    {
                        _matchId = _client.AddTeams(name1.Text, name2.Text);
                    }
                    catch (NameIsIncorrectException ex)
                    {
                        FindViewById<TextView>(Resource.Id.textView1).Text = ex.Message;
                    }

                    SetContentView(Resource.Layout.GameRecord);
                    //Need to test file deletion after proccessing the match
                    string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMovies) + "test.mp4";
                    var record = FindViewById<Button>(Resource.Id.Record);
                    var stop = FindViewById<Button>(Resource.Id.Stop);
                    var play = FindViewById<Button>(Resource.Id.Play);
                    var video = FindViewById<VideoView>(Resource.Id.VideoView);
                    var backGame = FindViewById<Button>(Resource.Id.GameRecordBack);

                    backGame.Click += delegate
                    {
                        SetContentView(Resource.Layout.QuickMatch);
                    };

                    record.Click += delegate
                    {

                        video.StopPlayback();
                        
                        var recorder = _recorder.Value;
                        recorder.SetVideoSource(VideoSource.Camera);
                        recorder.SetAudioSource(AudioSource.Mic);
                        recorder.SetOutputFormat(OutputFormat.Default);
                        recorder.SetVideoEncoder(VideoEncoder.Default);
                        recorder.SetAudioEncoder(AudioEncoder.Default);
                        recorder.SetOutputFile(path);
                        recorder.SetPreviewDisplay(video.Holder.Surface);
                        recorder.Prepare();
                        recorder.Start();
                    };

                    stop.Click += delegate
                    {
                        var recorder = _recorder.Value;

                        if (recorder != null)
                        {
                            video.StopPlayback();
                            recorder.Stop();
                            recorder.Release();
                            WebClient webClient = new WebClient();
                            byte[] responsearray = webClient.UploadFile("http://192.168.1.128:4860/api/Upload", path);
                        }
                    };

                    play.Click += delegate
                    {
                        Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                        var uri = Android.Net.Uri.Parse(path);

                        mediaScanIntent.SetData(uri);
                        SendBroadcast(mediaScanIntent);

                        video.SetVideoURI(uri);
                        video.Start();
                    };

                    ScoreClick();
                };
            };
            doubl.Click += (s, arg) =>
            {
                SetContentView(Resource.Layout.TournamentMode);
            };
            troph.Click += (s, arg) =>
            {
                SetContentView(Resource.Layout.Statistics);
            };
            webe.Click += (s, arg) =>
            {
                var uri = Android.Net.Uri.Parse("");
                var intent = new Intent(Intent.ActionView, uri: uri);
                StartActivity(intent);
            };
        }

        private void ScoreClick()
        {
            var scoreGuest = FindViewById<Button>(Resource.Id.ScoreGuest);
            var scoreHost = FindViewById<Button>(Resource.Id.ScoreHost);
            
            scoreGuest.Click += (s, args) =>
            {
                _scoreHost++;

                _client.UpdateScore(true, _scoreHost, _scoreGuest, _matchId);
                ScoreClick();
            };

            scoreHost.Click += (s, args) =>
            {
                _scoreGuest++;

                _client.UpdateScore(false, _scoreHost, _scoreGuest, _matchId);
                ScoreClick();
            };
        }

        protected override void OnDestroy()
        {

            base.OnDestroy();

            var recorder = _recorder.Value;

            if (recorder != null)
            {
                recorder.Release();
                recorder.Dispose();
                recorder = null;
            }
        }
    }
}

