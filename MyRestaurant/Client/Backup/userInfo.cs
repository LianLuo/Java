using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class userInfo : Form
    {
        Info info = new Info();
        public userInfo(Info _info)
        {
            InitializeComponent();
            this.info = _info;
        }

        private void userInfo_Load(object sender, EventArgs e)
        {
            _userInfo();
        }
        //初始化用户信息
        private void _userInfo()
        {
            lb_name.Text = info.Name;
            lb_sex.Text = info.Sex;
            lb_age.Text = info.Age.ToString();
            lb_group.Text = info.Group;
            lb_tel.Text = info.Tel;
            lb_email.Text = info.Email;
            pictureBox1.Image=il_face.Images[info.FaceId];
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}