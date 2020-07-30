package DesignPattern;

public class SingletonPattern {
    public static void main(String[] args) {
        System.out.println(World.INSTANCE.getName());
        System.out.println(Singleton.getInstance().toString());
    }
}

// 推荐用枚举方式创建单例
enum World{
    // 唯一枚举
    INSTANCE;

    private String name = "world";
    public String getName(){
        return this.name;
    }

    public void setName(String name){
        this.name = name;
    }
}

class Singleton{
    private static final Singleton Instance  = new Singleton();
    public static Singleton getInstance(){
        return Instance;
    }
    private Singleton(){}

    @Override
    public String toString(){
        return "singleton.";
    }
}