using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class pwd : Form
    {
        string Password;
        Info info;
        public pwd(string pwd, Info info)
        {
            InitializeComponent();
            this.Password = pwd;
            this.info = info;
        }

        private void pwd_Load(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tbx_old.Text == Password)
            {
                if (tbx_new.Text == tbx_renew.Text)
                {
                    info.Pwd = tbx_new.Text;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("�Բ���������������벻һ�£�");
                }
            }
            else
            {
                MessageBox.Show("�Բ���ԭ���벻��ȷ��");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}