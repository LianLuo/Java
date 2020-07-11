package Threading;

public class SyncThreading {
    public static void main(String[] args) throws InterruptedException{
        test2();
    }

    static void test1() throws InterruptedException{
        System.out.println("Synchronize Threading");
        var add = new Thread(new AddThreading());
        var dec = new DecThreading();
        add.start();
        dec.start();
        add.join();
        dec.join();
        System.out.println("Counter without lock:"+Counter.count);
        System.out.println("CounterWithLock:"+CounterWithLock.count);
        System.out.println("completed.");
    }

    static void test2() throws InterruptedException{
        var p = new CounterLock();
        var t1 = new Thread(()->{
            for(int i=0;i<1000;i++){
                p.add();
            }
        });

        var t2 = new Thread(()->{
            for(int i=0;i<1000;i++){
                p.dec();
            }
        });
        t1.start();
        t2.start();
        t1.join();
        t2.join();

        System.out.println("CounterLock.length:"+p.getLength());
    }
}

class Counter{
    public static int count = 0;
}

class CounterWithLock{
    public static int count = 0;
    public static final Object lock = new Object();
}

class AddThreading implements Runnable{

    @Override
    public void run() {
        // NOLOCK
        for(int i=0;i<1000;i++){
            Counter.count += 1;
        }

        // LOCK
        for(int i=0;i<1000;i++){
            synchronized(CounterWithLock.lock){
                CounterWithLock.count += 1;
            }
        }
    }
}

class DecThreading extends Thread {
    @Override
    public void run(){
        // NOLOCK
        for(int i=0;i<1000;i++){
            Counter.count -= 1;
        }

        // LOCK
        for(int i=0;i<1000;i++){
            synchronized(CounterWithLock.lock){
                CounterWithLock.count -= 1;
            }
        }
    }
}


class CounterLock{
    private int length = 0;

    public synchronized void add(){
        this.length += 1;
    }

    public synchronized void dec(){
        this.length -= 1;
    }

    public int getLength(){
        return this.length;
    }
}