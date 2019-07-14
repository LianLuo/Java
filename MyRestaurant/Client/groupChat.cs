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
    public partial class groupChat : Form
    {
        public Jid roomjid;
        private XmppClientConnection con;

        public groupChat(Jid jid, XmppClientConnection con)
        {
            InitializeComponent();
            this.roomjid = jid;
            this.con = con;
            this.Text = "会议名称:" + jid.User;
        }

        private void groupChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("真的要关闭会议室？", "注意！", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                e.Cancel = false;
                mainForm.Isgroupchat = false;
                mainForm.Islogingroupchat = false;

                //发送退出会议消息给会议中的人
                Presence pre = new Presence();
                pre.Type = PresenceType.unsubscribe;
                pre.To = roomjid;
                con.Send(pre);
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void meetingPresence(object sender, Presence pres)
        {
            //添加登入用户
            if (pres.Type == PresenceType.subscribe)
            {
                if (pres.From.User == this.roomjid.Resource)
                {
                    listView_userList.Items.Add(pres.From.User, 0).Group = listView_userList.Groups[0];
                }
                else
                {
                    listView_userList.Items.Add(pres.From.User, 0).Group = listView_userList.Groups[1];
                }
            }
            //删除退出用户
            if (pres.Type == PresenceType.unsubscribe)
            {
                for (int i = 0; i < listView_userList.Items.Count; i++)
                {
                    if (listView_userList.Items[i].Text == pres.From.User)
                    {
                        listView_userList.Items.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void meetingOnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            rtb_recv.AppendText(msg.From.User + "说：" + msg.Body + "\r\n\r\n");
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            agsXMPP.protocol.client.Message msg=new agsXMPP.protocol.client.Message();
            msg.Type = MessageType.groupchat;
            msg.To = roomjid;
            msg.Body = rtb_send.Text;
            con.Send(msg);

            rtb_send.Text = "";
        }

        private void rtb_recv_TextChanged(object sender, EventArgs e)
        {
            rtb_recv.ScrollToCaret();
        }

        private void rtb_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyValue == 13)
                {
                    e.Handled = true;
                    btn_send_Click(this, null);
                }
            }
        }
    }
}