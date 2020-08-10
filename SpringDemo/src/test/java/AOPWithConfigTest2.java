import com.example.spring.manager.UserManagerImp;
import junit.framework.TestCase;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class AOPWithConfigTest2 extends TestCase {
    private BeanFactory factory;
    @Override
    protected void setUp() throws Exception {

        String filePattern = "ApplicationContext-aop-withconfig2.xml";
        factory = new ClassPathXmlApplicationContext(filePattern);
    }

    /**
     * 采用指定包名下面的所有类，所有方法都生效。
     */
    public void testAOPWithConfigOtherMethod(){
        UserManagerImp userManager = factory.getBean(UserManagerImp.class);
        String userName = userManager.findUserById(12);
        println(userName);
    }
    private void println(Object obj){
        System.out.println(obj);
    }
    @Override
    protected void tearDown() throws Exception {
        super.tearDown();
    }
}
