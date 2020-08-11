package com.example.spring.manager;

import com.example.spring.entities.LogEntity;
import com.example.spring.entities.UserEntity;
import org.springframework.orm.hibernate5.support.HibernateDaoSupport;

public class UserBusinessComponentHibernateDaoSupport extends HibernateDaoSupport implements IUserBusinessComponent {

    public void setLogBusinessComponent(ILogBusinessComponent logBusinessComponent) {
        this.logBusinessComponent = logBusinessComponent;
    }

    private ILogBusinessComponent logBusinessComponent;
    @Override
    public void addUser(UserEntity userEntity) throws RuntimeException{
        //this.getSessionFactory().getCurrentSession().save(userEntity);
        this.getHibernateTemplate().save(userEntity);

        LogEntity logEntity = new LogEntity();
        logEntity.setType("Record");
        new RuntimeException("ABC");
        this.logBusinessComponent.addLog(logEntity);
    }
}
