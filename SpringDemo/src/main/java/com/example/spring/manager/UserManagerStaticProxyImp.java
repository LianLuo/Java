package com.example.spring.manager;

public class UserManagerStaticProxyImp implements UserManager{
    private UserManager userManager;
    public UserManagerStaticProxyImp(UserManager userManager){
        this.userManager = userManager;
    }
    @Override
    public void save(String userName, String pwd) {
        checkSecurity();
        this.userManager.save(userName, pwd);
    }

    @Override
    public void delUser(int userId) {
        checkSecurity();
        this.delUser(userId);
    }

    @Override
    public String findUserById(int userId) {
        checkSecurity();
        return this.userManager.findUserById(userId);
    }

    @Override
    public void modifyUser(int userId, String userName, String pwd) {
        checkSecurity();
        this.userManager.modifyUser(userId, userName, pwd);
    }

    private void checkSecurity(){
        System.out.println("UserManagerStaticProxyImp::checkSecurity");
    }
}
