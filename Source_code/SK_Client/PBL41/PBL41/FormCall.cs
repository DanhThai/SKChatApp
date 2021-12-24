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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL41
{
    public partial class FormCall : Form
    {     
        public VideoFileWriter FileWriter = new VideoFileWriter();
        WaveIn waveIn;
        WaveOut waveOut;
        BufferedWaveProvider bufferedWaveProvider;
        public string name { get; set; }
        public string name_friend { get; set; }
        public FormCall(string _name, string _name_friend)
        {
            name = _name;
            name_friend = _name_friend;
            InitializeComponent();
            btnStartMicro.Visible = false;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            ChatClient.instance.SendEndCall();
            this.Close();
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

            lbMe.Text = name;
            lbYou.Text = name_friend;
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
        public object DeserializeData(byte[] theByteArray)
        {
            BinaryFormatter bf1 = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(theByteArray);
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
    }
}
