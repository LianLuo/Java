package com.mhl.utils;

import java.lang.reflect.Field;  

import java.lang.reflect.InvocationTargetException;  
import java.lang.reflect.Method;

public class ReflectionUtils {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public static Method getDeclaredMethod(Object object,String methodName,Class<?> ...parameterTyppes){
		Method method = null;
		
		for(Class<?> clazzClass = object.getClass();clazzClass!=Object.class;clazzClass.getSuperclass())
		{
			try{
				method = clazzClass.getDeclaredMethod(methodName, parameterTyppes);
				return method;
			}catch (Exception e) {
				// TODO: handle exception
			}
		}
		
		return method;
	}

	
	public static Object invokeMethod(Object object,String methodName,Class<?>[] parameterTypes,Object[] paramstes){
		Method method = getDeclaredMethod(object, methodName, parameterTypes);
		
		method.setAccessible(true);
		try{
			if(null != method)
			{
				return method.invoke(object, paramstes);
			}
		}catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
	
	public static Field getDeclaredField(Object object,String fieldName){
		Field field = null;
		Class<?> clazz = object.getClass();
		for(;clazz!=Object.class;clazz.getSuperclass())
		{
			try{
				field = clazz.getDeclaredField(fieldName);
				return field;
			}catch (Exception e) {
				// TODO: handle exception
			}			
		}
		return null;
	}
	
	public static Object getFieldValue(Object object,String fieldName){
		Field field = getDeclaredField(object, fieldName);
		
		field.setAccessible(true);
		try{
			return field.get(object);
		}catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
	

}
