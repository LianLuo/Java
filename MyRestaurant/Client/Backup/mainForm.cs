using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.iq.browse;
using agsXMPP.Xml.Dom;

namespace client
{
    public partial class mainForm : Form
    {
        private XmppClientConnection con;
        delegate void OnMessageDelegate(object sender, agsXMPP.protocol.client.Message msg);
        delegate void OnIqDelegate(object sender, Node e);
        delegate void OnPresenceDelegate(object sender, Presence pres);
        delegate void OnMeetingDelegate(object sender, Presence pres);
        static public bool Isgroupchat;
        static public bool Iscreatergroupchat;
        static public bool Islogingroupchat;
        private loading frmload;

        public mainForm()
        {
            InitializeComponent();
            con = new XmppClientConnection();
            frmload = new loading();

            Isgroupchat = false;
            Iscreatergroupchat=false;
            Islogingroupchat = false;
            con.OnReadXml += new XmlHandler(con_OnReadXml);
            con.OnWriteXml += new XmlHandler(con_OnWriteXml);
            con.OnLogin += new ObjectHandler(con_OnLogin);
            con.OnAuthError+=new OnXmppErrorHandler(con_OnAuthError);
            con.OnError += new ErrorHandler(con_OnError);

            //��Ա�б�
            //con.OnRosterStart += new ObjectHandler(con_OnRosterStart);
            con.OnRosterItem += new agsXMPP.XmppClientConnection.RosterHandler(con_OnRosterItem);
            //con.OnRosterEnd+=new ObjectHandler(con_OnRosterEnd);
        
            //��Ϣ����
            con.OnMessage+=new XmppClientConnection.MessageHandler(con_OnMessage);
            //��ϯ��Ϣ
            con.OnPresence += new XmppClientConnection.PresenceHandler(con_OnPresence);
            //������Ϣ
            con.OnIq+=new agsXMPP.Xml.StreamHandler(con_OnIq);
            agsXMPP.Factory.ElementFactory.AddElementType("Info", "agsoftware:Info", typeof(Info));

        }

        private void connect()
        {
            con.Open();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

            login frm = new login(con);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Thread mythread = new Thread(connect);
                mythread.Start();
                frmload.ShowDialog();
            }
            else
            {
                this.Close();
                Application.Exit();
            }
        }

        private  void con_OnLogin(object sender)
        {
            //��������״̬�������û�
            con.Show = ShowType.chat;
            con.SendMyPresence();
            Control.CheckForIllegalCrossThreadCalls = false;
            frmload.Close();
            this.toolStripButton1.Text ="��½�û���"+con.Username+"\n"+"��ǰ״̬������";
        }

        private void con_OnAuthError(object sender, Element e)
        {
            MessageBox.Show("�������");
            Application.Exit();
            System.Diagnostics.Process.Start("client.exe");
        }

