package com.mhl.views;

import java.awt.Dimension;
import java.awt.Frame;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;

import javax.imageio.ImageIO;
import javax.swing.JDialog;
import javax.swing.JFrame;

public class DetailView extends JDialog implements ActionListener{

	public DetailView(Frame frame,String title,boolean isModel)
	{
		super(frame,title,isModel);
		
		try{
			this.setIconImage(ImageIO.read(new File("Resources/images/title.png")));
		}catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		this.setSize(360,360);
		Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
		this.setLocation(dimension.width/2-200, dimension.height/2-150);
		this.setVisible(true);		
		
	}
	
	public DetailView(Frame frame,String title,boolean isModel,String id)
	{
		// TODO:通过ID获取模型，填充数据
		this(frame, title, isModel);
	}
	
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		
	}

}
