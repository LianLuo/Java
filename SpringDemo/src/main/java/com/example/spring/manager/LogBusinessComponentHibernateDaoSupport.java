package com.example.spring.manager;

import com.example.spring.entities.LogEntity;
import org.springframework.orm.hibernate5.support.HibernateDaoSupport;

public class LogBusinessComponentHibernateDaoSupport extends HibernateDaoSupport implements ILogBusinessComponent {
    @Override
    public void addLog(LogEntity logEntity) {
        this.getHibernateTemplate().save(logEntity);
    }
}
