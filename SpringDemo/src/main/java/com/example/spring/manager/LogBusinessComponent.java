package com.example.spring.manager;

import com.example.spring.entities.LogEntity;
import com.example.spring.utils.HibernateUtils;

public class LogBusinessComponent implements ILogBusinessComponent{
    @Override
    public void addLog(LogEntity logEntity) {
        HibernateUtils.getSessionFactory().getCurrentSession().save(logEntity);
    }
}
