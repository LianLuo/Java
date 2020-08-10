package com.example.spring.manager;

import com.example.spring.entities.LogEntity;
import com.example.spring.entities.UserEntity;
import com.example.spring.util.HibernateUtil;
import org.hibernate.Session;

public class UserBusinessComponent implements IUserBusinessComponent{
    @Override
    public void addUser(UserEntity userEntity) {
        Session session = null;
        try{
            //session = HibernateUtil.getSession();
            session = HibernateUtil.getSessionFactory().getCurrentSession();
            session.beginTransaction();

            session.save(userEntity);

            LogEntity log = new LogEntity();
            log.setType("record");
            ILogBusinessComponent ilog = new LogBusinessComponent();
            ilog.addLog(log);

            Integer.parseInt("123123ssd");

            session.getTransaction().commit();
        }catch (Exception e){
            e.printStackTrace();
            session.getTransaction().rollback();
        }finally {
            // 如果是currentSession不需要手动关闭
            //HibernateUtil.closeSession(session);
        }
    }
}
