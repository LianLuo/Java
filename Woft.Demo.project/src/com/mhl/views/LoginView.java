package com.mhl.views;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.*;

public class LoginView extends JDialog implements ActionListener{

	JLabel lbUser,lbPwd;
	JTextField tbUser;
	JPasswordField pwdField;
	JButton btnOk,btnCancel;
	
	public static void main(String[] args)
	{
		new LoginView();
	}
	
	public LoginView(){
		this.setLayout(null);
		BackImage backImage = new BackImage();
		backImage.setBounds(0,0,360,360);
		
		Container container = this.getContentPane();
		
		
		
		lbUser = new JLabel("请输入用户名:");
		lbUser.setFont(null);
		lbUser.setBounds(60, 190, 150, 30);
		container.add(lbUser);
		
		
		tbUser = new JTextField(20);
		tbUser.setFocusable(true);
		tbUser.setBounds(180, 190, 120, 30);
		tbUser.setFont(null);
		tbUser.setBorder(BorderFactory.createLoweredBevelBorder());
		container.add(tbUser);
		
		lbPwd = new JLabel("请输入密码:");
		lbPwd.setBounds(60,240,150,30);
		container.add(lbPwd);
		
		pwdField = new JPasswordField(20);
		pwdField.setBounds(180, 240, 120, 30);
		pwdField.setFont(null);
		pwdField.setBorder(BorderFactory.createLoweredBevelBorder());
		container.add(pwdField);
		
		btnOk = new JButton("确定");
		btnOk.addActionListener(this);
		btnOk.setFont(null);
		btnOk.setBounds(110,300,70,30);
		container.add(btnOk);
		
		btnCancel = new JButton("取消");
		btnCancel.addActionListener(this);
		btnCancel.setFont(null);
		btnCancel.setBounds(200,300,70,30);
		container.add(btnCancel);
		container.add(backImage);
		this.setUndecorated(true);
		this.setSize(360,360);
		
		Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
		this.setLocation(dimension.width/2-200,dimension.height/2-150);
		this.setVisible(true);
		
	}
	
	
	class BackImage extends JPanel{
		Image image;
		public BackImage(){
			try{
				image = ImageIO.read(new File("Resources/images/skin.png"));//login.gif
			}catch(IOException e){
				e.printStackTrace();
			}
		}
		
		public void paintComponent(Graphics g){
			g.drawImage(image, 0, 0, 360, 360, this);
		}
	}
	
	
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		if(e.getSource() == btnOk){
			
			String userName = this.tbUser.getText().trim();
			String pwd = new String(this.pwdField.getPassword());
			
			if(userName.equals("lwx240898") && pwd.equals("123")){
				//MainView view = new MainView();
				this.dispose();
			}else{
				JOptionPane.showMessageDialog(this, "您输入的用户名或者密码不对.");
				return;
			}
			
		}else if(e.getSource() == btnCancel){
			this.dispose();
		}
	}

}
