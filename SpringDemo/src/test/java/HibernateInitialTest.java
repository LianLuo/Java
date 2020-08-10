import com.example.spring.entities.UserEntity;
import com.example.spring.manager.IUserBusinessComponent;
import com.example.spring.manager.UserBusinessComponent;
import junit.framework.TestCase;

import java.util.Date;

public class HibernateInitialTest extends TestCase {

    public void testMappingDB(){
        IUserBusinessComponent userBC = new UserBusinessComponent();
        UserEntity userEntity = new UserEntity();
        userEntity.setName("duxiaoqiang");
        userEntity.setDetail("hello");
        userEntity.setTime(new Date());
        userBC.addUser(userEntity);
    }
}
