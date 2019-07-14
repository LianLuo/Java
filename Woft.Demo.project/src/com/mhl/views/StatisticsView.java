package com.mhl.views;

import java.awt.BasicStroke;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

import com.mhl.utils.FontUtil;

public class StatisticsView extends JPanel{

	JPanel southPanel;
	JPanel bottonRightPanel;
	
	public StatisticsView(){
		this.setLayout(new BorderLayout());
		this.initialChartPanel();
		
		this.add(new chartPanel(),"Center");
		this.add(southPanel,"South");
	}
	
	private void initialChartPanel(){		
	
		southPanel = new JPanel(new BorderLayout());
		southPanel.add(new JLabel("AAA"),"West");
		
		bottonRightPanel = new JPanel();
		bottonRightPanel.add(new JButton("Add"));
		bottonRightPanel.add(new JButton("Delete"));
		bottonRightPanel.add(new JButton("Modify"));
		southPanel.add(bottonRightPanel,"East");
		
	}
	
}

class chartPanel extends JPanel{
	public chartPanel(){
		this.setBackground(new Color(9,18,14));
	}

	@Override
	public void paintComponent(Graphics g) {
		// TODO Auto-generated method stub
		super.paintComponent(g);
		g.setColor(new Color(34,68,52));
		
		drawXYAxis(g,true);
	}
	
	/**
	 * ���������XY����
	 * @param g
	 * @param isNeetNetGrid �Ƿ���Ҫ����
	 */
	private void drawXYAxis(Graphics g,boolean isNeetNetGrid)
	{
		// net grid
		if(isNeetNetGrid){
			int xAxis = this.getWidth();
			int yAxis = this.getHeight();
			for(int i = 0;i<yAxis;i+=10)
			{
				g.drawLine(0, i, xAxis, i);
			}
			
			for(int i = 0;i<xAxis;i+=10){
				g.drawLine(i, 0, i, yAxis);
			}
		}
		
		// Y ��
		g.setColor(Color.WHITE);
//		Graphics2D g2d = (Graphics2D) g;
//		g2d.setStroke(new BasicStroke(3f)); // �����ߵĴ�
		g.drawLine(95, 130, 95, 633);
		int index = 0;
		for(int y = 633;y>180;y-=50)
		{
			g.drawLine(95, y, 105, y);
			g.drawString(index * 150+"", 60, y);
			index++;
		}
		// X ��
		g.drawLine(95, 633, 1255, 633);
		index = 0;
		for(int x = 145;x<1255;x+=50)
		{
			g.drawLine(x, 633, x, 623);
			if(index >= 0 && index <=17)
			{
				g.drawString((index+2010)+"��", x-15, 653);	
				drawPillar(g,x,633,500);
			}
			index++;
			
		}
		
		// ��Title
		g.setFont(FontUtil.f0);
		g.drawString("2010~2017�������ܶ�ͳ��ͼ����:(��λ ��Ԫ)", 490, 25);
	}


	private void drawPillar(Graphics g,int x,int y,int height)
	{
		int sideLength = 6;
		// ��״�ױ�
		g.drawLine(x-sideLength, y, x+sideLength, y);//�ױ�
		g.drawLine(x-sideLength, y-(sideLength*2), x+sideLength, y-(sideLength*2));//�ϱ�
		g.drawLine(x-(sideLength*2), y-sideLength,x-sideLength, y);//���±���
		g.drawLine(x-(sideLength*2), y-sideLength,x-sideLength, y);//���±���
		g.drawLine(x+(sideLength*2), y-sideLength,x+sideLength, y);//���±���
		g.drawLine(x-(sideLength*2), y-sideLength,x-sideLength, y-(sideLength*2));//���ϱ���
		g.drawLine(x+(sideLength*2), y-sideLength,x+sideLength, y-(sideLength*2));//���ϱ���
		
		int[][] px = new int[6][6];
		int[][] py = new int[6][6];
		double angle = 0.0;
		int min = 90,deta=20;
		for(int i = 0;i<6;i++){
			angle = 60 * Math.PI*i/180;
			for(int j = 0;j<6;j++){
				px[i][j] = (int) Math.round(x/2+(min+deta*j)*Math.sin(angle));
				py[i][j] = (int) Math.round(y/2+(min+deta*j)*Math.sin(angle));
			}
		}
		
		Graphics2D tcx = (Graphics2D)g;
		//tcx.fillPolygon(null,null,7);
		
		for(int i = 0;i<6;i++){
			g.fillPolygon(new int[]{px[0][i],px[1][i],px[2][i],px[3][i],px[4][i],px[5][i]},
					new int[]{py[0][i],py[1][i],py[2][i],py[3][i],py[4][i],py[5][i]}, 6);
		}
		//��״����
		/*g.drawLine(x-sideLength, y-height, x+sideLength, y-height);//�ױ�
		g.drawLine(x-sideLength, y-(sideLength*2)-height, x+sideLength, y-(sideLength*2)-height);//�ϱ�
		g.drawLine(x-(sideLength*2), y-sideLength-height,x-sideLength, y-height);//���±���
		g.drawLine(x-(sideLength*2), y-sideLength-height,x-sideLength, y-height);//���±���
		g.drawLine(x+(sideLength*2), y-sideLength-height,x+sideLength, y-height);//���±���
		g.drawLine(x-(sideLength*2), y-sideLength-height,x-sideLength, y-(sideLength*2)-height);//���ϱ���
		g.drawLine(x+(sideLength*2), y-sideLength-height,x+sideLength, y-(sideLength*2)-height);//���ϱ���
		*/
	}
}
