package Threading.Concurrents;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ParalleFor {
    static class Collector{
        private final int size = 10000000;
        public List<Object> getObjets(){
            final List<Object> list = new ArrayList<>(size);
            for (int i = 0; i < size; i++) {
                list.add(new Object());
            }
            return list;
        }
    }

    private static Map<Object, Object> oMap = new HashMap<>();

    public synchronized static void put(final Object obj){
        oMap.put(obj, obj);
    }

    public static void main(final String[] args) {

        final Collector collector = new Collector();
        final var list = collector.getObjets();
        final long start = System.currentTimeMillis();
        list.parallelStream().forEach(f -> {
            put(f);
        });
        final long end = System.currentTimeMillis();

        System.out.println(end-start);
        // 15463 ~ 16810
    }
}