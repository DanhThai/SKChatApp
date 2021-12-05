using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using NAudio.Wave;
using PBL41.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL41
{
    public partial class FormCall : Form
    {
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice videoCaptureDevice = null;
        private Bitmap video;
        private Bitmap video2;
        public VideoFileWriter FileWriter = new VideoFileWriter();
        WaveIn waveIn;
        WaveOut waveOut;
        BufferedWaveProvider bufferedWaveProvider;

        public FormCall()
        {
            InitializeComponent();
            btnStartCam.Visible = false;
            btnStartMicro.Visible = false;

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            ChatClient.instance.SendEndCall();
            this.Close();
        }

        private void btnStopCam_Click(object sender, EventArgs e)
        {
            btnStartCam.Visible = true;
            btnStopCam.Visible = false;
            if (videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
                pictureBoxMe.Image = null;
            }
        }

        private void btnStartCam_Click(object sender, EventArgs e)
        {
            btnStartCam.Visible = false;
            btnStopCam.Visible = true;

            videoCaptureDevice.Start();
        }

        private void btnStopMicro_Click(object sender, EventArgs e)
        {
            btnStartMicro.Visible = true;
            btnStopMicro.Visible = false;
            waveIn.StopRecording();
        }

        private void btnStartMicro_Click(object sender, EventArgs e)
        {
            btnStartMicro.Visible = false;
            btnStopMicro.Visible = true;
            //waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();
        }

        private void FormCall_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(5000);
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoCaptureDevice = new VideoCaptureDevice(VideoCaptureDevices[0].MonikerString);
            //videoCaptureDevice.NewFrame += FinalVideo_NewFrame;
            //videoCaptureDevice.Start();
            //videoCaptureDevice.NewFrame += FinalVideo2_NewFrame;
            //videoCaptureDevice.Start();

            waveOut = new WaveOut();
            int sampleRate = 8000; // 8 kHz
            int channels = 1; // mono
            waveIn = new WaveIn(this.Handle);
            waveIn.BufferMilliseconds = 100;
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();

            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();

            Thread th1 = new Thread(() =>
            {
                while (true)
                {
                    byte[] data = CallClient.instance.receiveData();

                    //string msg = Encoding.ASCII.GetString(data);
                    //Console.WriteLine(msg);
                    if (data != null)
                    {
                        bufferedWaveProvider.AddSamples(data, 0, data.Length);
                        if (bufferedWaveProvider.BufferedDuration.Milliseconds > 500)
                            bufferedWaveProvider.ClearBuffer();
                    }
                    else continue;
                }
            });
            th1.IsBackground = true;
            th1.Start();

        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] data = e.Buffer;
            CallClient.instance.sendData(data);
            //bufferedWaveProvider.AddSamples(bytes, 0, bytes.Length);
        }
        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            video = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxMe.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        public byte[] BitmapToByteArray(Bitmap bitmap)
        {
            BitmapData bmpdata = null;
            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;
                Marshal.Copy(ptr, bytedata, 0, numbytes);
                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }
        }
        public Bitmap CopyDataToBitmap(byte[] data, int nX, int nY)
        {
            //Here create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(nX, nY, PixelFormat.Format24bppRgb);
            //Create a BitmapData and Lock all pixels to be written 
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
            //Unlock the pixels
            bmp.UnlockBits(bmpData);
            //Return the bitmap 
            return bmp;
        }
        private void FinalVideo2_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            byte[] arr = BitmapToByteArray(video);
            video2 = CopyDataToBitmap(arr, video.Width, video.Height);
            pictureBoxFriend.Image = video2;
        }
    }
}
