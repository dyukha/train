public class Main{
  /*public static class B<T extends Integer> {
    int a() {
      T w = new T();
      return 2;
    }
  }*/

  public static class A {
    String print() {
      return "a";
    }
  }

  public static class C extends A {
    String print() {
      return "c";
    }
  }

  static String print(C c) {
    return "c";
  }

  static String print(A a) {
    return "a";
  }

  public static void main(String args[]) {
    //A c = new C();
    //c.print();
    A[] arr = new A[2];
    arr[0] = new A();
    arr[1] = new C();
    for (int i = 0; i < 2; i++) {
      System.out.println(arr[i].print());
    }
  }
}