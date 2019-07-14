using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using agsXMPP;

namespace client
{
    public partial class login : Form
    {
        private XmppClientConnection connection;

        public login(XmppClientConnection con)
        {
            InitializeComponent();
            connection = con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Username = tbx_user.Text;
            connection.Server = tbx_server.Text;
            connection.Password = tbx_pwd.Text;
            connection.Port = 10000;
            connection.Resource = "Resource";

            this.DialogResult = DialogResult.OK;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}