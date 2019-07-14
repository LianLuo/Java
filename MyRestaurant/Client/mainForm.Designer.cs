namespace client
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改个人资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立会议室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.il_largeface = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.il_face = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_onlineroom = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改个人资料ToolStripMenuItem,
            this.建立会议室ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            resources.ApplyResources(this.操作ToolStripMenuItem, "操作ToolStripMenuItem");
            // 
            // 修改个人资料ToolStripMenuItem
            // 
            this.修改个人资料ToolStripMenuItem.Name = "修改个人资料ToolStripMenuItem";
            resources.ApplyResources(this.修改个人资料ToolStripMenuItem, "修改个人资料ToolStripMenuItem");
            this.修改个人资料ToolStripMenuItem.Click += new System.EventHandler(this.修改个人资料ToolStripMenuItem_Click);
            // 
            // 建立会议室ToolStripMenuItem
            // 
            this.建立会议室ToolStripMenuItem.Name = "建立会议室ToolStripMenuItem";
            resources.ApplyResources(this.建立会议室ToolStripMenuItem, "建立会议室ToolStripMenuItem");
            this.建立会议室ToolStripMenuItem.Click += new System.EventHandler(this.createMeeting);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            resources.ApplyResources(this.关于ToolStripMenuItem, "关于ToolStripMenuItem");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // il_largeface
            // 
            this.il_largeface.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_largeface.ImageStream")));
            this.il_largeface.TransparentColor = System.Drawing.Color.Transparent;
            this.il_largeface.Images.SetKeyName(0, "");
            this.il_largeface.Images.SetKeyName(1, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.ImageList = this.il_face;
            this.treeView1.ItemHeight = 25;
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.userInfo);
            // 
            // il_face
            // 
            this.il_face.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_face.ImageStream")));
            this.il_face.TransparentColor = System.Drawing.Color.Transparent;
            this.il_face.Images.SetKeyName(0, "a.bmp");
            this.il_face.Images.SetKeyName(1, "1_m.bmp");
            this.il_face.Images.SetKeyName(2, "2_m.bmp");
            this.il_face.Images.SetKeyName(3, "3_m.bmp");
            this.il_face.Images.SetKeyName(4, "4_m.bmp");
            this.il_face.Images.SetKeyName(5, "5_m.bmp");
            this.il_face.Images.SetKeyName(6, "6_m.bmp");
            this.il_face.Images.SetKeyName(7, "7_m.bmp");
            this.il_face.Images.SetKeyName(8, "8_m.bmp");
            this.il_face.Images.SetKeyName(9, "9_m.bmp");
            this.il_face.Images.SetKeyName(10, "10_m.bmp");
            this.il_face.Images.SetKeyName(11, "11_m.bmp");
            this.il_face.Images.SetKeyName(12, "12_m.bmp");
            this.il_face.Images.SetKeyName(13, "13_m.bmp");
            this.il_face.Images.SetKeyName(14, "14_m.bmp");
            this.il_face.Images.SetKeyName(15, "15_m.bmp");
            this.il_face.Images.SetKeyName(16, "16_m.bmp");
            this.il_face.Images.SetKeyName(17, "17_m.bmp");
            this.il_face.Images.SetKeyName(18, "18_m.bmp");
            this.il_face.Images.SetKeyName(19, "19_m.bmp");
            this.il_face.Images.SetKeyName(20, "20_m.bmp");
            this.il_face.Images.SetKeyName(21, "21_m.bmp");
            this.il_face.Images.SetKeyName(22, "22_m.bmp");
            this.il_face.Images.SetKeyName(23, "23_m.bmp");
            this.il_face.Images.SetKeyName(24, "24_m.bmp");
            this.il_face.Images.SetKeyName(25, "25_m.bmp");
            this.il_face.Images.SetKeyName(26, "26_m.bmp");
            this.il_face.Images.SetKeyName(27, "27_m.bmp");
            this.il_face.Images.SetKeyName(28, "28_m.bmp");
            this.il_face.Images.SetKeyName(29, "29_m.bmp");
            this.il_face.Images.SetKeyName(30, "30_m.bmp");
            this.il_face.Images.SetKeyName(31, "31_m.bmp");
            this.il_face.Images.SetKeyName(32, "32_m.bmp");
            this.il_face.Images.SetKeyName(33, "33_m.bmp");
            this.il_face.Images.SetKeyName(34, "34_m.bmp");
            this.il_face.Images.SetKeyName(35, "35_m.bmp");
            this.il_face.Images.SetKeyName(36, "36_m.bmp");
            this.il_face.Images.SetKeyName(37, "37_m.bmp");
            this.il_face.Images.SetKeyName(38, "38_m.bmp");
            this.il_face.Images.SetKeyName(39, "39_m.bmp");
            this.il_face.Images.SetKeyName(40, "40_m.bmp");
            this.il_face.Images.SetKeyName(41, "41_m.bmp");
            this.il_face.Images.SetKeyName(42, "42_m.bmp");
            this.il_face.Images.SetKeyName(43, "43_m.bmp");
            this.il_face.Images.SetKeyName(44, "44_m.bmp");
            this.il_face.Images.SetKeyName(45, "45_m.bmp");
            this.il_face.Images.SetKeyName(46, "46_m.bmp");
            this.il_face.Images.SetKeyName(47, "47_m.bmp");
            this.il_face.Images.SetKeyName(48, "48_m.bmp");
            this.il_face.Images.SetKeyName(49, "49_m.bmp");
            this.il_face.Images.SetKeyName(50, "50_m.bmp");
            this.il_face.Images.SetKeyName(51, "51_m.bmp");
            this.il_face.Images.SetKeyName(52, "52_m.bmp");
            this.il_face.Images.SetKeyName(53, "53_m.bmp");
            this.il_face.Images.SetKeyName(54, "54_m.bmp");
            this.il_face.Images.SetKeyName(55, "55_m.bmp");
            this.il_face.Images.SetKeyName(56, "56_m.bmp");
            this.il_face.Images.SetKeyName(57, "57_m.bmp");
            this.il_face.Images.SetKeyName(58, "58_m.bmp");
            this.il_face.Images.SetKeyName(59, "59_m.bmp");
            this.il_face.Images.SetKeyName(60, "60_m.bmp");
            this.il_face.Images.SetKeyName(61, "61_m.bmp");
            this.il_face.Images.SetKeyName(62, "62_m.bmp");
            this.il_face.Images.SetKeyName(63, "63_m.bmp");
            this.il_face.Images.SetKeyName(64, "64_m.bmp");
            this.il_face.Images.SetKeyName(65, "65_m.bmp");
            this.il_face.Images.SetKeyName(66, "66_m.bmp");
            this.il_face.Images.SetKeyName(67, "67_m.bmp");
            this.il_face.Images.SetKeyName(68, "68_m.bmp");
            this.il_face.Images.SetKeyName(69, "69_m.bmp");
            this.il_face.Images.SetKeyName(70, "70_m.bmp");
            this.il_face.Images.SetKeyName(71, "71_m.bmp");
            this.il_face.Images.SetKeyName(72, "72_m.bmp");
            this.il_face.Images.SetKeyName(73, "73_m.bmp");
            this.il_face.Images.SetKeyName(74, "74_m.bmp");
            this.il_face.Images.SetKeyName(75, "75_m.bmp");
            this.il_face.Images.SetKeyName(76, "76_m.bmp");
            this.il_face.Images.SetKeyName(77, "77_m.bmp");
            this.il_face.Images.SetKeyName(78, "78_m.bmp");
            this.il_face.Images.SetKeyName(79, "79_m.bmp");
            this.il_face.Images.SetKeyName(80, "80_m.bmp");
            this.il_face.Images.SetKeyName(81, "81_m.bmp");
            this.il_face.Images.SetKeyName(82, "82_m.bmp");
            this.il_face.Images.SetKeyName(83, "83_m.bmp");
            this.il_face.Images.SetKeyName(84, "84_m.bmp");
            this.il_face.Images.SetKeyName(85, "85_m.bmp");
            this.il_face.Images.SetKeyName(86, "86_m.bmp");
            this.il_face.Images.SetKeyName(87, "87_m.bmp");
            this.il_face.Images.SetKeyName(88, "88_m.bmp");
            this.il_face.Images.SetKeyName(89, "89_m.bmp");
            this.il_face.Images.SetKeyName(90, "90_m.bmp");
            this.il_face.Images.SetKeyName(91, "91_m.bmp");
            this.il_face.Images.SetKeyName(92, "92_m.bmp");
            this.il_face.Images.SetKeyName(93, "93_m.bmp");
            this.il_face.Images.SetKeyName(94, "94_m.bmp");
            this.il_face.Images.SetKeyName(95, "95_m.bmp");
            this.il_face.Images.SetKeyName(96, "96_m.bmp");
            this.il_face.Images.SetKeyName(97, "97_m.bmp");
            this.il_face.Images.SetKeyName(98, "98_m.bmp");
            this.il_face.Images.SetKeyName(99, "99_m.bmp");
            this.il_face.Images.SetKeyName(100, "100_m.bmp");
            this.il_face.Images.SetKeyName(101, "1_m.bmp");
            this.il_face.Images.SetKeyName(102, "2_m.bmp");
            this.il_face.Images.SetKeyName(103, "3_m.bmp");
            this.il_face.Images.SetKeyName(104, "4_m.bmp");
            this.il_face.Images.SetKeyName(105, "5_m.bmp");
            this.il_face.Images.SetKeyName(106, "6_m.bmp");
            this.il_face.Images.SetKeyName(107, "7_m.bmp");
            this.il_face.Images.SetKeyName(108, "8_m.bmp");
            this.il_face.Images.SetKeyName(109, "9_m.bmp");
            this.il_face.Images.SetKeyName(110, "10_m.bmp");
            this.il_face.Images.SetKeyName(111, "11_m.bmp");
            this.il_face.Images.SetKeyName(112, "12_m.bmp");
            this.il_face.Images.SetKeyName(113, "13_m.bmp");
            this.il_face.Images.SetKeyName(114, "14_m.bmp");
            this.il_face.Images.SetKeyName(115, "15_m.bmp");
            this.il_face.Images.SetKeyName(116, "16_m.bmp");
            this.il_face.Images.SetKeyName(117, "17_m.bmp");
            this.il_face.Images.SetKeyName(118, "18_m.bmp");
            this.il_face.Images.SetKeyName(119, "19_m.bmp");
            this.il_face.Images.SetKeyName(120, "20_m.bmp");
            this.il_face.Images.SetKeyName(121, "21_m.bmp");
            this.il_face.Images.SetKeyName(122, "22_m.bmp");
            this.il_face.Images.SetKeyName(123, "23_m.bmp");
            this.il_face.Images.SetKeyName(124, "24_m.bmp");
            this.il_face.Images.SetKeyName(125, "25_m.bmp");
            this.il_face.Images.SetKeyName(126, "26_m.bmp");
            this.il_face.Images.SetKeyName(127, "27_m.bmp");
            this.il_face.Images.SetKeyName(128, "28_m.bmp");
            this.il_face.Images.SetKeyName(129, "29_m.bmp");
            this.il_face.Images.SetKeyName(130, "30_m.bmp");
            this.il_face.Images.SetKeyName(131, "31_m.bmp");
            this.il_face.Images.SetKeyName(132, "32_m.bmp");
            this.il_face.Images.SetKeyName(133, "33_m.bmp");
            this.il_face.Images.SetKeyName(134, "34_m.bmp");
            this.il_face.Images.SetKeyName(135, "35_m.bmp");
            this.il_face.Images.SetKeyName(136, "36_m.bmp");
            this.il_face.Images.SetKeyName(137, "37_m.bmp");
            this.il_face.Images.SetKeyName(138, "38_m.bmp");
            this.il_face.Images.SetKeyName(139, "39_m.bmp");
            this.il_face.Images.SetKeyName(140, "40_m.bmp");
            this.il_face.Images.SetKeyName(141, "41_m.bmp");
            this.il_face.Images.SetKeyName(142, "42_m.bmp");
            this.il_face.Images.SetKeyName(143, "43_m.bmp");
            this.il_face.Images.SetKeyName(144, "44_m.bmp");
            this.il_face.Images.SetKeyName(145, "45_m.bmp");
            this.il_face.Images.SetKeyName(146, "46_m.bmp");
            this.il_face.Images.SetKeyName(147, "47_m.bmp");
            this.il_face.Images.SetKeyName(148, "48_m.bmp");
            this.il_face.Images.SetKeyName(149, "49_m.bmp");
            this.il_face.Images.SetKeyName(150, "50_m.bmp");
            this.il_face.Images.SetKeyName(151, "51_m.bmp");
            this.il_face.Images.SetKeyName(152, "52_m.bmp");
            this.il_face.Images.SetKeyName(153, "53_m.bmp");
            this.il_face.Images.SetKeyName(154, "54_m.bmp");
            this.il_face.Images.SetKeyName(155, "55_m.bmp");
            this.il_face.Images.SetKeyName(156, "56_m.bmp");
            this.il_face.Images.SetKeyName(157, "57_m.bmp");
            this.il_face.Images.SetKeyName(158, "58_m.bmp");
            this.il_face.Images.SetKeyName(159, "59_m.bmp");
            this.il_face.Images.SetKeyName(160, "60_m.bmp");
            this.il_face.Images.SetKeyName(161, "61_m.bmp");
            this.il_face.Images.SetKeyName(162, "62_m.bmp");
            this.il_face.Images.SetKeyName(163, "63_m.bmp");
            this.il_face.Images.SetKeyName(164, "64_m.bmp");
            this.il_face.Images.SetKeyName(165, "65_m.bmp");
            this.il_face.Images.SetKeyName(166, "66_m.bmp");
            this.il_face.Images.SetKeyName(167, "67_m.bmp");
            this.il_face.Images.SetKeyName(168, "68_m.bmp");
            this.il_face.Images.SetKeyName(169, "69_m.bmp");
            this.il_face.Images.SetKeyName(170, "70_m.bmp");
            this.il_face.Images.SetKeyName(171, "71_m.bmp");
            this.il_face.Images.SetKeyName(172, "72_m.bmp");
            this.il_face.Images.SetKeyName(173, "73_m.bmp");
            this.il_face.Images.SetKeyName(174, "74_m.bmp");
            this.il_face.Images.SetKeyName(175, "75_m.bmp");
            this.il_face.Images.SetKeyName(176, "76_m.bmp");
            this.il_face.Images.SetKeyName(177, "77_m.bmp");
            this.il_face.Images.SetKeyName(178, "78_m.bmp");
            this.il_face.Images.SetKeyName(179, "79_m.bmp");
            this.il_face.Images.SetKeyName(180, "80_m.bmp");
            this.il_face.Images.SetKeyName(181, "81_m.bmp");
            this.il_face.Images.SetKeyName(182, "82_m.bmp");
            this.il_face.Images.SetKeyName(183, "83_m.bmp");
            this.il_face.Images.SetKeyName(184, "84_m.bmp");
            this.il_face.Images.SetKeyName(185, "85_m.bmp");
            this.il_face.Images.SetKeyName(186, "86_m.bmp");
            this.il_face.Images.SetKeyName(187, "87_m.bmp");
            this.il_face.Images.SetKeyName(188, "88_m.bmp");
            this.il_face.Images.SetKeyName(189, "89_m.bmp");
            this.il_face.Images.SetKeyName(190, "90_m.bmp");
            this.il_face.Images.SetKeyName(191, "91_m.bmp");
            this.il_face.Images.SetKeyName(192, "92_m.bmp");
            this.il_face.Images.SetKeyName(193, "93_m.bmp");
            this.il_face.Images.SetKeyName(194, "94_m.bmp");
            this.il_face.Images.SetKeyName(195, "95_m.bmp");
            this.il_face.Images.SetKeyName(196, "96_m.bmp");
            this.il_face.Images.SetKeyName(197, "97_m.bmp");
            this.il_face.Images.SetKeyName(198, "98_m.bmp");
            this.il_face.Images.SetKeyName(199, "99_m.bmp");
            this.il_face.Images.SetKeyName(200, "100_m.bmp");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_onlineroom);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_onlineroom
            // 
            this.listView_onlineroom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            resources.ApplyResources(this.listView_onlineroom, "listView_onlineroom");
            this.listView_onlineroom.FullRowSelect = true;
            this.listView_onlineroom.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_onlineroom.Name = "listView_onlineroom";
            this.listView_onlineroom.SmallImageList = this.il_largeface;
            this.listView_onlineroom.UseCompatibleStateImageBehavior = false;
            this.listView_onlineroom.View = System.Windows.Forms.View.Details;
            this.listView_onlineroom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_onlineroom_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "a.bmp");
            this.imageList2.Images.SetKeyName(1, "1.bmp");
            this.imageList2.Images.SetKeyName(2, "2.bmp");
            this.imageList2.Images.SetKeyName(3, "3.bmp");
            this.imageList2.Images.SetKeyName(4, "4.bmp");
            this.imageList2.Images.SetKeyName(5, "5.bmp");
            this.imageList2.Images.SetKeyName(6, "6.bmp");
            this.imageList2.Images.SetKeyName(7, "7.bmp");
            this.imageList2.Images.SetKeyName(8, "8.bmp");
            this.imageList2.Images.SetKeyName(9, "9.bmp");
            this.imageList2.Images.SetKeyName(10, "10.bmp");
            this.imageList2.Images.SetKeyName(11, "11.bmp");
            this.imageList2.Images.SetKeyName(12, "12.bmp");
            this.imageList2.Images.SetKeyName(13, "13.bmp");
            this.imageList2.Images.SetKeyName(14, "14.bmp");
            this.imageList2.Images.SetKeyName(15, "15.bmp");
            this.imageList2.Images.SetKeyName(16, "16.bmp");
            this.imageList2.Images.SetKeyName(17, "17.bmp");
            this.imageList2.Images.SetKeyName(18, "18.bmp");
            this.imageList2.Images.SetKeyName(19, "19.bmp");
            this.imageList2.Images.SetKeyName(20, "20.bmp");
            this.imageList2.Images.SetKeyName(21, "21.bmp");
            this.imageList2.Images.SetKeyName(22, "22.bmp");
            this.imageList2.Images.SetKeyName(23, "23.bmp");
            this.imageList2.Images.SetKeyName(24, "24.bmp");
            this.imageList2.Images.SetKeyName(25, "25.bmp");
            this.imageList2.Images.SetKeyName(26, "26.bmp");
            this.imageList2.Images.SetKeyName(27, "27.bmp");
            this.imageList2.Images.SetKeyName(28, "28.bmp");
            this.imageList2.Images.SetKeyName(29, "29.bmp");
            this.imageList2.Images.SetKeyName(30, "30.bmp");
            this.imageList2.Images.SetKeyName(31, "31.bmp");
            this.imageList2.Images.SetKeyName(32, "32.bmp");
            this.imageList2.Images.SetKeyName(33, "33.bmp");
            this.imageList2.Images.SetKeyName(34, "34.bmp");
            this.imageList2.Images.SetKeyName(35, "35.bmp");
            this.imageList2.Images.SetKeyName(36, "36.bmp");
            this.imageList2.Images.SetKeyName(37, "37.bmp");
            this.imageList2.Images.SetKeyName(38, "38.bmp");
            this.imageList2.Images.SetKeyName(39, "39.bmp");
            this.imageList2.Images.SetKeyName(40, "40.bmp");
            this.imageList2.Images.SetKeyName(41, "41.bmp");
            this.imageList2.Images.SetKeyName(42, "42.bmp");
            this.imageList2.Images.SetKeyName(43, "43.bmp");
            this.imageList2.Images.SetKeyName(44, "44.bmp");
            this.imageList2.Images.SetKeyName(45, "45.bmp");
            this.imageList2.Images.SetKeyName(46, "46.bmp");
            this.imageList2.Images.SetKeyName(47, "47.bmp");
            this.imageList2.Images.SetKeyName(48, "48.bmp");
            this.imageList2.Images.SetKeyName(49, "49.bmp");
            this.imageList2.Images.SetKeyName(50, "50.bmp");
            this.imageList2.Images.SetKeyName(51, "51.bmp");
            this.imageList2.Images.SetKeyName(52, "52.bmp");
            this.imageList2.Images.SetKeyName(53, "53.bmp");
            this.imageList2.Images.SetKeyName(54, "54.bmp");
            this.imageList2.Images.SetKeyName(55, "55.bmp");
            this.imageList2.Images.SetKeyName(56, "56.bmp");
            this.imageList2.Images.SetKeyName(57, "57.bmp");
            this.imageList2.Images.SetKeyName(58, "58.bmp");
            this.imageList2.Images.SetKeyName(59, "59.bmp");
            this.imageList2.Images.SetKeyName(60, "60.bmp");
            this.imageList2.Images.SetKeyName(61, "61.bmp");
            this.imageList2.Images.SetKeyName(62, "62.bmp");
            this.imageList2.Images.SetKeyName(63, "63.bmp");
            this.imageList2.Images.SetKeyName(64, "64.bmp");
            this.imageList2.Images.SetKeyName(65, "65.bmp");
            this.imageList2.Images.SetKeyName(66, "66.bmp");
            this.imageList2.Images.SetKeyName(67, "67.bmp");
            this.imageList2.Images.SetKeyName(68, "68.bmp");
            this.imageList2.Images.SetKeyName(69, "69.bmp");
            this.imageList2.Images.SetKeyName(70, "70.bmp");
            this.imageList2.Images.SetKeyName(71, "71.bmp");
            this.imageList2.Images.SetKeyName(72, "72.bmp");
            this.imageList2.Images.SetKeyName(73, "73.bmp");
            this.imageList2.Images.SetKeyName(74, "74.bmp");
            this.imageList2.Images.SetKeyName(75, "75.bmp");
            this.imageList2.Images.SetKeyName(76, "76.bmp");
            this.imageList2.Images.SetKeyName(77, "77.bmp");
            this.imageList2.Images.SetKeyName(78, "78.bmp");
            this.imageList2.Images.SetKeyName(79, "79.bmp");
            this.imageList2.Images.SetKeyName(80, "80.bmp");
            this.imageList2.Images.SetKeyName(81, "81.bmp");
            this.imageList2.Images.SetKeyName(82, "82.bmp");
            this.imageList2.Images.SetKeyName(83, "83.bmp");
            this.imageList2.Images.SetKeyName(84, "84.bmp");
            this.imageList2.Images.SetKeyName(85, "85.bmp");
            this.imageList2.Images.SetKeyName(86, "86.bmp");
            this.imageList2.Images.SetKeyName(87, "87.bmp");
            this.imageList2.Images.SetKeyName(88, "88.bmp");
            this.imageList2.Images.SetKeyName(89, "89.bmp");
            this.imageList2.Images.SetKeyName(90, "90.bmp");
            this.imageList2.Images.SetKeyName(91, "91.bmp");
            this.imageList2.Images.SetKeyName(92, "92.bmp");
            this.imageList2.Images.SetKeyName(93, "93.bmp");
            this.imageList2.Images.SetKeyName(94, "94.bmp");
            this.imageList2.Images.SetKeyName(95, "95.bmp");
            this.imageList2.Images.SetKeyName(96, "96.bmp");
            this.imageList2.Images.SetKeyName(97, "97.bmp");
            this.imageList2.Images.SetKeyName(98, "98.bmp");
            this.imageList2.Images.SetKeyName(99, "99.bmp");
            this.imageList2.Images.SetKeyName(100, "100.bmp");
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立会议室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList il_largeface;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView_onlineroom;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList il_face;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 修改个人资料ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList2;
    }
}