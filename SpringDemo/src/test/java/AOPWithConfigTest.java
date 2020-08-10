import com.example.spring.manager.UserManagerImp;
import junit.framework.TestCase;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class AOPWithConfigTest extends TestCase {
    private BeanFactory factory;
    @Override
    protected void setUp() throws Exception {

        String filePattern = "ApplicationContext-aop-withconfig.xml";
        factory = new ClassPathXmlApplicationContext(filePattern);
    }

    public void testAOPWithConfig(){
        UserManagerImp userManager = factory.getBean(UserManagerImp.class);
        userManager.delUser(12);
    }

    private void println(Object obj){
        System.out.println(obj);
    }
    @Override
    protected void tearDown() throws Exception {
        super.tearDown();
    }
}
