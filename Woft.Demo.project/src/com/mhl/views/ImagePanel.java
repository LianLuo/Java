package com.mhl.views;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;

import javax.swing.JPanel;

public class ImagePanel extends JPanel{

	Image backImage;
	
	public ImagePanel(Image image)
	{
		this.backImage = image;
		Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
		
		this.setSize(dimension.width,dimension.height);
	}
	
	public void paintComponent(Graphics g){
		super.paintComponent(g);
		g.drawImage(this.backImage, 0, 0, this.getWidth(), this.getHeight(), this);
	}
}
