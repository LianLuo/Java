package com.mhl.views;

import java.awt.BorderLayout;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.JDialog;
import javax.swing.JPanel;

import com.sun.xml.internal.ws.api.server.Container;

public class safe extends JDialog implements ActionListener{

	public safe()
	{
		this.setLayout(null);
		BackImage back = new BackImage();
		back.setBounds(0,0,1024,640);
		java.awt.Container container = getContentPane();
		
		container.add(back);
		this.setSize(1024, 640);
		this.setLocation(500,400);
		this.setUndecorated(true);
		this.setVisible(true);
		
	}
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		new safe();
	}

	
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		
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
			g.drawImage(image, 0, 0, 1024, 640, this);
		}
		
		
	}
}
