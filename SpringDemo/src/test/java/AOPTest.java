import com.example.spring.manager.UserManagerImp;
import junit.framework.TestCase;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class AOPTest extends TestCase {
    private BeanFactory factory;
    @Override
    protected void setUp() throws Exception {

        String filePattern = "ApplicationContext-aop.xml";
        factory = new ClassPathXmlApplicationContext(filePattern);
    }

    public void testAOP(){
        UserManagerImp userManager = (UserManagerImp)factory.getBean("userManager");
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
