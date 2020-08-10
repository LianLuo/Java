import com.example.spring.beans.Bean1;
import com.example.spring.beans.Bean2;
import junit.framework.TestCase;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class InjectionTest extends TestCase {
    private BeanFactory factory;
    @Override
    protected void setUp() throws Exception {
//        String[] resources = new String[]{
//                "ApplicationContext-base.xml",
//                "ApplicationContext-editor.xml",
//                "ApplicationContext-common.xml"
//        };
        String filePattern = "ApplicationContext-*.xml";
        factory = new ClassPathXmlApplicationContext(filePattern);
    }

    public void testInjection(){
        Bean1 bean1 = factory.getBean(Bean1.class);
        System.out.println("bean1.strVal="+bean1.getStrVal());
        System.out.println("bean1.intVal="+bean1.getIntVal());
        System.out.println("bean1.arrayVal="+bean1.getArrayVal());
        System.out.println("bean1.listVal="+bean1.getListVal());
        System.out.println("bean1.mapVal="+bean1.getMapVal());
        System.out.println("bean1.setVal="+bean1.getSetVal());
        System.out.println("bean1.dateVal="+bean1.getDateVal());
    }

    public void testInjection2(){
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
