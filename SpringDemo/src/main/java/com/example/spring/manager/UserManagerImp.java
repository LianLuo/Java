package com.example.spring.manager;

import com.example.spring.dao.UserDao;

public class UserManagerImp implements UserManager{

    public UserDao getUserDao() {
        return userDao;
    }

    public void setUserDao(UserDao userDao) {
        this.userDao = userDao;
    }

    private UserDao userDao;
//    public UserManagerImp(UserDao userDao){
//        this.userDao = userDao;
//    }
    public void save(String userName, String pwd) {
        this.userDao.save(userName,pwd);
    }

    @Override
    public void delUser(int userId) {
        System.out.println("UserManagerImp::delUser");
    }

    @Override
    public String findUserById(int userId) {
        System.out.println("UserManagerImp::findUserById");
        return null;
    }

    @Override
    public void modifyUser(int userId, String userName, String pwd) {
        System.out.println("UserManagerImp::modifyUser");
    }
}
