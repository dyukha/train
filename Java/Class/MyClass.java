import java.lang.reflect.*;

public class MyClass {
  class NonStat{}
  static class Foo {}
  static class Foo1 {}
  public static void main(String[] args) throws InstantiationException, IllegalAccessException, InvocationTargetException {
    Class nonStatClass = NonStat.class;
    Constructor<?> con = nonStatClass.getDeclaredConstructors()[0];
    NonStat nonStat = (NonStat)con.newInstance((Object)new MyClass());
    

    Class<Foo> klass = Foo.class;
    Foo f0 = new Foo();
    Foo f1 = klass.newInstance();
    Foo f2 = klass.cast((Object)f1);
  }
}