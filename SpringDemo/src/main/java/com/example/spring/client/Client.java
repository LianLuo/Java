package com.example.spring.client;

import com.example.spring.manager.SecurityHandler;
import com.example.spring.manager.UserManager;
import com.example.spring.manager.UserManagerImp;

public class Client {
    public static void main(String[] args) {
//        BeanFactory factory = new ClassPathXmlApplicationContext("ApplicationContext-base.xml");
//        UserManager userManager = (UserManager)factory.getBean("userManagerImp");
//        UserManager userManager = factory.getBean(UserManagerImp.class);
//        UserManager userManager = new UserManagerImp(new UserMySqlDao());
//        userManager.save("A","B");
        UserManager proxy = (UserManager)new SecurityHandler().createProxyInstance(new UserManagerImp());
        proxy.save("as","asd");
    }
}
