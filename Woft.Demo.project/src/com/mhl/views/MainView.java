package com.mhl.views;

import java.awt.BorderLayout;
import java.awt.CardLayout;
import java.awt.Cursor;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.io.File;
import java.io.IOException;
import java.util.Calendar;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JSplitPane;
import javax.swing.JToolBar;
import javax.swing.Timer;

import com.mhl.utils.FontUtil;
import com.mhl.views.charView.newPanel;

public class MainView extends JFrame implements ActionListener,MouseListener{

	Image titleIco;// 窗体图标
	Image timebackground; // 时间背景图
	
	JMenuBar menuBar;//菜单栏
	
	JMenu menu_system; //系统菜单
	JMenu menu_human; // 人事菜单
	JMenu menu_menu; // 点餐菜单
	JMenu menu_statistic; // 统计菜单
	JMenu menu_store; // 库存菜单
	JMenu menu_help; //帮助菜单
	
	JMenuItem menuItem_changeUser,menuItem_bill,menuItem_login,menuItem_calendar,menuItem_exit;
	
	ImageIcon icon_bill,icon_calender,icon_changeUser,icon_exit,icon_userLogin;
	
	JToolBar toolBar;
	
	JButton btn_sys,btn_human,btn_menu,btn_staic,btn_store,btn_help;
	
	JPanel leftPanel,splitPanel,operatePanel,rightPanel,mainPanel;
	
	JLabel currentTimeLabel;
	
	JLabel lb1,lb2,lb3,lb4,lb5,lb6,lb7,lb8;
	
	JLabel p2_label,p2_Label2;
	
	javax.swing.Timer timer;
	
	Cursor myCursor = null;
	
	JSplitPane splitPane;
	
	CardLayout cardLayout,cardLayout2;
	
	ImagePanel imagePanel;
	
	Image p1_backImage,main_backImage,hr_backImage;
	
	public static void main(String[] args){
		new MainView();
	}
	
	
	private void initialMenu()
	{
		icon_bill = new ImageIcon("Resources\\images\\menuBar\\bill.png");
		icon_calender = new ImageIcon("Resources\\images\\menuBar\\calendar.png");
		icon_changeUser = new ImageIcon("Resources\\images\\menuBar\\changeUser.png");
		icon_exit = new ImageIcon("Resources\\images\\menuBar\\exit.png");
		icon_userLogin = new ImageIcon("Resources\\images\\menuBar\\userLogin.png");
		
		menu_system = new JMenu("系统管理");
		menu_system.setFont(FontUtil.f1);
		
		menuItem_changeUser = new JMenuItem("切换用户",icon_changeUser);
		menuItem_changeUser.setFont(FontUtil.f2);
		menu_system.add(menuItem_changeUser);
		
		menuItem_bill = new JMenuItem("收款界面",icon_bill);
		menuItem_bill.setFont(FontUtil.f2);
		menu_system.add(menuItem_bill);
		
		menuItem_login = new JMenuItem("登录界面",icon_userLogin);
		menuItem_login.setFont(FontUtil.f2);
		menu_system.add(menuItem_login);
		
		menuItem_calendar = new JMenuItem("万年历日",icon_calender);
		menuItem_calendar.setFont(FontUtil.f2);
		menu_system.add(menuItem_calendar);
		
		menuItem_exit = new JMenuItem("退出系统",icon_exit);
		menuItem_exit.setFont(FontUtil.f2);
		menu_system.add(menuItem_exit);
		
		
		menu_human = new JMenu("人事管理");
		menu_human.setFont(FontUtil.f1);
		menu_menu = new JMenu("菜单管理");
		menu_menu.setFont(FontUtil.f1);
		menu_statistic = new JMenu("报表管理");
		menu_statistic.setFont(FontUtil.f1);
		menu_store = new JMenu("成本库房");
		menu_store.setFont(FontUtil.f1);
		menu_help = new JMenu("系统帮助");
		menu_help.setFont(FontUtil.f1);
		
		menuBar = new JMenuBar();
		menuBar.add(menu_system);
		menuBar.add(menu_human);
		menuBar.add(menu_menu);
		menuBar.add(menu_statistic);
		menuBar.add(menu_store);
		menuBar.add(menu_help);
		
		this.setJMenuBar(menuBar);
		
	}

