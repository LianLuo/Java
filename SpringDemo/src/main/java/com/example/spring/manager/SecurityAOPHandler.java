package com.example.spring.manager;

import org.aspectj.lang.annotation.*;

@Aspect
public class SecurityAOPHandler {

    /**
     * 定义Pointcut,Pointcut的名称为AddAddMethod(),此方法没有返回值和参数。
     * 该方法就是一个标识，不进行调用。
     * * del*(...) 第一个* 表示匹配有返回值和没有返回值；第二个del*表示：以del为前缀的所有方法;(..)表示函数中匹配所有参数（不管是否有参数）。
     */
    @Pointcut("execution(* del*(..))")
    private void addAddMethod(){}

    /**
     * 定义Advice
     * 表示Advice应用到那些Pointcut的订阅的Joinpoint上。
     */
    @After("addAddMethod()")
    public void checkSecurity(){
        System.out.println("SecurityAOPHandler::checkSecurity");
    }
}
