**Cross Cutting Concern**
   * 是一种独立服务，它会遍布在系统的处理流程中。  
   
**Aspect**
   * 对横切性关注点的模块化(定义的类)   
 
**Advice**
   * 对横切性关注点的具体实现。（具体的拦截方法）  
   * Advice 分为三类
        1. advice before
        2. advice after
        3. advice exception
   
**JoinPoint**
   * 需要进行拦截的方法  
   * Advice在应用程序上执行的点或者时机，Spring只支持方法的joinPoint,这个点也可以支持属性修改，如AspectJ可以支持。
 
**Pointcut**
   * 它定义了Advice应用到那些JoinPoint（方法）上。
   
**Weave**
   * 将Advice应用到具体的TargetObject上的过程叫织入，Spring支持的时动态织入。  
   
**Target Object**
   * Advice 被应用的对象。  

**Proxy**
   * Spring AOP默认使用的JDK动态代理，它的代理是运行时创建，也可以使用CGLIB代理。  

## 了解表达式的基本语法
* 匹配返回值
* 匹配包
* 匹配方法
* 匹配参数
```xml
<beans>
<aop:config proxy-target-class="true">
        <aop:aspect id="securityAspect" ref="securityAOPWithConfigHandler">
<!--            <aop:pointcut id="addAddMethod" expression="execution(* com.ncsi.spring.manager.*.*(..))"/>-->
            <!-- 支持包下面的类中的所有add*和del*的方法。 -->
            <aop:pointcut id="addAddMethod" expression="execution(* com.ncsi.spring.manager.*.add*(..)) || execution(* com.ncsi.spring.manager.*.del*(..))"/>
            <aop:after method="checkSecurity" pointcut-ref="addAddMethod"/>
        </aop:aspect>
    </aop:config>
</beans>
```

如果目标对象实现了接口，在默认情况下会采用JDK的动态代理实现AOP。  
如果目标对象实现了接口，也可以强制使用CGLIB生成代理实现AOP。  
如果目标对象没有实现接口，必须引入CGLIB，Spring会在JDB动态代理和CGLIB代理动态代理。

如何强制使用CGLIB生产代码？  
```xml
<aop:aspectj-autoproxy xmlns="http://www.springframework.org/schema/aop" proxy-target-class="true">

</aop:aspectj-autoproxy>
```

JDK动态代理和CGLIB代理区别？
* JDK动态代理对实现了接口类进行代理。
* CGLIB代理可以对类代理，主要对指定的类生产一个子类，因为是继承目标类，所以主要使用final声明目标类。