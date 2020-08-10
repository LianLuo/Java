package com.example.spring.dao;

public class UserOracleDao implements UserDao{
    public void save(String userName, String pwd) {
        System.out.println("UserOracleDao::save");
    }
}
