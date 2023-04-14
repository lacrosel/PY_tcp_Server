using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace testclient
{
    public partial class Form1 : Form
    {
        //서버 연결
        SCOMM sCOMM = new SCOMM();
        Socket serv_sock;
        string userName;
        string ipName;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_servconnect_Click(object sender, EventArgs e)
        {
           

            bool check = server_Connect();
            if (check)
            {
                Program.name = userName;
                Program.socket = serv_sock;
                Program.logincheck = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("연결실패");
            }
           
            
            
        }
        private bool server_Connect() // 서버연결
        {
            // 이름 미설정시 연결 x
            if (lbl_inname.Text.Equals(""))
            {
                return false;
            }
            userName = lbl_inname.Text;

            ipName = textBox1.Text;
            int PORT = 9999;
            serv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serv = new IPEndPoint(IPAddress.Parse(ipName), PORT);

            serv_sock.Connect(serv);

            return true;

         


        }


    }
}
