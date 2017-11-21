using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace FoosballApp
{
    [Activity(Label = "FoosballApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MediaRecorder recorder;
        int filename = 1;
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
                //Need to capture Textfields
                var name1 = FindViewById<EditText>(Resource.Id.textView1);
                var name2 = FindViewById<EditText>(Resource.Id.textView2);
                var submitQuickMatchbtn = FindViewById<Button>(Resource.Id.SumbitQuickMatch);
                //Need to test file deletion after proccessing the match
                string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/video.mp4";
                var record = FindViewById<Button>(Resource.Id.Record);
                var stop = FindViewById<Button>(Resource.Id.Stop);
                var play = FindViewById<Button>(Resource.Id.Play);
                var video = FindViewById<VideoView>(Resource.Id.VideoView);
                //recording fails on emulator for some reason
                record.Click += delegate
                {
                    video.StopPlayback();
                    recorder = new MediaRecorder();
                    recorder.SetVideoSource(VideoSource.Camera);
                    recorder.SetOutputFormat(OutputFormat.Default);
                    recorder.SetVideoEncoder(VideoEncoder.Default);
                    recorder.SetOutputFile(path);
                    recorder.SetPreviewDisplay(video.Holder.Surface);
                    recorder.Start();
                };
                stop.Click += delegate
                {
                    if (recorder != null)
                    {
                        recorder.Stop();
                        recorder.Release();
                        //this needs to be done
                        Proccesses proccesses = new Proccesses();
                        proccesses.ProccessVideo(pathtovideo);
                        proccesses.UploadResults(endpoint);
                        DeleteFile(path);
                    }
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
                var uri = Android.Net.Uri.Parse("https://www.google.lt/search?q=How+not+to+be+retarded&oq=How+not+to+be+retarded&aqs=chrome..69i57.7006j0j8&sourceid=chrome&ie=UTF-8");
                var intent = new Intent(Intent.ActionView, uri);
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
    }
}

