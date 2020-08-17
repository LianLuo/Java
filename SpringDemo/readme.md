## Spring Framework
 1. Spring的依赖包配置
    > spring-beans  
    > spring-context  
    
    使用maven进行管理。
 2. 提供spring的配置文件ApplicationContext.xml
 3. 提供log4j.properties配置文件
     ```xml
    <beans>
        <bean id="userDao4MySql" class="com.example.spring.dao.UserMySqlDao"/>
        <bean id="userDao4Oracle" class="com.example.spring.dao.UserOracleDao"/>
        <bean id="userManagerImp" class="com.example.spring.manager.UserManagerImp">
            <constructor-arg name="userDao" ref="userDao4Oracle"/>
        </bean>
    </beans>
    ```
4. 在UserManagerImp中提供构造函数，让Spring将UserDao注入（DI）。
5. 让Spring管理对象的创建和依赖，必须将依赖关系配置到Spring的配置文件中。

**`IoC`**控制反转：本来是由应用程序管理的对象之间的依赖关系，现在交给了容器管理，这就叫控制反转，即交给了`IoC`容器，Spring的`IoC`容器主要使用DI方式实现的。
不需要主动查找；查找，定位和创建都由容器管理。  
1. 大量减少了Factory和Singleton数量。使代码层次更加清晰，主要原因是我们不在查找，定位，创建和管理对象之间的依赖关系，这些关系都交给了`IoC`容器管理了。
2. Spring的`IoC`容器是一个轻量级的容器，没有侵入性，不需要依赖容器中的API，也不需要一些特殊接口。
3. 一个合理的设计最好避免侵入性。
4. 会使框架(Struts && Hibernate)工作更好
5. 提供了AOP声明式服务能力，可以针对POJO对象提供声明式服务能力。如：声明式事务。
6. 对于资源，如Hibernate Session或JDBC Connection,开发不再负责开启和关闭。
7. 鼓励程序员面向接口编程。
8. 减少了代码中的耦合度，将耦合推迟到了配置文件中，发生变化更好容易控制。

### 注入
> 注入分为构造函数注入，属性注入和函数注入这三种，Spring最常用的是属性和构造函数的注入。  

当对象属性比较对的时候，推荐使用属性注入的方式，因为不需要在构造函数中写入太多的参数。

### 什么是属性编辑器
* 将Spring配置文件中的字符串转换成相应的Java对象。  
* Spring内置了一些属性编辑器，也可以自定义属性编辑器。

### 如何自定义属性编辑器?
* 继承PropertyEditorSupport
* 重写setAsText()方法
* 将自定义的属性编辑器注入到Spring中。

### 了解关于多配置文件读取方式
* 可以采用数组 e.g String[] filesPath = new String[]{ "ApplicationContext-base.xml","ApplicationContext-common.xml"};
* 可以采用*匹配模式。 e.g String filePattern = "ApplicationContext-*.xml";

### 如何减少Spring的配置文件
* 通过<bean>标签将公共的配置提取出来，然后指定<bean>标签的abstract属性为true.
* 在其他<bean>标签中制定其parent即可。
参看ApplicationContext-common.xml

Spring默认在创建BeanFactory时，将配置文件中所有的对象都初始化并注入，但是可以通过标签标记，延迟配置文件的初始化。
e.g default-lazy-init="true"

### Spring Bean的作用域
* Scope取值
    1. singleton:默认值，每次调用getBean都是返回相同对象。
    2. prototype:每次调用getBean()返回都是全新对象。
    
    
- ----------------
### Spring和Struts的依赖包配置（第一种）
* Struts
    1. 拷贝struts和jstl的依赖
    2. 在Web.xml文件中配置ActionServlet
    3. 提供struts-config.xml文件
    4. 提供国际化支持，提供缺省的国际化资源文件
    
* Spring
    1. 拷贝spring相关依赖包
    2. 提供Spring的配置文件

在web.xml文件中配置ContextLoaderListener,让web Server在启动的时候将BeanFactory放在ServletContext中。
```xml
<context-param>
    <param-name>contextConfiguration</param-name>
    <param-value>classpath:applicationContext-*.xml</param-value>    
</context-param>

<listener>
    <listener-class>org.springframework.web.context.ContextLoaderListener</listener-class>
</listener>
```

在Action中采用WebApplicationContextUtils.getRequestWebApplicationContext()从ServletContext中取得BeanFactory.  

通过BeanFactory从IoC容器中获取业务逻辑对象。

> 上面的存在依赖查找，所以Action依赖Spring的API。
>
- --
### Spring和Struts的依赖包配置（第二种）
集成原理，将Struts的Action交给Spring创建。这样业务逻辑将会被注入。（避免依赖查找 ）
* Struts
    1. 拷贝struts和jstl的依赖
    2. 在Web.xml文件中配置ActionServlet
    3. 提供struts-config.xml文件
    4. 提供国际化支持，提供缺省的国际化资源文件
    
* Spring
    1. 拷贝spring相关依赖包
    2. 提供Spring的配置文件

在web.xml文件中配置ContextLoaderListener,让web Server在启动的时候将BeanFactory放在ServletContext中。
```xml
<context-param>
    <param-name>contextConfiguration</param-name>
    <param-value>classpath:applicationContext-*.xml</param-value>    
</context-param>

<listener>
    <listener-class>org.springframework.web.context.ContextLoaderListener</listener-class>
</listener>
```

struts-config.xml文件中<action>标签的type属性需要更改为Spring的代理类:org.springframework.web.DelegateActionProxy代理Action的
作用：取得BeanFactory,然后到IoC容器中将本次请求对应的Action取出。  

将Action交给Spring创建，必须创建业务逻辑对象，注入到Action。
```xml
<bean name="/login" class="com.example.spring.actions.LoginAction">
    <property name="userManager" ref="userManager"/>
</bean>
```

必须使用name属性，而且name属性值，必须和struts-config.xml中<action>标签中的属性值一致。  
必须配置业务逻辑对象。   
建议将Scope设置为prototype,这样struts的action将是线程安全的。
