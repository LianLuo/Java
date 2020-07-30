package Threading.Concurrents;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class NormalFor{
    static class Collector{
        private final int size = 10000000;
        public List<Object> getObjets(){
            List<Object> list = new ArrayList<>(size);
            for(int i=0;i<size;i++){
                list.add(new Object());
            }
            return list;
        }
    }
    private static Map<Object, Object> oMap = new HashMap<>();
    public static void put(Object obj){
        oMap.put(obj, obj);
    }
    public static void main(String[] args) {

        Collector collector = new Collector();
        var list = collector.getObjets();
        long start = System.currentTimeMillis();
        list.forEach(f->{
            put(f);
        });
        long end = System.currentTimeMillis();

        System.out.println(end-start);
        // 5778 ~ 6028
    }
}