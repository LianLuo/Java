using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using server;
using agsXMPP.protocol;
using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.auth;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.browse;
using agsXMPP.protocol.client;
using agsXMPP.protocol.x;
using agsXMPP.Xml;
using agsXMPP.Xml.Dom;
using System.Windows.Forms;
using System.Data;

namespace agsXMPP
{
	public class XmppSeverConnection
	{
		#region << Constructors >>
		public XmppSeverConnection()
		{		
			streamParser = new StreamParser();
			streamParser.OnStreamStart		+= new StreamHandler(streamParser_OnStreamStart);
			streamParser.OnStreamEnd		+= new StreamHandler(streamParser_OnStreamEnd);
			streamParser.OnStreamElement	+= new StreamHandler(streamParser_OnStreamElement);	
            
		}

        public XmppSeverConnection(serverfrm a, Socket sock)
            : this()
		{	
			m_Sock = sock;
            frm = a;
			m_Sock.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReadCallback), null);		
		}
		#endregion
			
		private StreamParser			streamParser;
		public Socket					m_Sock;
        private const int BUFFERSIZE = 1024;
        private byte[] buffer = new byte[BUFFERSIZE];
        private serverfrm frm;
        public Jid jid;
        public delegate void mydelegate(string str);
	
		public void ReadCallback(IAsyncResult ar) 
		{        
            try
            {
                int bytesRead = m_Sock.EndReceive(ar);

                if (bytesRead > 0)
                {
                    streamParser.Push(buffer, 0, bytesRead);

                    m_Sock.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReadCallback), null);
                }
                else
                {
                    m_Sock.Shutdown(SocketShutdown.Both);
                    m_Sock.Close();
                }
            }
            catch
            {
                deluser();
            }
		}

		public void Send(string data) 
		{
            try
            {
                byte[] byteData = Encoding.UTF8.GetBytes(data);
                //发送数据给客户端
                frm.BeginInvoke(new mydelegate(frm.ShowSendMessage), new Object[] { data });
                m_Sock.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), null);
            }
            catch
            { }
		}

        public void SendCallback(IAsyncResult ar) 
		{
			try 
			{
				int bytesSent = m_Sock.EndSend(ar);
				Console.WriteLine("Sent {0} bytes to client.", bytesSent);

			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}
	
		
		public void Stop()
		{
			Send("</stream:stream>");
			m_Sock.Shutdown(SocketShutdown.Both);
			m_Sock.Close();
		}
			
		
		#region << Properties and Member Variables >>
//		private int			m_Port			= 5222;		
		private string		m_SessionId		= null;

		public string SessionId
		{
			get
			{
				return m_SessionId;
			}
			set
			{
				m_SessionId = value;
			}
		}
		#endregion

		private void streamParser_OnStreamStart(object sender, Node e)
		{
			SendOpenStream();
		}

		private void streamParser_OnStreamEnd(object sender, Node e)
		{
            deluser();
		}

        private void deluser()
        {
            frm.listViewOnlineUser.Items.Remove(frm.listViewOnlineUser.FindItemWithText(jid.User));
            foreach (XmppSeverConnection con in Online.onlineuser)
            {
                if (con.jid.User == jid.User)
                {
                    Online.onlineuser.Remove(con);
                    break;
                }
            }

            Presence pre;
            pre = new Presence();
            pre.Type = PresenceType.unavailable;
            pre.From = jid;
            try
            {
                foreach (XmppSeverConnection con in Online.onlineuser)
                {
                    con.Send(pre);
                }
            }
            catch
            { }
        }

		private void streamParser_OnStreamElement(object sender, Node e)
		{
            frm.BeginInvoke(new mydelegate(frm.ShowRecvMessage), new Object[] { e.ToString() });
            Console.WriteLine("OnStreamElement: " + e.ToString());
			if (e.GetType() == typeof(Presence))
			{
                Presence pres=e as Presence;

                //处理会议室被取消消息
                if(pres.Type==PresenceType.invisible)
                {
                    foreach(Meeting meeting in Online.onlinemeeting)
                    {
                        if (meeting.jid.Equals(pres.To))
                        {
                            if (this.jid.User == pres.To.Resource)
                            {
                                Online.onlinemeeting.Remove(meeting);
                                pres.From = pres.To;
                                foreach (XmppSeverConnection con in Online.onlineuser)
                                {
                                    pres.To = con.jid;
                                    con.Send(pres);
                                }
                                break;
                            }
                        }
                    }
                }
                //处理用户上线消息
                if (pres.Show == ShowType.chat)
                {
                    pres.From = this.jid;
                    foreach (XmppSeverConnection con in Online.onlineuser)
                    {
                        if (con.jid.User != this.jid.User)
                        {
                        pres.To = con.jid;
                        con.Send(pres);
                        }
                    }
                }
                //处理用户退出会议消息
                if (pres.Type == PresenceType.unsubscribe)
                {
                    foreach (Meeting meeting in Online.onlinemeeting)
                    {
                        if (pres.To.Equals(meeting.jid))
                        {
                            meeting.userinmeeting.Remove(this.jid);
                            pres.From = this.jid;
                            foreach (Jid jd2 in meeting.userinmeeting)
                            {
                                foreach (XmppSeverConnection con in Online.onlineuser)
                                {
                                    if (jd2.Equals(con.jid))
                                    {
                                        con.Send(pres);
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
			}
			else if (e.GetType() == typeof(agsXMPP.protocol.client.Message))
			{
                 agsXMPP.protocol.client.Message msg = e as agsXMPP.protocol.client.Message;
                 //路由点对点聊天消息
                 if (msg.Type == MessageType.chat)
                 {
                     foreach (XmppSeverConnection con in Online.onlineuser)
                     {
                         if (con.jid.User == msg.To.User)
                         {
                             msg.From = jid;
                             con.Send(msg);
                         }
                     }
                 }
                 //路由群聊消息
                 if (msg.Type == MessageType.groupchat)
                 {
                     foreach (Meeting meeting in Online.onlinemeeting)
                     {
                         if (msg.To.Equals(meeting.jid))
                         {
                             msg.From = this.jid;
                             foreach (Jid jd2 in meeting.userinmeeting)
                             {
                                 foreach (XmppSeverConnection con in Online.onlineuser)
                                 {
                                     if (jd2.Equals(con.jid))
                                     {
                                         con.Send(msg);
                                         break;
                                     }
                                 }
                             }
                             break;
                         }
                     }
                 }
			}
			else if (e.GetType() == typeof(IQ))
			{
				ProcessIQ(e as IQ);
			}
		}

		private void ProcessIQ(IQ iq)
		{
            //好友信息查询
            if (iq.HasTag(typeof(Info)))
            {
                if (iq.Type == IqType.get)
                {
                    Info _Info = iq.SelectSingleElement(typeof(Info)) as Info;
                    DataTable dt = usersTableAdapter.selectUser_byname(_Info.Name);
                    DataTable dt_group = groupTableAdapter.select_group();
                    iq.SwitchDirection();
                    iq.Type = IqType.result;

                    _Info.Name = dt.Rows[0][0].ToString();
                    _Info.FaceId = Convert.ToInt32(dt.Rows[0][2]);
                    _Info.Sex = dt.Rows[0][3].ToString();
                    _Info.Age = Convert.ToInt32(dt.Rows[0][4]);
                    for (int i = 0; i < dt_group.Rows.Count; i++)
                    {
                        if (dt_group.Rows[i][0].Equals(dt.Rows[0][5]))
                            _Info.Group = dt_group.Rows[i][1].ToString();
                    }
                    _Info.Tel = dt.Rows[0][6].ToString();
                    _Info.Email = dt.Rows[0][7].ToString();
                    Send(iq);
                    dt.Dispose();
                    dt_group.Dispose();
                }
                if (iq.Type == IqType.set)
                {
                    Info setInfo = iq.SelectSingleElement(typeof(Info)) as Info;
                    if (setInfo.Name == jid.User)
                    {
                        DatabaseDataSet databaseDataSet = new DatabaseDataSet();
                        usersTableAdapter.Update_userInfo(setInfo.Pwd, setInfo.FaceId, setInfo.Sex, setInfo.Age, setInfo.Tel, setInfo.Email, setInfo.Name);
                        usersTableAdapter.Update(databaseDataSet.users);
                        //修改成功
                    }
                }
            }
            if(iq.Query!=null)
            {
                //处理用户认证
			    if(iq.Query.GetType() == typeof(Auth))
			    {
				    Auth auth = iq.Query as Auth;
                    switch (iq.Type)
                    {
                        case IqType.get:
                            iq.SwitchDirection();
                            iq.Type = IqType.result;
                            auth.AddChild(new Element("password"));
                            auth.AddChild(new Element("digest"));
                            Send(iq);
                            break;
                        case IqType.set:
                            this.jid = new Jid(auth.Username, "localhost", "Resource");
                            //用户登陆认证
                            try
                            {
                                DataTable dt_auth = usersTableAdapter.selectUser_byname(auth.Username);
                                string str = util.Hash.Sha1Hash(this.SessionId + dt_auth.Rows[0][1].ToString());
                                if (auth.Digest == str)
                                {
                                    bool flag = false;//表示不存在
                                    foreach (XmppSeverConnection con in Online.onlineuser)
                                    {
                                        if (con.jid.User == auth.Username)
                                        {
                                            flag = true;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        Online.onlineuser.Add(this);
                                        int itemNumber = frm.listViewOnlineUser.Items.Count;
                                        string[] subItem0 ={ auth.Username, m_Sock.RemoteEndPoint.ToString() };
                                        frm.listViewOnlineUser.Items.Insert(itemNumber, new ListViewItem(subItem0));

                                        iq.SwitchDirection();
                                        iq.Type = IqType.result;
                                        iq.Query = null;
                                        Send(iq);
                                    }
                                }
                                else
                                {
                                    iq.SwitchDirection();
                                    iq.Type = IqType.error;
                                    iq.Query = null;
                                    Send(iq);
                                }
                            }
                            catch (Exception ee)
                            { 
                            }
                            break;
                    }
			    }
                //处理用户列表与在线用户的发送
			    else if(iq.Query.GetType() == typeof(Roster))
			    {
				    ProcessRosterIQ(iq);
			    }
                //处理会议消息
                else if (iq.Query.GetType() == typeof(Browse))
                {
                    switch (iq.Type)
                    {
                        case IqType.get:
                            //加入会议室
                            foreach(Meeting meeting in Online.onlinemeeting)
                            {
                                if (meeting.jid.Equals(iq.To))
                                {
                                    if (iq.Query.Value == meeting.password)
                                    {
                                        iq.Type = IqType.result;
                                        iq.From = iq.To;
                                        this.Send(iq);


                                        //将会议中的参与者发给他
                                        Presence presence = new Presence();
                                        presence.Type = PresenceType.subscribe;
                                        foreach(Jid jd in meeting.userinmeeting)
                                        {
                                            presence.From = jd;
                                            this.Send(presence);
                                        }
                                        
                                        meeting.userinmeeting.Add(this.jid);
                                        //将他参与会议的消息发给所有会议中的参与者
                                        presence.From = this.jid;
                                        foreach (Jid jd2 in meeting.userinmeeting)
                                        {
                                            foreach (XmppSeverConnection con in Online.onlineuser)
                                            {
                                                if (jd2.Equals(con.jid))
                                                {
                                                    con.Send(presence);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        iq.From = iq.To;
                                        iq.Type = IqType.error;
                                        this.Send(iq);
                                    }
                                    break;
                                }
                            }
                            break;

                        case IqType.set:
                            //建立会议室
                            Meeting meeting2 = new Meeting(iq.To, iq.Query.Value);
                            meeting2.userinmeeting.Add(this.jid);
                            Online.onlinemeeting.Add(meeting2);
                            //将新建的会议室通知所有人
                            Presence pre = new Presence();
                            pre.Type = PresenceType.probe;
                            pre.From = iq.To;

                            foreach (XmppSeverConnection con in Online.onlineuser)
                            {
                                con.Send(pre);
                            }
                            break;
                    }
                }
                    
            }
        
		}

		private void ProcessRosterIQ(IQ iq)
		{
			if (iq.Type == IqType.get)
			{
				// 发送用户列表
                getRosterItem(iq);
				Send(iq);

                //发送所有在线人及在线会议室的消息给他
                Presence pre;
                pre = new Presence();
                pre.Show = ShowType.chat;
                foreach (XmppSeverConnection con in Online.onlineuser)
                {
                    pre.From = con.jid;
                    Send(pre);
                }
                //将他在线消息发给所有在线人
                Presence pre1 = new Presence();
                pre1.Type = PresenceType.probe;
                foreach (Meeting meeting in Online.onlinemeeting)
                {
                    pre1.From = meeting.jid;
                    Send(pre1);
                }
			}
		}
        /*************************************************************
        * 2007-05-16   牛坤
        * 查询DataSet  即  得到用户列表   发送个登陆用户
        * 
        *用户登录验证 
        *************************************************************/
        #region  得到用户列表

        server.DatabaseDataSetTableAdapters.usersTableAdapter usersTableAdapter = new server.DatabaseDataSetTableAdapters.usersTableAdapter();
        server.DatabaseDataSetTableAdapters.groupTableAdapter groupTableAdapter = new server.DatabaseDataSetTableAdapters.groupTableAdapter();

        private IQ getRosterItem(IQ iq)
        {
            DataTable dt_group = groupTableAdapter.select_group();
            DataTable dt_users = usersTableAdapter.select_users();
            iq.SwitchDirection();
            iq.Type = IqType.result;
            for (int i = 0; i < dt_users.Rows.Count; i++)
            {
                RosterItem ri = new RosterItem();
                ri.Name = dt_users.Rows[i][0].ToString();
                ri.Subscription = SubscriptionType.both;
                ri.Jid = new Jid(ri.Name + "@localhost");
                for (int j = 0; j < dt_group.Rows.Count; j++)
                {
                    if (dt_group.Rows[j][0].Equals(dt_users.Rows[i][5]))
                        ri.AddGroup(dt_group.Rows[j][1].ToString());
                }
                ri.Value = dt_users.Rows[i][2].ToString();
                iq.Query.AddChild(ri);
            }
            return iq;
        }
        #endregion
		private void SendOpenStream()
		{
			// Send the Opening Strem to the client
			string ServerDomain = "localhost";
			
			this.SessionId = agsXMPP.SessionId.CreateNewId();
			
			
			StringBuilder sb = new StringBuilder();

			sb.Append( "<stream:stream from='");
			sb.Append( ServerDomain );
			
			sb.Append( "' xmlns='" );
			sb.Append( Uri.CLIENT );
			
			sb.Append( "' xmlns:stream='" );
			sb.Append( Uri.STREAM );
			
			sb.Append( "' id='" );
			sb.Append( this.SessionId );
			
			sb.Append( "'>" );

			Send( sb.ToString() );
		}

		private void Send(Element el)
		{
			Send(el.ToString());
		}
	}
}