namespace client
{
    partial class creatergroupChat
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("会议创建者", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("会议参与者", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(creatergroupChat));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.rtb_recv = new System.Windows.Forms.RichTextBox();
            this.rtb_send = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.listView_userList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(786, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(786, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // rtb_recv
            // 
            this.rtb_recv.Location = new System.Drawing.Point(129, 52);
            this.rtb_recv.Name = "rtb_recv";
            this.rtb_recv.Size = new System.Drawing.Size(438, 323);
            this.rtb_recv.TabIndex = 3;
            this.rtb_recv.Text = "";
            this.rtb_recv.TextChanged += new System.EventHandler(this.rtb_recv_TextChanged);
            // 
            // rtb_send
            // 
            this.rtb_send.Location = new System.Drawing.Point(129, 397);
            this.rtb_send.Name = "rtb_send";
            this.rtb_send.Size = new System.Drawing.Size(438, 58);
            this.rtb_send.TabIndex = 4;
            this.rtb_send.Text = "";
            this.rtb_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_send_KeyDown);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(492, 461);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // listView_userList
            // 
            this.listView_userList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView_userList.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView_userList.FullRowSelect = true;
            listViewGroup3.Header = "会议创建者";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "会议参与者";
            listViewGroup4.Name = "listViewGroup2";
            this.listView_userList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.listView_userList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_userList.Location = new System.Drawing.Point(0, 49);
            this.listView_userList.Name = "listView_userList";
            this.listView_userList.Size = new System.Drawing.Size(121, 436);
            this.listView_userList.SmallImageList = this.imageList1;
            this.listView_userList.TabIndex = 6;
            this.listView_userList.UseCompatibleStateImageBehavior = false;
            this.listView_userList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 109;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "28_m.bmp");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // creatergroupChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 507);
            this.Controls.Add(this.listView_userList);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.rtb_send);
            this.Controls.Add(this.rtb_recv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "creatergroupChat";
            this.Text = "groupChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.creatergroupChat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox rtb_recv;
        private System.Windows.Forms.RichTextBox rtb_send;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ListView listView_userList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
    }
}