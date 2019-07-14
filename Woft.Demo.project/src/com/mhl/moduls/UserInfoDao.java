package com.mhl.moduls;

import com.mhl.models.UserInfo;

public class UserInfoDao extends BaseDao<UserInfo>{

	public UserInfoDao(){
		super("UserInfo", "ID");
	}
	
	public void print(UserInfo info)
	{
		this.add(info);
	}
}
