## Java 和 C# 反射
>`Java`中定义了一个`Class`类型，用来表示类的反射。  
`C#`中定义了一个`Type`类型，用来表示类的反射。

### Java获取反射信息
```java
    public class Person
    {
        private int age;

        public int getAge()
        {
            return age;
        }

        public void setAge(int age)
        {

        }

        public void sayHello()
        {
            System.out.print("Hello");
        }

        private void eatHand()
        {
            System.out.print("eating hand.");
        }

        public static void callStaticMethod()
        {
            System.out.print("invoke static method.");
        }

        public Person()
        {

        }

        public Person(int age)
        {
            this.age = age;
        }
    }

    class Program
    {
        public static void main(String[] args)
        {
            // 通过类名获取Class信息。
            Class cls = Perons.class;
            // 通过实例获取类信息。
            Person p = new Person();
            cls = p.getClass();

            // 通过类的全名获取类的信息。
            cls = Class.forName("package.Person");

            /*
            * 获取字段信息
            * getField(String fieldName);通过字段名 获取指定的 [公有] 字段信息，包含了父类的。
            * getFields() 获取所有的共有字段信息，包含父类。
            * getDeclaredField(String fieldName);通过字段名获取指定的字段信息，不包含父类的。
            * getDeclaredFields();获取指定类中的所有字段。不包含父类。
            */

            /*
            * 获取函数信息
            * getMethod(String methodName,Class ...); 通过函数名，获取指定的[公有]函数信息，包含父类。
            * getMethods() 获取所有公有函数信息。不包含父类。
            * getDeclaredMethod(String methodName,Class ...) 获取当前类中的所有函数信息，不包含父类。
            * getDeclaredMethods() 获取当前类中所有的函数信息。不包含父类。
            */

            /*
            * 初始化对象
            * getConstructor(Class ...):获取某个public的Constructor
            * getDeclaredConstructor(Class ..):获取某个Constructor
            * getConstructors():获取所有的public的constructor
            * getDeclaredConstructors():获取所有的constructor
            */
            p = new Person();
            p = Person.class.newInstance();// 调用无参构造函数。
            Constructor constructor1 = Person.class.getConstructor(int.class);
            p = (Person)constructor1.newInstance(13);
        }

        static void printClassInfo(Class cls)
        {
            System.out.println("Class name:" + cls.getName());// package+类名
            System.out.println("Simple name:" + cls.getSimpleName()); // 只有类名
            if (null != cls.getPackage()) {
                System.out.println("Package name:" + cls.getPackage().getName());
            }
            System.out.println("is interface:" + cls.isInterface());
            System.out.println("is enum:" + cls.isEnum());
            System.out.println("is array:" + cls.isArray());
            System.out.println("is primitive:" + cls.isPrimitive());
        }
    }

```

通过Method实例可以获方法的信息，`getName()`,`getReturnType()`,`getParameterType()`,`getModifiers()`  
通过Method实例可以调用某个对象的方法：Object invoke(Object instane, Object ... parameters);

### C#获取反射信息
```C#
    public class Person
    {
        public int Age
        {
            get;
            set;
        }
        
        private void SayHello()
        {
            Console.WriteLine("private method SayHello().");
        }
        
        public void Run()
        {
            Console.WriteLine("Person::Run.");
        }
        
        public static void StaticMethod()
        {
            Console.WriteLine("Person.StaticMethod().");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. 通过全名称获取Type对象。
            Type type = Type.GetType("namespace.className");//类的全名
            Person p = new Person();
            type = p.GetType();

            /*
            * 获取字段信息
            * GetField(fieldName,BindingFlags);
            * GetFields() 获取所有的字段信息，包含父类，包含公有和非公有
            * GetProperty(propertyName, BindingFlags);
            * GetProperties();获取所有属性信息，包含父类。
            * GetMethod(methodName, BindingFlags);
            * GetMethods();获取所有函数信息，包含父类。
            * method.Invoke(p,new object[]{}); 调用反射出来的函数。
            */
            FieldInfo fieldInfo = type.GetField("",BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase);// 这段意思是，获取忽略大小写的实例成员中共有或者非公有的字段。
            PropertyInfo propertyInfo = type.GetProperty("",BindingFlags.Instance | BindingFlags.Public);

            MethodInfo methodInfo = type.GetMethod("",BindingFlag.Instance | BindingFlag.Public);
            methodInfo.Invoke(p,new object[]{ });//非静态方法，
            methodInfo.Invoke(null,new object[]{});//静态方法。

            MethodInfo methodInfo = type.GetMethod("StaticMethod", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo.Invoke(p, new object[] {});
            // 如果不指定 BindingFlags.Instance会发生为将对象引用为实例的异常。
            methodInfo = type.GetMethod("Run",BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            // 如果不指定p这个实例对象,会报‘非静态方法需要一个目标。’
            methodInfo.Invoke(p, new object[] {});
            
            /*
            * 通过反射创建实例
            */
            Type type = p.GetType();
            // 无参构造函数
            p = (Person)Activator.CreateInstance(type);

            List<object> args = new List<object>();
            foreach(var item in type.GetConstructors()[0].getParameters())
            {
                // 处理基本类型。
                args.Add(GetInstanceByType(item.ParameterType));
            }
            p = (Person)Activator.CreateInstance(type, args);
        }

        private object GetInstanceByType(Type type)
        {
            switch (type.ToString())
            {
                case "System.String":
                    return string.Empty;
                case "System.Single":
                case "System.Int32":
                case "System.Double":
                case "System.Decimal":
                    return 0;
                case "System.Char":
                    return '\n';
                case "System.DateTime":
                    return DateTime.MinValue;
                case "System.Boolean":
                    return false;
                default:
                    return null;
            }
        }
    }
```

