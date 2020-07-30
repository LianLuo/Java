package Threading.Concurrents;

import jdk.internal.misc.Unsafe;

public class Lock {
    private static final Unsafe Unsafe;
    private static final long valueOffset;

    static{
        try{
            Class<Unsafe> unsafeclaz = Unsafe.class;
        }
    }
}