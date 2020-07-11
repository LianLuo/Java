package Threading;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

import javax.management.Query;

public class WaitNotifyDemo {
    public static void main(String[] args) throws InterruptedException{
        System.out.println("Wait Notify Demo.");
        test1();
    }

    static void test1() throws InterruptedException{
        var q = new TaskQueue();
        var ts = new ArrayList<Thread>();
        for(int i=0;i<5;i++){
            var t = new Thread(()->{
                while(true){
                    try{
                        String s = q.getTask();
                        System.out.println("execute task:"+s+"\t Thread ID"+Thread.currentThread().getId());
                    }catch(InterruptedException e){
                        return;
                    }
                }
            });
            t.start();
            ts.add(t);
        }

        var add = new Thread(()->{
            for(int i=0;i<10;i++){
                String s = "t-"+Math.random();
                System.out.println("add task:"+s);
                q.addTask(s);
                try{
                    Thread.sleep(100);
                }catch(InterruptedException e){

                }
            }
        });

        add.start();
        add.join();
        Thread.sleep(100);
        for(var t: ts){
            t.interrupt();
        }
    }
}

class TaskQueue{
    Queue<String> queue = new LinkedList<>();

    public synchronized void addTask(String s){
        this.queue.add(s);
        this.notifyAll();
    }

    public synchronized String getTask() throws InterruptedException{
        while(this.queue.isEmpty()){
            this.wait();
        }
        return queue.remove();
    }
}

class CounterWithCounter{
    private final Lock lock = new ReentrantLock();
    private int count;

    /**
     * use lock.lock() replace synchronized.
     * @param n
     * @throws InterruptedException
     */
    public void add(int n) throws InterruptedException{
        //lock.lock();
        if(lock.tryLock(1, TimeUnit.SECONDS)){
            try{
                count += n;
            }finally{
                lock.unlock();
            }
        }
        
    }

    public int getCount(){
        return this.count;
    }
}

class TaskQueue_2{
    private final Lock lock = new ReentrantLock();
    private final Condition condition = lock.newCondition();
    private Queue<String> queue = new LinkedList<>();

    public void addTask(String s){
        lock.lock();
        try{
            queue.add(s);
            condition.signalAll();
        }finally{
            lock.unlock();
        }
    }

    public String getTask() throws InterruptedException {
        lock.lock();
        try{
            while(queue.isEmpty()){
                condition.await();
            }
            return queue.remove();
        }finally{
            lock.unlock();
        }
    }
}