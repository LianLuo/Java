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
 * ���¹���ҳ��
 * @author Multi
 *
 */
public class HRManageView extends JPanel implements ActionListener{

	JPanel searchPanel;
	JPanel dataGridViewPanel;
	JPanel southPanel;
	JPanel buttonsPanel;
	
	JLabel infoLabel; // ������Ϣ
	JLabel searchLabel;// ������Ϣ
	JTextField searchField; //������
	JButton searchButton; // ������ť
	JButton addButton; // ��Ӱ�ť
	JButton modityButton; // �޸İ�ť
	JButton deleteButton; // ɾ����ť
	JButton detailButton; // ���鰴ť
	
	JTable dataGrid;
	DataTable dt;
	
	JScrollPane scrollPane;//֧�ֹ���
	
	public HRManageView(){
		dt = new DataTable();
		//initialDataTable();
		initialComponent();
	}
	
	private void initialComponent(){
		this.searchPanel = new JPanel(new FlowLayout());
		this.searchLabel = new JLabel("����������(Ա������):");
		this.searchLabel.setFont(FontUtil.f2);
		this.searchPanel.add(this.searchLabel);
		
		this.searchField = new JTextField(20);
		this.searchField.setBorder(BorderFactory.createLoweredBevelBorder());
		this.searchPanel.add(this.searchField);
		
		this.searchButton = new JButton("��  ��");
		this.searchButton.addActionListener(this);
		this.searchPanel.add(this.searchButton);
		
		// center panel
		Vector<String> columns = new Vector<String>();
		Vector<Vector> rows = new Vector<Vector>();
		Vector<String> cols = columns;
		cols.add("����");
		cols.add("����");
		cols.add("�Ա�");
		cols.add("����");
		cols.add("ְλ");
		cols.add("ѧ��");
		cols.add("�Ƿ����");
		
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
		this.scrollPane = new JScrollPane(dataGrid);// ע�⣬��DataGridView��ӵ�JScrollPane�У���Ҫ�ڹ��캯���������
		this.dataGridViewPanel= new JPanel(new BorderLayout());
		this.dataGridViewPanel.add(scrollPane,"Center");
		
		
		// sourth panel		
		this.buttonsPanel = new JPanel(new FlowLayout());
		this.detailButton = new JButton("�鿴����");
		this.detailButton.setFont(FontUtil.f2);
		this.detailButton.addActionListener(this);
		this.buttonsPanel.add(this.detailButton);
		
		this.addButton = new JButton("�����Ϣ");
		this.addButton.setFont(FontUtil.f2);
		this.addButton.addActionListener(this);
		this.buttonsPanel.add(this.addButton);
		
		this.modityButton = new JButton("�޸���Ϣ");
		this.modityButton.setFont(FontUtil.f2);
		this.modityButton.addActionListener(this);
		this.buttonsPanel.add(this.modityButton);
		
		this.deleteButton = new JButton("ɾ����Ϣ");
		this.deleteButton.setFont(FontUtil.f2);
		this.deleteButton.addActionListener(this);
		this.buttonsPanel.add(this.deleteButton);
		
		this.southPanel = new JPanel(new BorderLayout());
		this.infoLabel = new JLabel("����?����¼");
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
				JOptionPane.showMessageDialog(this, "��ѡ����Ҫɾ������!");
				return ;
			}
		}else if(this.detailButton == object){
			if(-1 == row)
			{
				JOptionPane.showMessageDialog(this, "��ѡ����Ҫ�鿴����!");
				return ;
			}
		}else if( this.addButton == object){
			
			AddHRView hr = new AddHRView(null,"����û���Ϣ",true);
			hr.dispose();
			
		}else if(this.modityButton == object){
			if(-1 == row)
			{
				JOptionPane.showMessageDialog(this, "��ѡ����Ҫ�޸ĵ���!");
				return ;
			}
			
			DetailView detailView = new DetailView(null,"�޸�",true);
			detailView.dispose();
		}else if(this.searchButton == object){
			String searchKey = this.searchField.getText().trim();
			if(searchKey.equals(""))
			{
				JOptionPane.showMessageDialog(this, "��������������");
				return;
			}
		}
	}

}
