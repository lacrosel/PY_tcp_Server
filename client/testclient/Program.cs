using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace testclient
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        /// 

        internal static bool logincheck = false;
        internal static Socket socket;
        internal static string name;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            if (logincheck)
            {
                Application.Run(new mainform(socket,name));

            }
        }
    }
}
