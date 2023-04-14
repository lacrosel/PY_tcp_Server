using Lucene.Net.Index;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;



namespace testclient
{
    public partial class mainform : Form
    {
        //lock
        private object loc = new object();

        //서버 연결
        SCOMM sCOMM = new SCOMM();
        Socket serv_sock;
        string userName;


        //cam 파트
        private Thread camera;
        bool isCameraRunning = false;
        MemoryStream ms;
        VideoCapture capture;
        Mat frame;
        Bitmap image;



        //recv 파트
        private Thread recvthread;
        static bool recvrunning = false;

        byte[] septers;
        byte[] septers2;
        byte[] datalen;
        byte[] SEGS;

        bool alertsignal = false;

        public mainform(Socket serv_soc, string name)
        {
            InitializeComponent();

            serv_sock = serv_soc;
            userName = name;
        }
        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void CaptureCamera() //캠 스레드 함수
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }
        private void CaptureCameraCallback() //캠 콜백함수
        {
            frame = new Mat();
            capture = new VideoCapture();
            capture.FrameWidth = 320;
            capture.FrameHeight = 240;
            capture.Open(0);

            while (isCameraRunning)
            {
                capture.Read(frame);
                if (!frame.Empty())
                {
                    image = BitmapConverter.ToBitmap(frame);
                    //이미지 출력
                    pbox_mine.Image = image;

                    //구분자
                    septers = BitConverter.GetBytes(1);
                    septers = BitConverter.GetBytes(1);
                    //이미지데이터 지정
                    SEGS = frame.ToBytes(".png");
                    //데이터 길이
                    Int32 comma = SEGS.Length;
                    datalen = BitConverter.GetBytes(comma);


                    //채팅 senddata 생성 - [sept,len,data]순으로 바이트배열 생성
                    Byte[] data = septers.Concat(septers).Concat(datalen).Concat(SEGS).ToArray();
                    //Console.WriteLine($"datalength : {data.Length}");

                    // 데이터 보내기
                    serv_sock.Send(data, data.Length, 0);

                }
                Thread.Sleep(50);
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.ShiftKey)
            {
                Console.WriteLine("yes");
            }
            else if (e.KeyValue == (int)Keys.ShiftKey)
            {
                if (pbcheck())
                {
                    List<int> list1 = new List<int>() { 1, 3, 7, 9 };

                    var rnd = new Random(1465);
                    var randomized = list1.OrderBy(item => rnd.Next());
                    PictureBox[] pbox = { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9 };
                    for (int i = 0; i < 4; i++)
                    {
                        pbox[list1[i] - 1].Visible = true;
                        pbox[list1[i] - 1].BackColor = Color.Red;
                    }
                    while (pbcheck() == false)
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\im.wav");
                        player.Play();
                        pictureBox1.BackColor = Color.Red;
                        Delay(1000);
                    }


                }
            }
            
        }
        
        private void checker_Streaming(object sender, EventArgs e)
        {
            Bitmap img;

            if (btn_stream.Text.Equals("Start"))
            {
                recvrunning = true;
                recvthread = new Thread(new ThreadStart(recvfuntion));
                recvthread.Start();
                Console.WriteLine("==  CONNECTED  ==");

                CaptureCamera();
                btn_stream.Text = "Stop";
                isCameraRunning = true;

            }
            else
            {
                if (capture.IsOpened())
                {
                    //PictureBox pictureBox = new PictureBox();
                    //img = new Bitmap(@"C:\Users\1\Desktop\0327\newserver\testclient\testclient\phone_x.PNG");
                    //pbox_mine.Image = (Image)img;
                    capture.Release();

                }
                btn_stream.Text = "Start";
                isCameraRunning = false;

            }


        }

        private void server_disConnect() //서버 연결해제
        {
            recvrunning = false;
            Thread.Sleep(2000);

            Console.WriteLine("==  DISCONNECTED  ==");
            serv_sock.Close();
        }

        private void recvfuntion()
        {
            while (recvrunning)
            {
                int startidx = 0;
                byte[] recved = new byte[512];
                int bytesReceived;
                try
                {
                    bytesReceived = serv_sock.Receive(recved);
                }
                catch (SocketException) { return; }
                Console.WriteLine($"bytesReceived : {bytesReceived}");
                int septer = BitConverter.ToInt32(recved, startidx);
                startidx += sizeof(Int32);
                int dataSize = BitConverter.ToInt32(recved, startidx);
                startidx += sizeof(Int32);
                byte[] recvbuffer = new byte[dataSize];

                int totalRecv = bytesReceived - startidx;
                //Console.WriteLine($"totalRecv : {totalRecv}");
                //Array.Copy(recvbuffer, 0, recved, startidx, totalRecv);
                //바이트배열 카피
                Buffer.BlockCopy(recved, startidx, recvbuffer, 0, totalRecv);
                int recvLen =0;
                while (totalRecv < dataSize) //전송받은 길이만큼 반복적으로 버퍼에 입력
                {
                    //수신                    
                    try
                    {
                        recvLen = serv_sock.Receive(recvbuffer, totalRecv, dataSize - totalRecv, 0);
                    }
                    catch (SocketException) { return; }
                    //반복종료
                    if (recvLen <= 0)
                    {
                        break;
                    }
                    //이번 타임에 받은 길이를 총 길이에 더해서 버퍼 인덱스 변경
                    totalRecv += recvLen;
                }

                //구분자 식별파트
                if (septer == 1)// alert
                {
                    try
                    {
                        Console.WriteLine(septer);
                        if (alertsignal) { continue; } //알림중일시 넘기기
                        testfunc();
                        string signaltext = recvbuffer.ToString();
                        
                        
                        if (signallog.InvokeRequired)
                        {
                            signallog.Invoke(new MethodInvoker(delegate ()
                            {
                                signallog.Items.Add(signaltext);
                            }));
                        }
                        else
                        {
                            signallog.Items.Add(signaltext);
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e);
                    }


                }
            }
        }

        private void testfunc()
        {
            if (pbcheck())
            {
                List<int> list1 = new List<int>() { 1, 3, 7, 9 };

                var rnd = new Random(1465);
                var randomized = list1.OrderBy(item => rnd.Next());
                PictureBox[] pbox = { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9 };
                for (int i = 0; i < 4; i++)
                {
                    if (pbox[list1[i] - 1].InvokeRequired)
                    {
                        signallog.Invoke(new MethodInvoker(delegate ()
                        {
                            pbox[list1[i] - 1].Visible = true;
                        }));
                    }
                    else
                    {
                        pbox[list1[i] - 1].Visible = true;
                    }
                    pbox[list1[i] - 1].BackColor = Color.Red;
                }

                if (pbcheck() == false)
                { 
                    pictureBox1.BackColor = Color.Red;
                    alertsignal = true;

                    Thread Alert_thread = new Thread(new ThreadStart(testalert));
                }


            }
        }
        private void testalert()
        {
            while (alertsignal)
            {
                Console.WriteLine("alalalalalalalalalal");
                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testfunc();
        }
        private bool pbcheck()
        {
            PictureBox[] pbox = { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9 };
            for (int i = 0; i < 9; i++)
            {
                if(pbox[i].Visible==true)
                {
                    return false;
                }                
            }
            return true;
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            pb1.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }

        }

        private void pb2_Click(object sender, EventArgs e)
        {
            pb2.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            pb3.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            pb4.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb5_Click(object sender, EventArgs e)
        {
            pb5.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb6_Click(object sender, EventArgs e)
        {
            pb6.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb7_Click(object sender, EventArgs e)
        {
            pb7.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb8_Click(object sender, EventArgs e)
        {
            pb8.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }

        private void pb9_Click(object sender, EventArgs e)
        {
            pb9.Visible = false;
            if (pbcheck())
            {
                pictureBox1.BackColor = Color.Lime;
                alertsignal = false;
            }
        }
    }

}
