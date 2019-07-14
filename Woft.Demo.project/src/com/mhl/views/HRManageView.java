package com.mhl.views;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Vector;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;

import com.mhl.models.DataTable;
import com.mhl.utils.FontUtil;

/**
 * 人事管理页面
 * @author Multi
 *
 */
public class HRManageView extends JPanel implements ActionListener{

	JPanel searchPanel;
	JPanel dataGridViewPanel;
	JPanel southPanel;
	JPanel buttonsPanel;
	
	JLabel infoLabel; // 条数信息
	JLabel searchLabel;// 搜索信息
	JTextField searchField; //搜索框
	JButton searchButton; // 搜索按钮
	JButton addButton; // 添加按钮
	JButton modityButton; // 修改按钮
	JButton deleteButton; // 删除按钮
	JButton detailButton; // 详情按钮
	
	JTable dataGrid;
	DataTable dt;
	
	JScrollPane scrollPane;//支持滚动
	
	public HRManageView(){
		dt = new DataTable();
		//initialDataTable();
		initialComponent();
	}
	
	private void initialComponent(){
		this.searchPanel = new JPanel(new FlowLayout());
		this.searchLabel = new JLabel("请输入姓名(员工工号):");
		this.searchLabel.setFont(FontUtil.f2);
		this.searchPanel.add(this.searchLabel);
		
		this.searchField = new JTextField(20);
		this.searchField.setBorder(BorderFactory.createLoweredBevelBorder());
		this.searchPanel.add(this.searchField);
		
		this.searchButton = new JButton("搜  索");
		this.searchButton.addActionListener(this);
		this.searchPanel.add(this.searchButton);
		
		// center panel
		Vector<String> columns = new Vector<String>();
		Vector<Vector> rows = new Vector<Vector>();
		Vector<String> cols = columns;
		cols.add("工号");
		cols.add("姓名");
		cols.add("性别");
		cols.add("部门");
		cols.add("职位");
		cols.add("学历");
		cols.add("是否婚配");
		
		Vector<String> tem = new Vector<String>();
		tem.add("1");
		tem.add("1");
		tem.add("1");
		tem.add("1");
		tem.add("1");
		tem.add("1");
		tem.add("1");
		rows.add(tem);
		this.dataGrid = new JTable(rows,cols);
		this.scrollPane = new JScrollPane(dataGrid);// 注意，将DataGridView添加到JScrollPane中，需要在构造函数里面添加
		this.dataGridViewPanel= new JPanel(new BorderLayout());
		this.dataGridViewPanel.add(scrollPane,"Center");
		
		
		// sourth panel		
		this.buttonsPanel = new JPanel(new FlowLayout());
		this.detailButton = new JButton("查看详情");
		this.detailButton.setFont(FontUtil.f2);
		this.detailButton.addActionListener(this);
		this.buttonsPanel.add(this.detailButton);
		
		this.addButton = new JButton("添加信息");
		this.addButton.setFont(FontUtil.f2);
		this.addButton.addActionListener(this);
		this.buttonsPanel.add(this.addButton);
		
		this.modityButton = new JButton("修改信息");
		this.modityButton.setFont(FontUtil.f2);
		this.modityButton.addActionListener(this);
		this.buttonsPanel.add(this.modityButton);
		
		this.deleteButton = new JButton("删除信息");
		this.deleteButton.setFont(FontUtil.f2);
		this.deleteButton.addActionListener(this);
		this.buttonsPanel.add(this.deleteButton);
		
		this.southPanel = new JPanel(new BorderLayout());
		this.infoLabel = new JLabel("共有?条记录");
		this.infoLabel.setFont(FontUtil.f2);
		this.southPanel.add(infoLabel,"West");
		this.southPanel.add(buttonsPanel,"East");
		
		this.setLayout(new BorderLayout());
		this.add(this.searchPanel,"North");
		this.add(this.dataGridViewPanel,"Center");
		this.add(this.southPanel,"South");
		this.setVisible(true);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		Object object = e.getSource();
		int row = dataGrid.getSelectedRow();
		if(this.deleteButton == object){
			if(-1 == row)
			{
				JOptionPane.showMessageDialog(this, "请选择需要删除的行!");
				return ;
			}
		}else if(this.detailButton == object){
			if(-1 == row)
			{
				JOptionPane.showMessageDialog(this, "请选择需要查看的行!");
				return ;
			}
		}else if( this.addButton == object){
			
			AddHRView hr = new AddHRView(null,"添加用户信息",true);
			hr.dispose();
			
		}else if(this.modityButton == object){
			if(-1 == row)
			{
				JOptionPane.showMessageDialog(this, "请选择需要修改的行!");
				return ;
			}
			
			DetailView detailView = new DetailView(null,"修改",true);
			detailView.dispose();
		}else if(this.searchButton == object){
			String searchKey = this.searchField.getText().trim();
			if(searchKey.equals(""))
			{
				JOptionPane.showMessageDialog(this, "搜索框中无数据");
				return;
			}
		}
	}

}
