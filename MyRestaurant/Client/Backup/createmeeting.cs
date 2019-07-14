using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class createmeeting : Form
    {
        public createmeeting()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tbx_name.Text != "" && tbx_pwd.Text == tbx_repwd.Text)
            {
                room.roomname = tbx_name.Text;
                room.roompwd = tbx_pwd.Text;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("�������������Ϣ���������Ʋ���Ϊ�գ������������������ȣ�", "����", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}