        private void con_OnIq(object sender, Node e)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new OnIqDelegate(con_OnIq), new object[] { sender, e });
                return;
            }

            IQ iq = e as IQ;
            if (iq.Id == "loginmeeting")
            {
                if (iq.Type == IqType.result)
                {
                    groupChat frm = new groupChat(iq.From, con);
                    onlinegroupchatfrm.groupchatfrm = frm;
                    frm.Show();
                    //MessageBox.Show("����ɹ���");
                }
                if (iq.Type == IqType.error)
                {
                    MessageBox.Show("�������","ע��");
                    Isgroupchat = false;
                }
            }
            else if (iq.HasTag(typeof(Info)))
            {
                    Info _Info = iq.SelectSingleElement(typeof(Info)) as Info;
                    if (iq.Id == "browse")
                    {
                        userInfo frm = new userInfo(_Info);
                        frm.Show();
                    }
                    if (iq.Id == "edit")
                    {
                        editUserInfo frm = new editUserInfo(_Info,this.con);
                        frm.Show();
                    }
            }
        }

        private  void con_OnError(object sender, Exception ex)
        {
            MessageBox.Show("���ӷ�����ʧ�ܣ�");
            Application.Exit();
            System.Diagnostics.Process.Start("client.exe");
        }

        private  void con_OnReadXml(object sender, string xml)
        {
            Console.WriteLine("���� XML: " + xml);
        }

        private  void con_OnWriteXml(object sender, string xml)
        {
            Console.WriteLine("���� XML: " + xml);
        }
        //���س�Ա�б�
        private void con_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new agsXMPP.XmppClientConnection.RosterHandler(con_OnRosterItem), new object[] { this, item });
                return;
            }
            //���غ����б�
            /*************************************************************************************
             * 2007-05-16   ţ��
             * ���غ����б�   ��������Ϊ���ڵ�ĸ��ڵ�  ��Ա�б�Ϊ���ӽڵ�
             * **********************************************************************************/
            show_usersList(item);
        }
        private void show_usersList(agsXMPP.protocol.Base.RosterItem item)
        {
            //ȡ��Item��group����  ������ǰ��   ����ƥ��ķ���
            //�����    ��ӵ��÷�����ӽڵ�
            //���û��  ��Ӹ÷���  �������û�����÷���
            bool flag = false;
            foreach (TreeNode node in treeView1.Nodes)
            {
                node.Expand();
                if (node.Text == item.FirstChild.Value)
                {
                    TreeNode childnode = new TreeNode(item.Name);
                    node.Nodes.Add(childnode);
                    childnode.ImageIndex = Convert.ToInt32(item.Value)+100;
                    childnode.SelectedImageIndex = Convert.ToInt32(item.Value)+100;
                    flag = true;
                }
            }
            if (!flag)
            {
                TreeNode newnode = new TreeNode(item.FirstChild.Value);
                treeView1.Nodes.Add(newnode);
                newnode.ImageIndex = 0;
                newnode.SelectedImageIndex = 0;

                TreeNode childnode = new TreeNode(item.Name);
                newnode.Nodes.Add(childnode);
                childnode.ImageIndex = Convert.ToInt32(item.Value) + 100;
                childnode.SelectedImageIndex = Convert.ToInt32(item.Value) + 100;
            }
        }

        private void listView_user_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //bool check = true;
            //foreach (frmchat frm in onlinechatfrm.onlinefrm)
            //{
            //    if (frm.name == listView_user.SelectedItems[0].Text)
            //    {
            //        frm.Activate();
            //        check = false;
            //        break;
            //    }
            //}
            //if (check)
            //{
            //    frmchat frm = new frmchat(listView_user.SelectedItems[0].Text, this.con);
            //    onlinechatfrm.onlinefrm.Add(frm);
            //    frm.Show();
            //}
           
        }
        
        private void con_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new OnMessageDelegate(con_OnMessage), new object[] { sender, msg });
                return;
            }
            //�����û���Ե�������Ϣ
            if (msg.Type == MessageType.chat)
            {
                bool check = true;
                foreach (frmchat frm in onlinechatfrm.onlinefrm)
                {
                    if (msg.From.User == frm.name)
                    {
                        check = false;
                        Control.CheckForIllegalCrossThreadCalls = false;

                        frm.rtb_recv.SelectionFont = new Font(frm.rtb_recv.SelectionFont.FontFamily, 9);
                        frm.rtb_recv.SelectionIndent = 5;
                        frm.rtb_recv.SelectionColor = Color.Blue;
                        frm.rtb_recv.AppendText(msg.From.User + " "+ System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "\r\n");

                        frm.rtb_recv.SelectionFont = new Font(frm.rtb_recv.SelectionFont.FontFamily, 12);
                        frm.rtb_recv.SelectionIndent = 20;
                        frm.rtb_recv.SelectionColor = Color.Black;
                        frm.rtb_recv.AppendText(msg.Body + "\r\n");
                        break;
                    }
                }

                if (check)
                {
                    frmchat frm = new frmchat(msg.From.User, con);
                    frm.Show();
                    onlinechatfrm.onlinefrm.Add(frm);

                    frm.rtb_recv.SelectionFont = new Font(frm.rtb_recv.SelectionFont.FontFamily, 9);
                    frm.rtb_recv.SelectionIndent = 5;
                    frm.rtb_recv.SelectionColor = Color.Blue;
                    frm.rtb_recv.AppendText(msg.From.User + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "\r\n");

                    frm.rtb_recv.SelectionFont = new Font(frm.rtb_recv.SelectionFont.FontFamily, 12);
                    frm.rtb_recv.SelectionIndent = 20;
                    frm.rtb_recv.SelectionColor = Color.Black;
                    frm.rtb_recv.AppendText(msg.Body + "\r\n");
                }
            }
            //����������Ϣ
            if (msg.Type == MessageType.groupchat)
            {
                if (Iscreatergroupchat)
                {
                    onlinegroupchatfrm.creatergroupchatfrm.meetingOnMessage(this, msg);
                }
                else
                {
                    onlinegroupchatfrm.groupchatfrm.meetingOnMessage(this, msg);
                }
            }
        }

        private void con_OnPresence(object sender, Presence pres)
        {
            if (InvokeRequired)
            {			
                BeginInvoke(new OnPresenceDelegate(con_OnPresence), new object[] { sender, pres });
                return;
            }
            //�û�������Ϣ
            if (pres.Show == ShowType.chat)
            {
                foreach (TreeNode node in treeView1.Nodes)
                {
                    foreach (TreeNode childnode in node.Nodes)
                    {
                        if (childnode.Text == pres.From.User)
                        {
                            if (childnode.ImageIndex > 100)
                            {
                                childnode.ImageIndex -= 100;
                                childnode.SelectedImageIndex -= 100;
                            }
                            break;
                        }
                    }
                }
            }
            //�û�������Ϣ
            else if (pres.Type == PresenceType.unavailable)
            {
                foreach (TreeNode node in treeView1.Nodes)
                {
                    foreach (TreeNode childnode in node.Nodes)
                    {
                        if (childnode.Text == pres.From.User)
                        {
                            if (childnode.ImageIndex <= 100)
                            {
                                childnode.ImageIndex += 100;
                                childnode.SelectedImageIndex += 100;
                            }
                            break;
                        }
                    }
                }
            }
            //���鴴����Ϣ
            else if (pres.Type == PresenceType.probe)
            {
                string[] str={pres.From.User,pres.From.Resource};
                ListViewItem item = new ListViewItem(str, 1);
                listView_onlineroom.Items.Add(item);
            }
            //����ȡ����Ϣ
            else if (pres.Type == PresenceType.invisible)
            {
                for (int i = 0; i < listView_onlineroom.Items.Count; i++)
                {
                    if (listView_onlineroom.Items[i].Text == pres.From.User && listView_onlineroom.Items[i].SubItems[1].Text == pres.From.Resource)
                    {
                        listView_onlineroom.Items.RemoveAt(i);
                        break;
                    }
                }
                if (Islogingroupchat)
                {
                    if (onlinegroupchatfrm.groupchatfrm != null)
                    {
                        if (onlinegroupchatfrm.groupchatfrm.roomjid.Equals(pres.From))
                        {
                            MessageBox.Show("���鱻�����߹رգ����鴰�ڽ��˳���", "ע��");
                            onlinegroupchatfrm.groupchatfrm.Dispose();
                            Isgroupchat = false;
                        }
                    }
                }
            }
            //�û����������Ϣ
            else if (pres.Type == PresenceType.subscribe)
            {
                if (Iscreatergroupchat)
                {
                    onlinegroupchatfrm.creatergroupchatfrm.meetingPresence(this, pres);
                }
                else
                {
                    onlinegroupchatfrm.groupchatfrm.meetingPresence(this,pres);
                }
            }
            //�û��˳�������Ϣ
            else if (pres.Type == PresenceType.unsubscribe)
            {
                if (Iscreatergroupchat)
                {
                    onlinegroupchatfrm.creatergroupchatfrm.meetingPresence(this, pres);
                }
                else
                {
                    onlinegroupchatfrm.groupchatfrm.meetingPresence(this, pres);
                }
            }
        }
        private void createMeeting(object sender, EventArgs e)
        {
            if (!Isgroupchat)
            {
                createmeeting frm = new createmeeting();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Isgroupchat = true;
                    Iscreatergroupchat = true;
                    Browse browse = new Browse();
                    browse.Value = room.roompwd;
                    IQ iq = new IQ();
                    iq.AddChild(browse);
                    iq.Type = IqType.set;
                    iq.To = new Jid(room.roomname, "localhost", con.Username);
                    con.Send(iq);

                    creatergroupChat creatergroupfrm = new creatergroupChat(iq.To, con);
                    onlinegroupchatfrm.creatergroupchatfrm = creatergroupfrm;
                    creatergroupfrm.Show();

                    Presence pre = new Presence();
                    pre.From = new Jid(con.Username, "localhost", "Resource");
                    pre.Type = PresenceType.subscribe;
                    onlinegroupchatfrm.creatergroupchatfrm.meetingPresence(this,pre);
                }
            }
            else
            {
                MessageBox.Show("���Ѿ�����һ�����鵱�У����ܽ��������ң�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_onlineroom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Isgroupchat)
            {
                logingroupchat frm = new logingroupchat();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Isgroupchat = true;
                    Islogingroupchat = true;
                    Browse browse = new Browse();
                    browse.Value = loginroom.roompwd;
                    IQ iq = new IQ();
                    iq.AddChild(browse);
                    iq.Type = IqType.get;
                    iq.Id = "loginmeeting";
                    iq.To = new Jid(listView_onlineroom.SelectedItems[0].Text, "localhost", listView_onlineroom.SelectedItems[0].SubItems[1].Text);
                    con.Send(iq);
                }
            }
            else
            {
                MessageBox.Show("���Ѿ�����һ�����鵱�У������ټ�������ң�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //���˫���ӽ�㣬��ʼ�����촰��
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool check = true;
             TreeNode tn = this.treeView1.GetNodeAt(e.X, e.Y);
             if (tn != null && tn.IsSelected && tn.Level != 0 && e.Button == MouseButtons.Left)
             {
                 foreach (frmchat frm in onlinechatfrm.onlinefrm)
                 {
                     if (frm.name == tn.Text)
                     {
                         frm.Activate();
                         check = false;
                         break;
                     }
                 }
                 if (check)
                 {
                     frmchat frm = new frmchat(tn.Text, this.con);
                     onlinechatfrm.onlinefrm.Add(frm);
                     frm.Show();
                 }
             }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode tn = this.treeView1.GetNodeAt(e.X, e.Y);
            treeView1.SelectedNode = tn;
        }

        private void userInfo(object sender, EventArgs e)
        {
            /*agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
            Info userInfo = new Info();
            userInfo.Name=treeView1.SelectedNode.Text;
            msg.AddChild(userInfo);
            con.Send(msg);
             */
            IQ iq = new IQ();
            Info userInfo = new Info();
            userInfo.Name = treeView1.SelectedNode.Text;
            iq.AddChild(userInfo);
            iq.Id = "browse";
            iq.Type = IqType.get;
            con.Send(iq);
        }

        private void �޸ĸ�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IQ iq = new IQ();
            Info userInfo = new Info();
            userInfo.Name = con.Username;
            iq.AddChild(userInfo);
            iq.Id = "edit";
            iq.Type = IqType.get;
            con.Send(iq);
        }
    }
}