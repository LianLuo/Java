using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace server
{
    public partial class serverfrm : Form
    {
        public serverfrm()
        {
            InitializeComponent();
            agsXMPP.Factory.ElementFactory.AddElementType("Info", "agsoftware:Info", typeof(Info));

        }

        private ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket listener;
        private bool m_Listening;
        private Thread myThread;

        public void ShowRecvMessage(string str)
        {
            richTextBoxshow.SelectionColor = System.Drawing.Color.Red;
            richTextBoxshow.AppendText("接收数据：  ");
            richTextBoxshow.AppendText(str+"\r\n\r\n");
        }

        public void ShowSendMessage(string str)
        {
            richTextBoxshow.SelectionColor = System.Drawing.Color.Blue;
            richTextBoxshow.AppendText("发送数据：  ");
            richTextBoxshow.AppendText(str + "\r\n\r\n");
        }

        private void startserver(object sender, EventArgs e)
        {
            ThreadStart myThreadDelegate = new ThreadStart(Listen);
            myThread = new Thread(myThreadDelegate);
            myThread.Start();
            toolStripStatusLabel1.Text = "服务开启，监听端口"+localEndPoint.Port;
            ToolStripMenuItem.Enabled = false;
        }
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 10000);
        private void Listen()
        {
            

            // Create a TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                m_Listening = true;

                while (m_Listening)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), null);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            // Get the socket that handles the client request.
            Socket newSock = listener.EndAccept(ar);

            agsXMPP.XmppSeverConnection con = new agsXMPP.XmppSeverConnection(this,newSock);
        }

        private void formclosing(object sender, FormClosingEventArgs e)
        {
            if (myThread != null)
            {
                myThread.Abort();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void user_control(object sender, EventArgs e)
        {
            users frm = new users();
            frm.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://win.51aspx.com/CV/IMServerClient");

        }
    }
}