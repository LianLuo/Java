package com.example.spring.manager;

import com.example.spring.entities.LogEntity;
import com.example.spring.util.HibernateUtil;

public class LogBusinessComponent implements ILogBusinessComponent{
    @Override
    public void addLog(LogEntity logEntity) {

        HibernateUtil.getSessionFactory().getCurrentSession().save(logEntity);
    }
}
