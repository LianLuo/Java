import com.example.spring.beans.Bean2;
import junit.framework.TestCase;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class AutowiredTest extends TestCase {
    private BeanFactory factory;
    @Override
    protected void setUp() throws Exception {

        String filePattern = "ApplicationContext-autowired.xml";
        factory = new ClassPathXmlApplicationContext(filePattern);
    }

    public void testAutowired(){
        Bean2 bean2 = factory.getBean(Bean2.class);
        println(bean2.getBean3().getId());
        println(bean2.getBean3().getName());
        println(bean2.getBean3().getSex());

        println(bean2.getBean4().getAge());
        println(bean2.getBean4().getId());
        println(bean2.getBean4().getName());
        println(bean2.getBean4().getSex());

        println(bean2.getBean5().getPassword());
    }
    private void println(Object obj){
        System.out.println(obj);
    }
    @Override
    protected void tearDown() throws Exception {
        super.tearDown();
    }
}
