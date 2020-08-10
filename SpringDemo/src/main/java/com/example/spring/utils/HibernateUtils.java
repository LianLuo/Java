package com.example.spring.utils;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;


public class HibernateUtils {
    private static SessionFactory factory;
    private HibernateUtils(){}

    static {
        try{
            Configuration cfg = new Configuration().configure();
            factory = cfg.buildSessionFactory();
        }catch (Exception e){
            e.printStackTrace();
            throw new RuntimeException(e);
        }
    }

    public static SessionFactory getSessionFactory(){
        return factory;
    }

    public static Session getSession(){
        return factory.openSession();
    }

    public static void closeSession(Session session){
        if(null != session){
            session.close();
        }
    }
}
