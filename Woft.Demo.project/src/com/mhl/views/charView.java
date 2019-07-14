package com.mhl.views;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.RenderingHints;
import java.awt.Toolkit;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class charView extends JFrame {
	public charView() {
	add(new newPanel());
	}

	class newPanel extends JPanel {
	//private int x;
	//private int y;
		public newPanel(){
			this.setBackground(new Color(9,18,14));
		}
		protected void paintComponent(Graphics g) {
			super.paintComponent(g);
			// Íø¸ñ
			g.setColor(new Color(34,68,52));
			for(int i = 0;i<400;i+=10){
				g.drawLine(0, i, 400, i);
			}
			
			for(int i = 0;i<400;i+=10)
			{
				g.drawLine(i, 0, i, 400);
			}
			
			// YÖá
			g.setColor(Color.white);
			g.drawLine(20, 100, 20, 250);
			for(int i = 100;i<=250;i+=15){
				g.drawLine(20, i, 25, i);
			}
			
			// XÖá
			g.drawLine(20, 250, 250, 250);
			for(int i = 20;i<=250;i+=15){
				g.drawLine(i, 250, i, 245);
			}
		}
	}

	public static void main(String[] args) {
	JFrame f = new charView();
	f.setTitle("Test");
	f.setSize(400, 400);
	f.setVisible(true);
	f.setDefaultCloseOperation(EXIT_ON_CLOSE);
	}
	}