import com.example.spring.entities.UserEntity;
import com.example.spring.manager.IUserBusinessComponent;
import com.example.spring.manager.UserBusinessComponentHibernateDaoSupport;
import junit.framework.TestCase;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.util.Date;

public class HibernateDaoSupportTest extends TestCase {
    private BeanFactory factory;
    @Override
    protected void setUp() throws Exception {
        this.factory = new ClassPathXmlApplicationContext("ApplicationContext-hibernatedaosupport.xml");
    }

    public void testHibernateDaoSupport(){

        UserEntity userEntity = new UserEntity();
        userEntity.setTime(new Date());
        userEntity.setDetail("add some information");
        userEntity.setName("Lucy");
        // 这里必须用接口，不能用实体类，因为这里采用的代理，转换不到实体类上。
        IUserBusinessComponent daoSupport = (IUserBusinessComponent)this.factory.getBean("userManager");
        daoSupport.addUser(userEntity);
    }
}