	private void initialToolBar(){
		toolBar = new JToolBar();
		// 是否可以浮动
		toolBar.setFloatable(false);
		
		btn_sys = new JButton(new ImageIcon("Resources\\images\\toolBars\\system.png"));
		btn_help = new JButton(new ImageIcon("Resources\\images\\toolBars\\help.png"));
		btn_human = new JButton(new ImageIcon("Resources\\images\\toolBars\\user.png"));
		btn_menu = new JButton(new ImageIcon("Resources\\images\\toolBars\\menu.png"));
		btn_staic = new JButton(new ImageIcon("Resources\\images\\toolBars\\statistics.png"));
		btn_store = new JButton(new ImageIcon("Resources\\images\\toolBars\\store.png"));
	
		toolBar.add(btn_sys);
		toolBar.add(btn_human);
		toolBar.add(btn_menu);
		toolBar.add(btn_staic);
		toolBar.add(btn_store);
		toolBar.add(btn_help);
	}

	private void allPanels(){
		leftPanel = new JPanel(new BorderLayout());
		
		try{
			p1_backImage = ImageIO.read(new File("Resources\\images\\center\\jp1_bg.jpg"));
		}catch (IOException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		myCursor = new Cursor(Cursor.HAND_CURSOR);
		
		this.imagePanel = new ImagePanel(p1_backImage);
		this.imagePanel.setLayout(new GridLayout(8,1));
		
		this.lb1 = new JLabel(new ImageIcon("Resources\\images\\center\\label_1.gif"));
		this.lb1.setFont(FontUtil.f3);
		this.lb1.setCursor(myCursor);
		this.lb1.addMouseListener(this);
		this.imagePanel.add(this.lb1);
		
		this.lb2 = new JLabel("人事管理",new ImageIcon("Resources\\images\\center\\hr.png"),0);
		this.lb2.setFont(FontUtil.f3);
		this.lb2.setEnabled(false);
		this.lb2.addMouseListener(this);
		this.lb2.setCursor(myCursor);
		this.imagePanel.add(this.lb2);
		
		this.lb3 = new JLabel("登录管理",new ImageIcon("Resources\\images\\center\\user.png"),0);
		this.lb3.setFont(FontUtil.f3);
		this.lb3.setEnabled(false);
		this.lb3.addMouseListener(this);
		this.lb3.setCursor(myCursor);
		this.imagePanel.add(this.lb3);
		
		this.lb4 = new JLabel("菜谱价格",new ImageIcon("Resources\\images\\center\\archives.png"),0);
		this.lb4.setFont(FontUtil.f3);
		this.lb4.setEnabled(false);
		this.lb4.addMouseListener(this);
		this.lb4.setCursor(myCursor);
		this.imagePanel.add(this.lb4);
		
		this.lb5 = new JLabel("报价统计",new ImageIcon("Resources\\images\\center\\pie_statistic.png"),0);
		this.lb5.setFont(FontUtil.f3);
		this.lb5.setEnabled(false);
		this.lb5.addMouseListener(this);
		this.lb5.setCursor(myCursor);
		this.imagePanel.add(this.lb5);
		
		this.lb6 = new JLabel("成本库存",new ImageIcon("Resources\\images\\center\\database.png"),0);
		this.lb6.setFont(FontUtil.f3);
		this.lb6.setEnabled(false);
		this.lb6.addMouseListener(this);
		this.lb6.setCursor(myCursor);
		this.imagePanel.add(this.lb6);
		
		this.lb7 = new JLabel("系统设置",new ImageIcon("Resources\\images\\center\\settings.png"),0);
		this.lb7.setFont(FontUtil.f3);
		this.lb7.setEnabled(false);
		this.lb7.addMouseListener(this);
		this.lb7.setCursor(myCursor);
		this.imagePanel.add(this.lb7);
		
		this.lb8 = new JLabel("动画帮助",new ImageIcon("Resources\\images\\center\\lamp_active.png"),0);
		this.lb8.setFont(FontUtil.f3);
		this.lb8.setEnabled(false);
		this.lb8.addMouseListener(this);
		this.lb8.setCursor(myCursor);
		this.imagePanel.add(this.lb8);
		
		this.leftPanel.add(this.imagePanel);
		
		this.rightPanel = new JPanel(new BorderLayout());
		cardLayout = new CardLayout();
		splitPanel = new JPanel(this.cardLayout);
		p2_label = new JLabel(new ImageIcon("Resources\\images\\center\\jp2_left.jpg"));
		p2_label.addMouseListener(this);
		
		p2_Label2 = new JLabel(new ImageIcon("Resources\\images\\center\\jp2_right.jpg"));
		p2_Label2.addMouseListener(this);
		splitPanel.add(p2_label,"splitLeft");
		splitPanel.add(p2_Label2,"splitRight");
		
		this.cardLayout2 = new CardLayout();
		operatePanel = new JPanel(this.cardLayout2);
		try{
			main_backImage = ImageIO.read(new File("Resources\\images\\bg\\bg1.jpg"));
			hr_backImage = ImageIO.read(new File("Resources\\images\\bg\\bg2.jpg"));
		}catch (IOException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		
		ImagePanel imagePanel1 = new ImagePanel(main_backImage);
		operatePanel.add(imagePanel1,"IndexPage");		
		operatePanel.add(new HRManageView(),"humanPage");//new ImagePanel(hr_backImage)
		operatePanel.add(new JLabel("菜单点击"),"menuPage");
		operatePanel.add(new StatisticsView(),"statisticsPage");
		operatePanel.add(new JLabel("库存"),"storePage");
		operatePanel.add(new JLabel("系统"),"sysPage");
		operatePanel.add(new JLabel("动画"),"aniPage");
		
		JLabel dLabel = new JLabel(new ImageIcon("Resources\\images\\bg\\bg3.jpg"));
		
		operatePanel.add(dLabel,"loginPage");
		rightPanel.add(splitPanel,"West");
		rightPanel.add(operatePanel,"Center");
		
		// 拆分方式
		this.splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT,leftPanel,rightPanel);
		
		//指定左边面板宽度
		this.splitPane.setDividerLocation(160);
		// 设置分割线宽度
		this.splitPane.setDividerSize(0);
	}
	
	private void initialStatusBar(){
		mainPanel = new JPanel(new BorderLayout());
		
		timer = new Timer(1000,this);
		timer.start();
		
		currentTimeLabel = new JLabel("当前时间: "+Calendar.getInstance().getTime().toString());
		
		try{
			timebackground = ImageIO.read(new File("Resources\\images\\center\\time_bg.jpg"));
		}catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		
		ImagePanel imagePanel = new ImagePanel(timebackground);
		imagePanel.setLayout(new BorderLayout());
		imagePanel.add(currentTimeLabel,"East");
		mainPanel.add(imagePanel);
	}
	
	public MainView()
	{
		try{
			titleIco = ImageIO.read(new File("Resources/images/title.png"));
		}catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		
		this.initialMenu();
		
		this.initialToolBar();
		
		this.allPanels();
		
		this.initialStatusBar();
		
		java.awt.Container container = this.getContentPane();
		container.add(toolBar,"North");
		container.add(splitPane,"Center");
		container.add(mainPanel,"South");
		
		Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
		
		this.setTitle("满汉楼餐饮管理系统");
		this.setIconImage(titleIco);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(dimension.width,dimension.height-30);
		this.setVisible(true);
	}
	
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		this.currentTimeLabel.setText("当前时间: "+Calendar.getInstance().getTime().toString());
	}

