package Generic;

import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;

public class GenericClass {
    public static void main(final String[] args) throws Exception{
        System.out.println("Hello world");
        Class<IntPair> clazz = IntPair.class;
        Type t = clazz.getGenericSuperclass();
        if(t instanceof ParameterizedType){
            final ParameterizedType pt = (ParameterizedType) t;
            final Type[] types = pt.getActualTypeArguments();
            final Type firstType = types[0];
            final Class<?> typeclass = (Class<?>) firstType;
            System.out.println(typeclass);
        }

        IntPair p = new IntPair(123, 456);
        int n = add(p);
        System.out.println(n);
        setSame(p, 100);
        System.out.println(p.getFirst()+","+p.getLast());
    }

    // 通配符，类似C#里面的泛型中的out参数（协变）
    static int add(final Pair<? extends Number> p){
        final Number first = p.getFirst();
        final Number last = p.getLast();
        // p 是一个只读的，因为使用了通配符<? extends Number>
        //p.setFirst(123);
        return first.intValue()+last.intValue();
    }

    // 类似C#里面的泛型的in 参数（逆变）
    static void setSame(Pair<? super Integer> p, Integer n){
        p.setFirst(n);
        p.setLast(n);
    }
}

class Pair<T>{
    private T first;
    private T last;
    public Pair(T first,T last){
        this.first = first;
        this.last = last;
    }

    public T getFirst(){
        return this.first;
    }
    public void setFirst(T first){
        this.first = first;
    }
    public T getLast(){
        return this.last;
    }
    public void setLast(T last){
        this.last = last;
    }
}

class IntPair extends Pair<Integer>{
    public IntPair(Integer first, Integer last){
        super(first, last);
    }
}