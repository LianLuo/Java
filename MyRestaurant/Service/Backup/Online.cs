using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using agsXMPP;
//win.51aspx.com
namespace server
{
    class Online
    {
        static public ArrayList onlineuser=new ArrayList();
        static public ArrayList onlinemeeting=new ArrayList();
    }

    class Meeting
    {
        public Meeting(Jid jid, string password)
        {
            this.jid = jid;
            this.password=password;
        }

        public Jid jid;
        public string password;
        public ArrayList userinmeeting = new ArrayList();
    }
}
