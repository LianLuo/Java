package com.example.spring.manager;

public interface UserManager {
    void save(String userName, String pwd);
    void delUser(int userId);
    String findUserById(int userId);
    void modifyUser(int userId, String userName, String pwd);
}
