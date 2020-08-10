package com.example.spring.manager;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

/**
 * 动态代理
 * 这个类在AOP中成为 Aspect
 *
 * 针对全局的约束，叫做Pointcut:(add*)
 */
public class SecurityHandler implements InvocationHandler {
    private Object targetObject;
    public Object createProxyInstance(Object targetObject){
        this.targetObject = targetObject;
        Object proxy = Proxy.newProxyInstance(targetObject.getClass().getClassLoader(),
                                              targetObject.getClass().getInterfaces(),
                                            this);
        return proxy;
    }
    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        checkSecurity();
        // 调用目标方法
        Object obj = method.invoke(targetObject, args);
        return obj;
    }

    /**
     * 对横切性的关注点的具体实现成为Advice
     * Advice可以分为：
     * Before Advice，方法前执行
     * After Advice， 方法后执行
     * Throw Advice，抛异常时执行。
     *
     * 被修饰的方法叫着 JoinPoint
     */
    private void checkSecurity(){
        System.out.println("---------checkSecurity------------");
    }
}
