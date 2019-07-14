package com.mhl.views;

import java.awt.Dimension;
import java.awt.Toolkit;
import java.util.Vector;

import javax.swing.JWindow;

import com.mhl.models.DataTable;
import com.mhl.models.UserInfo;
import com.mhl.moduls.DbSession;
import com.mhl.moduls.UserInfoDao;

import java.lang.*;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

public class IndexView extends JWindow implements Runnable{

	FlashView flashView;
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IndexView indexView = new IndexView();
		Thread thread = new Thread(indexView);
		thread.start();

//		UserInfo userInfo = new UserInfo();
//		userInfo.setId(12);
//		userInfo.setAge(26);
//		userInfo.setRemark("AAAA");
//		userInfo.setUserGender(false);
//		userInfo.setUserName("luolian");
//		UserInfoDao dao = new UserInfoDao();
//		dao.print(userInfo);
		
	}

	public IndexView(){
		flashView = new FlashView();
		this.add(flashView);
		this.setSize(400,250);
		Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
		this.setLocation(dimension.width/2-200, dimension.height/2-150);
		//this.setAlwaysOnTop(true);
		this.setVisible(true);
	}
	
	@Override
	public void run() {
		// TODO Auto-generated method stub
		while(true){
			try{
				Thread.sleep(3*500);
				flashView.setThreadDisponse();
			}catch (InterruptedException e) {
				// TODO: handle exception
			}
			System.out.println("Thread over");
			LoginView login = new LoginView();
			this.dispose();
			break;
		}
	}

}
