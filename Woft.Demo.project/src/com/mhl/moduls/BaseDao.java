package com.mhl.moduls;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.List;

public abstract class BaseDao<T> implements IDao<T>{

	private boolean isDescending;
	protected String primaryKey;
	protected String selectedFields;
	protected String sortFields;
	protected String tableName;
	private DbSession dbSession;
	
	public BaseDao()
	{
		this.sortFields = "ID";
		this.selectedFields = "*";
		this.isDescending = true;
		this.dbSession = new DbSession();
	}
	
	public BaseDao(String tableName,String primaryKey){
		this();
		this.tableName = tableName;
		this.primaryKey = primaryKey;
	}
	
	
	@Override
	public int add(T entity) {
		// TODO Auto-generated method stub
		Class<?> type = entity.getClass();
		List<Object> vals = new ArrayList<Object>();
		List<String> fields = new ArrayList<String>();
		List<String> params = new ArrayList<String>();
		int result = -1;
		try{
			for(;type!=Object.class;type = type.getSuperclass())
			{
				Field[] fieldInfos = type.getDeclaredFields();
				for(int i =0;i<fieldInfos.length;i++){
					Field fieldInfo = fieldInfos[i];
					fieldInfo.setAccessible(true);
					fields.add(fieldInfo.getName());
					params.add("?");
					vals.add(fieldInfo.get(entity));					
				}
			}
		}catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		
		String sql = String.format("INSERT INTO `%s` (%s) VALUES (%s);", this.tableName,joinString(fields,","),joinString(params, ","));
		
	    System.out.println(sql);
	    for(Object item : vals){
	    	System.out.print(item.toString()+"\t");
	    }
	    
		//result = dbSession.executeNonQuery(sql, List2Array(vals));		
		
		
		return result;
	}

	@Override
	public int delete(int id) {
		// TODO Auto-generated method stub
		return delete(""+id);
	}

	@Override
	public int delete(String id) {
		// TODO Auto-generated method stub
		String sql = String.format("DELETE FROM `%s` WHERE `%s`=?", this.tableName,this.primaryKey);
		String key = ""+id;
		String[] params  = {key};
		
		return dbSession.executeNonQuery(sql, params);
	}

	@Override
	public int delete(T entity) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public List<T> getAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<T> getAll(String condition) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public T getEntity(int id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public T getEntity(String id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public int update(T entity) {
		// TODO Auto-generated method stub
		return 0;
	}
	
	private String joinString(List<String> array,String connectionStr){
		StringBuffer sb = new StringBuffer();
		int count = array.size();
		for(int i =0;i<count;i++)
		{
			if(i==count-1)
			{
				sb.append(array.get(i));
			}else{
				sb.append(array.get(i)+connectionStr);
			}
		}
		return sb.toString();
	}
	
	private String joinStringForField(List<String> array,String connectionStr){
		StringBuffer sb = new StringBuffer();
		int count = array.size();
		for(int i =0;i<count;i++)
		{
			if(i==count-1)
			{
				sb.append("`"+array.get(i)+"`");
			}else{
				sb.append("`"+array.get(i)+"`"+connectionStr);
			}
		}
		return sb.toString();
	}
	
	private String[] List2Array(List<Object> vals)
	{
		String[] items = new String[vals.size()];
		for(int i =0;i<vals.size();i++)
		{
			items[i] = vals.get(i).toString();
		}
		
		return items;
	}
}
