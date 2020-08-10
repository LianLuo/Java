package com.example.spring.beans;

import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class Bean1 {
    private String strVal;
    private int intVal;
    private List listVal;
    private Set setVal;
    private String[] arrayVal;
    private Map mapVal;

    public Date getDateVal() {
        return dateVal;
    }

    public void setDateVal(Date dateVal) {
        this.dateVal = dateVal;
    }

    private Date dateVal;

    public String getStrVal() {
        return strVal;
    }

    public void setStrVal(String strVal) {
        this.strVal = strVal;
    }

    public int getIntVal() {
        return intVal;
    }

    public void setIntVal(int intVal) {
        this.intVal = intVal;
    }

    public List getListVal() {
        return listVal;
    }

    public void setListVal(List listVal) {
        this.listVal = listVal;
    }

    public Set getSetVal() {
        return setVal;
    }

    public void setSetVal(Set setVal) {
        this.setVal = setVal;
    }

    public String[] getArrayVal() {
        return arrayVal;
    }

    public void setArrayVal(String[] arrayVal) {
        this.arrayVal = arrayVal;
    }

    public Map getMapVal() {
        return mapVal;
    }

    public void setMapVal(Map mapVal) {
        this.mapVal = mapVal;
    }
}
