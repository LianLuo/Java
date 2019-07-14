package com.mhl.models;

import java.util.Vector;

import javax.swing.table.AbstractTableModel;

public class DataTable extends AbstractTableModel{

	private Vector<String> columns;
	private Vector<Vector> rows;
	public DataTable(){
		columns = new Vector<String>();
		rows = new Vector<Vector>();
	}	
	
	public Vector<String> getColumns(){
		return columns;
	}
	
	public Vector<Vector> getRows()
	{
		return rows;
	}	
	
	public int getColumnCount(){
		return this.columns.size();
	}
	public int getRowCount(){
		return this.rows.size();
	}
	
	public Object getValueAt(int rowIndex,int columnIndex){
		if(rows.size()< rowIndex)
		{
			return null;
		}
		Vector vector = rows.get(rowIndex);
		if(vector.size() < columnIndex){
			return null;
		}
		return vector.get(columnIndex);
	}
	
	public String getColumnName(int column){
		if(this.columns.size() < column){
			return null;
		}
		return this.columns.get(column).toString();
	}

	public Vector<String> getColumnData(String name)
	{
		int index = -1;
		for(int i = 0;i<this.columns.size();i++){
			if(this.columns.get(i).toString() == name)
			{
				index = i;
			}
		}
		
		if(index == -1)
		{
			return null;
		}
		
		Vector<String> columns = new Vector<String>();
		
		for(int i = 0;i<this.getRowCount();i++)
		{
			columns.add(getValueAt(i,index).toString());
		}
		
		return columns;
	}
}
