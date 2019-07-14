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
    public partial class editUserInfo : Form
    {
        private XmppClientConnection con;
        Info info = new Info();
        public editUserInfo(Info _info, XmppClientConnection con)
        {
            InitializeComponent();
            this.info = _info;
            this.con = con;
        }

        private void _userInfo()
        {
            lb_name.Text = info.Name;
            comboBox_sex.Text = info.Sex;
            lb_age.Text = info.Age.ToString();
            lb_group.Text = info.Group;
            lb_tel.Text = info.Tel;
            lb_email.Text = info.Email;
            pictureBox1.Image = il_face.Images[info.FaceId];
        }

        private void editUserInfo_Load(object sender, EventArgs e)
        {
            this._userInfo();
            info.Pwd = con.Password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseface choose = new chooseface(info.FaceId);
            if (DialogResult.OK == choose.ShowDialog())
            {
                info.FaceId = choose.index;
                pictureBox1.Image = il_face.Images[info.FaceId];
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            info.Sex = comboBox_sex.Text;
            info.Age = Convert.ToInt32(lb_age.Text);
            info.Tel = lb_tel.Text;
            info.Email = lb_email.Text;

            IQ iq = new IQ();
            iq.AddChild(info);
            iq.Type = IqType.set;
            con.Send(iq);

            this.Close();
            this.Dispose();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            //修改密码
            pwd frm = new pwd(con.Password, info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(info.Pwd);
            }
            if (frm.DialogResult == DialogResult.Cancel)
            {
                info.Pwd = con.Password;
                //MessageBox.Show(info.Pwd);
            }
        }

    }
}