using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace RtspRecorder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cts;
        private CancellationToken token;

        private readonly string myVideoDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
            "CameraView"
        );

        private readonly ConcurrentQueue<Mat> queue = new ConcurrentQueue<Mat>();
        private bool isRecording = false;
        private bool isPlaying = false;
        private string videoFullpath;
        private double fps;
        private int videoWidth;
        private int videoHeight;

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            VideoCapture cap = new VideoCapture();
            var addr = TextAddr.Text;
            var suc = int.TryParse(addr, out var camIndex);
            BtnPlay.Enabled = false;

            if (suc)
            {
                cap.Open(camIndex);
            }
            else
            {
                cap.Open(addr);
            }

            if (!cap.IsOpened())
            {
                MessageBox.Show("视频源打开失败");
                BtnPlay.Enabled = true;
                return;
            }

            fps = cap.Fps;
            videoWidth = cap.FrameWidth;
            videoHeight = cap.FrameHeight;

            if (cts == null)
            {
                cts = new CancellationTokenSource();
                token = cts.Token;
            }

            while (!token.IsCancellationRequested)
            {
                var mat = new Mat();
                var readSuccess = cap.Read(mat);
                if (!readSuccess)
                {
                    MessageBox.Show("视频结束");
                    CancelToken();
                    BtnPlay.Enabled = true;
                    return;
                }

                if (isRecording)
                {
                    queue.Enqueue(mat);
                }

                Cv2.ImShow(addr, mat);
                Cv2.WaitKey(5);

                isPlaying = true;
            }

            Cv2.DestroyAllWindows();
            cap.Release();
            cap.Dispose();
            BtnPlay.Enabled = true;
            isPlaying = false;
        }

        private void BtnStopPlay_Click(object sender, EventArgs e)
        {
            CancelToken();
        }

        private void CancelToken()
        {
            isRecording = false;
            isPlaying = false;
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }

        private async void BtnRecord_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                MessageBox.Show("请先播放视频，再开始录制");
                return;
            }
            VideoWriter writer = new VideoWriter();
            videoFullpath = GetVideoFileName();

            BtnRecord.Enabled = false;
            bool opened = writer.Open(
                videoFullpath,
                FourCC.H264,
                fps,
                new OpenCvSharp.Size(videoWidth, videoHeight)
            );

            if (!opened)
            {
                MessageBox.Show("视频写入失败");
                BtnRecord.Enabled = true;
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            isRecording = true;

            while (!token.IsCancellationRequested)
            {
                if (queue.Count < 1)
                {
                    await Task.Delay(1);
                    continue;
                }

                if (queue.TryDequeue(out Mat tmpMat))
                {
                    writer.Write(tmpMat);
                }

                LabelRecordTime.Text = $"录制：{stopwatch.Elapsed:hh':'mm':'ss}";
            }

            BtnRecord.Enabled = true;

            writer.Release();
            writer.Dispose();
            stopwatch.Stop();

            LabelVideoFile.Text = $"文件：{Path.GetFileName(videoFullpath)}";
        }

        private string GetVideoFileName()
        {
            var hashId = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var videoFile = $"{hashId}.mp4";
            var videoFullpath = Path.Combine(myVideoDir, videoFile);

            if (!Directory.Exists(myVideoDir))
            {
                Directory.CreateDirectory(myVideoDir);
            }

            return videoFullpath;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRecording || isPlaying)
            {
                e.Cancel = true;
                MessageBox.Show("请停止录制");
            }
        }

        private void LabelVideoFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(videoFullpath))
            {
                return;
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = Path.GetDirectoryName(videoFullpath),
                    UseShellExecute = false
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
