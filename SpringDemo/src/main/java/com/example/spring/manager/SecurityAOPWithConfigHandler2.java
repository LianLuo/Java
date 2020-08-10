package com.example.spring.manager;

import org.aspectj.lang.JoinPoint;

import java.util.stream.Stream;

/**
 * 在切入点中添加Joinpoint参数
 */
public class SecurityAOPWithConfigHandler2 {
    public void checkSecurity(JoinPoint joinpoint){
        System.out.println("入参值：");
        Stream.of(joinpoint.getArgs()).forEach(p->{
            System.out.println(p);
        });
        System.out.println("方法名："+joinpoint.getSignature().getName());
        System.out.println("SecurityAOPWithConfigHandler::checkSecurity");
    }
}
