package com.mhl.moduls;

import java.util.*;

public interface IDao<T> {

	/**
	 * 添加一条数据
	 * @param entity 对象实体
	 * @return 受影响的行数
	 */
	int add(T entity);
	
	/**
	 * 通过id删除一条数据
	 * @param id 主键ID
	 * @return 受影响的行数
	 */
	int delete(int id);
	
	/**
	 * 通过id删除一条数据
	 * @param id 主键ID
	 * @return 受影响的行数
	 */
	int delete(String id);
	
	/**
	 * 通过实体对象删除一条数据
	 * @param id 主键ID
	 * @return 受影响的行数
	 */
	int delete(T entity);
	
	/**
	 * 更新数据
	 * @param entity
	 * @return 受影响行数
	 */
	int update(T entity);
	
	/**
	 * 通过ID获取一个对象
	 * @param id
	 * @return
	 */
	T getEntity(int id);
	
	/**
	 * 通过ID获取一个对象
	 * @param id
	 * @return
	 */
	T getEntity(String id);
	
	/**
	 * 获取所有数据
	 * @return
	 */
	List<T> getAll();
	
	/**
	 * 通过条件获取数据
	 * @param condition
	 * @return
	 */
	List<T> getAll(String condition);
}