	@Override
	public void mouseClicked(MouseEvent e) {
		// TODO Auto-generated method stub
		
		Object object = e.getSource();
		
		if(object == this.lb1){
			this.cardLayout2.show(this.operatePanel, "IndexPage");
		}else if(object == this.lb2){
			this.cardLayout2.show(this.operatePanel, "humanPage");
		}else if(object == this.lb3){
			this.cardLayout2.show(this.operatePanel, "loginPage");
		}else if(object == this.lb4){
			this.cardLayout2.show(this.operatePanel, "menuPage");
		}else if(object == this.lb5){
			this.cardLayout2.show(this.operatePanel, "statisticsPage");
		}else if(object == this.lb6){
			this.cardLayout2.show(this.operatePanel, "storePage");
		}else if(object == this.lb7){
			this.cardLayout2.show(this.operatePanel, "sysPage");
		}else if(object == this.lb8){
			this.cardLayout2.show(this.operatePanel, "aniPage");
		}else if(object == p2_label){
			this.cardLayout.show(this.splitPanel, "splitRight");
			this.splitPane.setDividerLocation(0);
		}else if(object == this.p2_Label2){
			this.cardLayout.show(this.splitPanel, "splitLeft");
			this.splitPane.setDividerLocation(160);
		}
		
	}

	@Override
	public void mouseEntered(MouseEvent e) {
		// TODO Auto-generated method stub
		Object object = e.getSource();
		// 如果用户选择某个Jlabel,则高亮
		JLabel[] labels = {lb2,lb3,lb4,lb5,lb6,lb7,lb8};
		for(int i =0;i<labels.length;i++)
		{
			JLabel label = labels[i];
			if(object == labels[i])
			{
				label.setEnabled(true);
			}else{
				label.setEnabled(false);
			}
		}
		
	}

	@Override
	public void mouseExited(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mousePressed(MouseEvent e) {
		// TODO Auto-generated method stub
		Object object = e.getSource();
	}

	@Override
	public void mouseReleased(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

}
