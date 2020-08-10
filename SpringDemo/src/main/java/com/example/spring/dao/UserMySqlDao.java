package com.example.spring.dao;

public class UserMySqlDao implements UserDao{
    public void save(String userName, String pwd) {
        System.out.println("UserMySqlDao::save");
    }
}
