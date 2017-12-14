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

namespace FoosballApp
{
    [Activity(Label = "FoosballApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private readonly string BaseURL = "http://10.0.2.2:4860/";

        private Lazy<MediaRecorder> _recorder = new Lazy<MediaRecorder>(() => new MediaRecorder());

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
                        AddPlayer(name1.Text);
                        AddPlayer(name2.Text);
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
                var uri = Android.Net.Uri.Parse(BaseURL);
                var intent = new Intent(Intent.ActionView, uri: uri);
                StartActivity(intent);
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
        private void AddPlayer(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Contains(" "))
            {
                throw new NameIsIncorrectException(name);
            }

            var wc = new WebClient();

            if (wc.DownloadString(BaseURL + "api/Managing/TeamExists/" + name) != "true")
            {
                //wc.UploadString(BaseURL, "api/Managing/GetAllTeams/" + name);
            }
        }
    }
}

