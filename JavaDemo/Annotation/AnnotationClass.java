package Annotation;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

public class AnnotationClass{
    public static void main(String[] args){
       try{
            Report anno = Person.class.getAnnotation(Report.class);
            if(null != anno){
                System.out.println("level:"+anno.level());
                System.out.println("type:"+anno.type());
            }
       }catch(Exception e){
           e.printStackTrace();
       }
    }
}
@Target({
    ElementType.TYPE
})
@Retention(RetentionPolicy.RUNTIME)
@interface Report{
    int type() default 0;
    String level() default "info";
    String value() default "";
}

@Report(type = 2, level = "Warning")
class Person{

}