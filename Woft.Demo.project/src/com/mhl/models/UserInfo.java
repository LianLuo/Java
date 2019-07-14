package com.mhl.models;

/**
 * @author lWX240898
 * @date 2016-12-30
 */
public class UserInfo extends Entity {

	private String userName;
	private boolean userGender;
	private int age;
	private String remark;
	
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public boolean isUserGender() {
		return userGender;
	}
	public void setUserGender(boolean userGender) {
		this.userGender = userGender;
	}
	public int getAge() {
		return age;
	}
	public void setAge(int age) {
		this.age = age;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
}
