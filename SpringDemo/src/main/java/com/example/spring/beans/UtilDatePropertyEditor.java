package com.example.spring.beans;

import java.beans.PropertyEditorSupport;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class UtilDatePropertyEditor extends PropertyEditorSupport {
    public String getFormat() {
        return format;
    }

    public void setFormat(String format) {
        this.format = format;
    }

    private String format="yyyy-mm-dd";
    @Override
    public void setAsText(String text) throws IllegalArgumentException {
        System.out.println("UtilDatePropertyEditor::setAsText---"+text);
        try {
            Date date = new SimpleDateFormat(format).parse(text);
            this.setValue(date);
        } catch (ParseException e) {
            e.printStackTrace();
            throw new IllegalArgumentException(e);
        }
    }
}
