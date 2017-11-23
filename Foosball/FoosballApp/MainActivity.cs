﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Content;
using System.Net;

namespace FoosballApp
{
    [Activity(Label = "FoosballApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private readonly string BaseURL = "http://localhost:4860/";
        MediaRecorder recorder;
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
                    AddPlayer(name1.Text);
                    AddPlayer(name2.Text);
                    SetContentView(Resource.Layout.GameRecord);
                    //Need to test file deletion after proccessing the match
                    string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/video.mp4";
                    var record = FindViewById<Button>(Resource.Id.Record);
                    var stop = FindViewById<Button>(Resource.Id.Stop);
                    var play = FindViewById<Button>(Resource.Id.Play);
                    var video = FindViewById<VideoView>(Resource.Id.VideoView);
                    var backGame = FindViewById<Button>(Resource.Id.GameRecordBack); ;
                    backGame.Click += delegate
                    {
                        SetContentView(Resource.Layout.QuickMatch);
                    };
                    record.Click += delegate
                    {
                        video.StopPlayback();
                        recorder = new MediaRecorder();
                        recorder.SetVideoSource(VideoSource.Default);
                        recorder.SetAudioSource(AudioSource.Default);
                        recorder.SetOutputFormat(OutputFormat.Default);
                        recorder.SetVideoEncoder(VideoEncoder.Default);
                        recorder.SetAudioEncoder(AudioEncoder.Default);
                        recorder.SetOutputFile(path);
                        recorder.SetPreviewDisplay(video.Holder.Surface);
                        //recorder.Prepare();
                        //recorder.Start();
                    };
                    stop.Click += delegate
                    {
                        if (recorder != null)
                        {
                            video.StopPlayback();
                            recorder.Stop();
                            recorder.Release();
                            //this needs to be done
                            //Proccesses proccesses = new Proccesses();
                            //proccesses.ProccessVideo(pathtovideo);
                            //proccesses.UploadResults(endpoint);
                            //DeleteFile(path);
                        }
                    };
                    play.Click += delegate
                    {
                        if (recorder == null)
                        {
                            //make it process the vid
                        }
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
                var uri = Android.Net.Uri.Parse("http://localhost:4860/");
                var intent = new Intent(Intent.ActionView, uri: uri);
                StartActivity(intent);
            };
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (recorder!= null)
            {
                recorder.Release();
                recorder.Dispose();
                recorder = null;
            }
        }
        private void AddPlayer(string name)
        {
            var wc = new WebClient();
            if (!(wc.DownloadString(BaseURL + "api/Managing/TeamExists/" + name) == "true"))
            {
                wc.UploadString(BaseURL, "api/Managing/GetAllTeams/" + name);
            }
            
        }
    }
}

