Spring和Hibernate的集成（编程式事务）
1. OpenSession和getCurrentSession的区别
   * OpenSession必须关闭，currentSession在事务结束后自动关闭。
   * openSession没有和当前线程绑定，currentSession和当前线程绑定。
   
2. 如果使用currentSession需要在hibernate.cfg.xml文件中进行配置：
   * 如果是本地事务(jdbc事务)
   ```xml
       <property name="hibernate.current_session_context_class">thread</property>
    ```
   * 如果是全局事务(jta事务)
   ```xml
    <property name="hibernate.current_session_context_class">jta</property>
    ```
   
3. 事务的几种传播性
    1. Required:如果存在一个事务，则支持当前事务。如果没有事务则开启。
    2. Supports:如果存在一个事务，支持当前事务；如果没有事务，则非事务执行。
    3. Mandatory:如果已经存在一个事务，支持当前事务；如果没有一个活动事务，则抛异常。
    4. RequiredNew:总是开启一个新的事务；如果一个事务已经存在，则将这个存在的事务挂起。
    5. NotSupported:总是非事务执行，并挂起任何存在的事务。
    6. Never:总是非事务执行；如果存在一个活动事务，则抛异常。
    
| 传播特性属性 | T1 | T2 |
| ---- | ---- | ---- |
| Required | None | T2 |
| Required | T1 | T1 |
| RequiredNew | None | T2 |
| RequiredNew | T1 | T2 |
| Supports | None | None |
| Supports | T1 | T1 |
| Mandatory | None | Exception |
| Mandatory | T1 | T1 |
| NotSupported | None | None |
| NotSupported | T1 | None |
| Never | None | None |
| Never | T1 | Exception |
