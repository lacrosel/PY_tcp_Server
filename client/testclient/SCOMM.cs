using System;
using System.Net.Sockets;
using System.Text;

namespace testclient
{
    public class SCOMM
    {
        Socket serv_sock;

        public void Send_Data(Socket sock, string text)
        {
            string send_data = text.Trim();                         //문자열 앞, 뒤 공백 제거
            int length = Encoding.UTF8.GetByteCount(send_data);     //바이트단위 길이
            byte[] send_byte = new byte[length];                    //길이만큼 바이트 할당


            //send_byte = Encoding.UTF8.GetBytes(send_data);
            send_byte = Encoding.Default.GetBytes(send_data);
            sock.Send(send_byte, 0);

        }


        //======================= 문자열 수신 ============================
        public string Recv_Data(Socket sock)
        {
            string recv_data = null;
            byte[] recv_byte = new byte[1024];
            int length = 0;


            length = sock.Receive(recv_byte);
            //Console.WriteLine(recv_byte);
            //recv_data = Encoding.UTF8.GetString(recv_byte, 0, length);
            recv_data = Encoding.Default.GetString(recv_byte, 0, length);

            return recv_data;
        }
    }
}
