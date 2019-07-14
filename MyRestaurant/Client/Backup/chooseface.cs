using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class chooseface : Form
    {
        public chooseface(int index)
        {
            InitializeComponent();
            this.index = index;
            pictureBox.Image = il_face.Images[index];
        }
        public int index;
        private void chooseface_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < il_face.Images.Count; i++)
            {
                listViewface.Items.Add("", i);
            }
        }

        private void listViewface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewface.SelectedItems.Count > 0)
            {
                pictureBox.Image = il_face.Images[listViewface.SelectedItems[0].ImageIndex];
                index = listViewface.SelectedItems[0].ImageIndex;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}