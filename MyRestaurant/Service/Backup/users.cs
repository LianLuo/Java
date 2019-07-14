using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace server
{
    /****************************************************
     * ţ��  2007-05-15                                 *
     *��ȡ���ݿ��е���Ա�б���TreeView���ղ��ŷ�����ʾ*
     *                                                  *
     ***************************************************/   
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }
        DatabaseDataSetTableAdapters.groupTableAdapter groupTableAdapter = new server.DatabaseDataSetTableAdapters.groupTableAdapter();
        DatabaseDataSetTableAdapters.usersTableAdapter usersTableAdapter = new server.DatabaseDataSetTableAdapters.usersTableAdapter();

        private void users_Load(object sender, EventArgs e)
        {
            fillComboBox();
            readUsersTree();
            pictureBox1.Image=il_face.Images[1];
        }
        private void fillComboBox()
        {
            // TODO: ���д��뽫���ݼ��ص���databaseDataSet.group���С������Ը�����Ҫ�ƶ����Ƴ�����
            this.groupTableAdapter1.Fill(this.databaseDataSet.group);
        }
        #region ��ȡ���ݿ��еĳ�Ա�����ʾ

        private void readUsersTree()
        {
            DataTable dt_group = groupTableAdapter.select_group();
            DataTable dt_users = usersTableAdapter.select_users();
            for (int i = 0; i < dt_group.Rows.Count; i++)
            {
                //MessageBox.Show(dt_group.Rows[i][0].ToString());
                TreeNode newnode = new TreeNode(dt_group.Rows[i][1].ToString());
                treeView1.Nodes.Add(newnode);
                for (int j = 0; j < dt_users.Rows.Count; j++)
                {
                    if (dt_users.Rows[j][5].Equals(dt_group.Rows[i][0]))
                    {
                        TreeNode childnode = new TreeNode(dt_users.Rows[j][0].ToString());
                        newnode.Nodes.Add(childnode);
                        newnode.ExpandAll();
                    }
                }
            }
            dt_group.Dispose();
            dt_users.Dispose();
        }
        #endregion
        #region ��Ӳ��ŷ���
        private void add_group(string str_group)
        {
            groupTableAdapter.Insert(str_group);
            groupTableAdapter.Update(databaseDataSet.group);
            this.fillComboBox();
        }
        #endregion
        #region ע�����û�
        int int_faceId=1;
        private void regiser_newUser()
        {
            string str_name = tbx_name.Text;
            string str_pwd = tbx_pwd.Text;
            string str_sex = comboBox2.Text;
            int int_age;
            if (tbx_age.Text == "")
            {
                int_age = 0;
            }
            else
            {
                 int_age = Convert.ToInt32(tbx_age.Text);
            }
            int int_group = (int)comboBox1.SelectedValue;
            string str_tel = tbx_tel.Text;
            string str_email = tbx_email.Text;

            if (str_name != "" && str_pwd != "" && str_pwd == tbx_repwd.Text)
            {
                usersTableAdapter.Insert(str_name, str_pwd, int_faceId, str_sex, int_age, int_group, str_tel, str_email);
                usersTableAdapter.Update(databaseDataSet.users);
                MessageBox.Show("ע��ɹ�");
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Level == 0 && node.Text == comboBox1.Text)
                    {
                        TreeNode childnode = new TreeNode(str_name);
                        node.Nodes.Add(childnode);
                    }

                }
                
            }
            else
            {
                MessageBox.Show("�û������벻��Ϊ�գ�����������������һ�£�");
            }
        }
	
        #endregion
        #region �û��ͻ����ύ�޸ĸ������ϻ����Ƿ��������޸��û��������ϵĲ����ӿ�
        private bool edit_users(string str_name, string str_pwd, int int_faceId, string str_sex, int int_age, int int_group, string str_tel, string str_email)
        {
            //�����str_name�Ǹñ��������
            try
            {
                usersTableAdapter.Update_user(str_pwd, int_faceId, str_sex, int_age, int_group, str_tel, str_email, str_name);
                usersTableAdapter.Update(databaseDataSet.users);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region дһ������������һ���Ѿ����ڵķ������ƣ����ҵ��������������޸ĺõ�updata
        private bool updata_gruop(string str_oldGroup)
        {
            DataTable dt_group = groupTableAdapter.select_group();
            string str_newGroup = tbx_group_new.Text;
            int id=-1;
            for (int i = 0; i < dt_group.Rows.Count; i++)
            {
                if (dt_group.Rows[i][1].ToString() == str_oldGroup)
                {
                    id =(int)dt_group.Rows[i][0];
                }
            }
            if (id > 0&&str_newGroup!="")
            {
                groupTableAdapter.Update_group(str_newGroup, id);
                groupTableAdapter.Update(databaseDataSet.group);
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Text == str_oldGroup)
                        node.Text = str_newGroup;
                }
                return true;
            }
            else
            {
                MessageBox.Show("ע�⣬ԭ������ܲ����ڣ����·������Ʋ���Ϊ��");
                return false;
            }
            dt_group.Dispose();
        }
        #endregion
        private void btn_addGroup_Click(object sender, EventArgs e)
        {
            bool flag = true;
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Level ==0 && node.Text == tbx_group.Text)
                {
                    flag = false;
                    MessageBox.Show("�ò����Ѿ�����,�����ظ���ӣ�");
                }
            }
            if (flag)
            {
                if (tbx_group.Text != "")
                {
                    try
                    {
                        add_group(tbx_group.Text);
                        MessageBox.Show("ע��ɹ�");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.ToString());
                    }
                }
                TreeNode newnode = new TreeNode(tbx_group.Text);
                treeView1.Nodes.Add(newnode);
            }
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            try
            {
                regiser_newUser();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_userEdit_Click(object sender, EventArgs e)
        {
            string str_name = tbx_name_edit.Text;
            string str_pwd = tbx_pwd_edit.Text;
            int int_faceId = 0;
            string str_sex = comboBox3.Text;
            int int_age;
            if (tbx_age.Text == "")
            {
                int_age = 0;
            }
            else
            {
                int_age = Convert.ToInt32(tbx_age.Text);
            }
            int int_group = (int)comboBox4.SelectedValue;
            string str_tel = tbx_tel_edit.Text;
            string str_email = tbx_email_edit.Text;
            if (tbx_pwd_edit.Text == tbx_repwd_edit.Text && tbx_pwd_edit.Text != "")
            {
                if (edit_users(str_name, str_pwd, int_faceId, str_sex, int_age, int_group, str_tel, str_email))
                {
                    MessageBox.Show("��ӳɹ�");
                }
            }
            else
            {
                MessageBox.Show("���ʧ��");
            }
        }

        private void btn_group_edit_Click(object sender, EventArgs e)
        {
            if (updata_gruop(tbx_group_old.Text))
                MessageBox.Show("�޸ĳɹ�");
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //���˫���¼�������༭����
            TreeNode node = this.treeView1.GetNodeAt(e.X, e.Y);
            //ȡ�õ�ǰ�ڵ㣬�ж������Ҷ�ڵ�
            if (node.Level == 1 && node != null && node.IsSelected)
            {
                tabControl1.SelectedIndex = 1;
                DataTable dt_users = usersTableAdapter.selectUser_byname(node.Text);
                tbx_name_edit.Text = dt_users.Rows[0][0].ToString();
                comboBox3.Text = dt_users.Rows[0][3].ToString();
                tbx_age_edit.Text = dt_users.Rows[0][4].ToString();
                comboBox4.SelectedValue = dt_users.Rows[0][5].ToString();
                tbx_tel_edit.Text=dt_users.Rows[0][6].ToString();
                tbx_email_edit.Text = dt_users.Rows[0][7].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chooseface choose = new chooseface(int_faceId);
            if(DialogResult.OK == choose.ShowDialog())
            {
                int_faceId = choose.index;
                pictureBox1.Image = il_face.Images[int_faceId];
            }
        }
    }
}