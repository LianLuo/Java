package com.mhl.views;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Vector;

import javax.jws.WebParam.Mode;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.table.AbstractTableModel;
import javax.xml.transform.Source;

import com.mhl.utils.FontUtil;

public class HRView extends JFrame implements ActionListener{

	JPanel northPanel,southPanel,centerPanel;
	JTable dataGridView;
	JScrollPane scrollPane;
	
	Vector<String> columns;
	Vector<Vector> rows;
	
	public HRView()
	{
		columns = new Vector<String>();
		rows = new Vector<Vector>();
		initialData();
		northPanel =new JPanel(new FlowLayout(FlowLayout.CENTER));
		JLabel searchName = new JLabel("请输入员工姓名");
		searchName.setFont(FontUtil.f2);
		northPanel.add(searchName);
		ModelTable daTable = new ModelTable();
		dataGridView = new JTable(rows,columns){
			public boolean isCellEditable(int row,int column){
				return false;
			}
		};
		//dataGridView.setModel(daTable);
		centerPanel = new JPanel(new BorderLayout());
		scrollPane = new JScrollPane(dataGridView);
		centerPanel.add(scrollPane);
		//centerPanel.add(dataGridView);
		
		
		southPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
		JLabel totaLabel = new JLabel("总记录数是:条");
		totaLabel.setFont(FontUtil.f2);
		southPanel.add(totaLabel);
		
		this.setLayout(new BorderLayout());
		this.add(northPanel,"North");
		this.add(centerPanel,"Center");
		this.add(southPanel,"South");
		
		Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
		this.setSize(360,360);
		this.setLocation(dimension.width/2-200, dimension.height/2-150);
		
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setVisible(true);
	}
	
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		new HRView();
	}

	
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		
	}

	
	private void initialData(){
		String[] colStrings = {"编号","姓名","年龄","部门","备注"};
		for(int i =0;i<5;i++){
			columns.add(colStrings[i]);
			Vector<String> temp = new Vector<String>();
			int j=5;
			while(j>0)
			{
				temp.add(""+j);
				j--;
			}
			rows.add(temp);
		}
	}
}

class ModelTable extends AbstractTableModel{
	Vector<String> columns;
	Vector<Vector> rows;
	
	public ModelTable(){
		columns = new Vector<String>();
		rows = new Vector<Vector>();
		initialData();
	}
	
	private void initialData(){
		String[] colStrings = {"编号","姓名","年龄","部门","备注"};
		for(int i =0;i<5;i++){
			columns.add(colStrings[i]);
			Vector<String> temp = new Vector<String>();
			int j=5;
			while(j>0)
			{
				temp.add(""+j);
				j--;
			}
			rows.add(temp);
		}
	}

	@Override
	public int getColumnCount() {
		// TODO Auto-generated method stub
		return this.columns.size();
	}

	@Override
	public String getColumnName(int column) {
		// TODO Auto-generated method stub
		return this.columns.get(column);
	}

	@Override
	public int getRowCount() {
		// TODO Auto-generated method stub
		return this.rows.size();
	}

	@Override
	public Object getValueAt(int rowIndex, int columnIndex) {
		// TODO Auto-generated method stub
		return ((Vector)this.rows.get(rowIndex)).get(columnIndex);
	}
}
