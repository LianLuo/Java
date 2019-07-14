using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.protocol.client;

namespace client
{
    public partial class frmchat : Form
    {
        public frmchat(string str, XmppClientConnection con)
        {
            InitializeComponent();
            name = str;
            this.con = con;
            this.Text = "与　"+str+" 聊天中";
        }

        public string name;
        private XmppClientConnection con;

        private void frmchat_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (frmchat frm in onlinechatfrm.onlinefrm)
            {
                if (frm.name == this.name)
                {
                    onlinechatfrm.onlinefrm.Remove(this);
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
            msg.To = new Jid(name, "localhost", "resourse");
            msg.Type = MessageType.chat;
            msg.Body = rtb_send.Text;
            con.Send(msg);

            rtb_recv.SelectionFont = new Font(rtb_recv.SelectionFont.FontFamily, 9);
            rtb_recv.SelectionIndent = 5;
            rtb_recv.SelectionColor = Color.Green;
            rtb_recv.AppendText(name + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "\r\n");

            rtb_recv.SelectionFont = new Font(rtb_recv.SelectionFont.FontFamily, 12);
            rtb_recv.SelectionIndent=20;
            rtb_recv.SelectionColor = Color.Black;
            rtb_recv.AppendText(rtb_send.Text + "\r\n");

            rtb_send.Text = "";
        }

        private void rtb_recv_TextChanged(object sender, EventArgs e)
        {
            this.rtb_recv.ScrollToCaret();
        }

        private void rtb_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyValue== 13)
                {
                    e.Handled = true;
                    button1_Click(this,null);
                }
            }
        }
    }
}