| 字段 | 值 | 描述 |
| - | - | - |
| Default | 0 | 指定未定义任何绑定标志
| IgnoreCase | 1 | 指定在绑定时不应考虑成员名称的大小写。
| DeclaredOnly | 2 | 指定只应考虑在所提供类型的层次结构级别上声明的成员。 不考虑继承的成员。
| Instance | 4 | 指定实例成员要包括在搜索中。
| Static | 8 | 指定静态成员要包括在搜索中。
| Public | 16 | 指定公共成员要包括在搜索中。
| NonPublic | 32 | 指定非公共成员要包括在搜索中。
| FlattenHierarchy | 64 | 指定应返回层次结构往上的公共成员和受保护静态成员。 不返回继承类中的私有静态成员。 静态成员包括字段、方法、事件和属性。 不支持嵌套类型。
| CreateInstance | 512 | 指定反射应创建指定类型的实例。 调用与给定参数匹配的构造函数。 忽略提供的成员名称。 如果未指定查找的类型，则应用“（实例 | 公共）”。 不能调用类型初始值设定项。此标志会传递给 InvokeMember 方法以调用构造函数。
| GetField | 1024 | 指定应返回指定字段的值。此标志会传递给 InvokeMember 方法以获取字段值。
| SetField | 2048 | 指定应设置指定字段的值。此标志会传递给 InvokeMember 方法以设置字段值。
| GetProperty | 4096 | 指定应返回指定属性的值。此标志会传递给 InvokeMember 方法以调用属性 getter。
| SetProperty | 8192 | 指定应设置指定属性的值。 对于 COM 属性，指定此绑定标志等效于指定 PutDispProperty 和 PutRefDispProperty。此标志会传递给 InvokeMember 方法以调用属性 setter。
| PutDispProperty | 16384 | 指定应调用 COM 对象上的 PROPPUT 成员。 PROPPUT 指定使用值的属性设置函数。 如果属性同时具有 PROPPUT 和 PROPPUTREF 并且你需要区分调用哪一个，请使用 PutDispProperty。
| PutRefDispProperty | 32768 | 指定应调用 COM 对象上的 PROPPUTREF 成员。 PROPPUTREF 指定使用引用而不是值的属性设置函数。 如果属性同时具有 PROPPUT 和 PROPPUTREF 并且你需要区分调用哪一个，请使用 PutRefDispProperty。
| ExactBinding | 65536 | 指定提供的参数的类型必须与对应形参的类型完全匹配。 如果调用方提供非 null Binder 对象，则反射会引发异常，因为这意味着调用方在提供将选取适当方法的 BindToXXX 实现。 当自定义绑定器可实现此标志的语义时，默认绑定器会忽略此标志。
| SuppressChangeType | 131072 | 未实现。
| OptionalParamBinding | 262144 | 返回其参数计数与提供的参数数量匹配的成员集。 此绑定标志用于参数具有默认值的方法和使用变量参数 (varargs) 的方法。 此标志只应与 InvokeMember(String, BindingFlags, Binder, Object, Object[], ParameterModifier[], CultureInfo, String[]) 结合使用。使用默认值的参数仅在省略了尾随参数的调用中使用。 它们必须是位于最后面的参数。
| IgnoreReturn | 16777216 | 在 COM 互操作中用于指定可以忽略成员的返回值。