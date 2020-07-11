package Threading;

public class ThreadingDemo {
    public static void main(String[] args) {
        System.out.println("Threading Demo");
        Thread t = new Thread(()->{
            System.out.println("ABC");
        });
        t.start();
        System.out.println("OK");
        t = new CustomerThread();
        t.start();

        t = new Thread(new Threading());
        t.start();
    }
}

class CustomerThread extends Thread{

    @Override
    public void run(){
        System.out.println("AAAA");
    }
}

class Threading implements Runnable{

    @Override
    public void run() {
        System.out.println("Threading");
    }

}