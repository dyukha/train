public class Main{

  static interface A {
    static int a = 1;
  }

  static interface B {
    static int a = 2;
    static int b = 2;
  }

  static class C implements A, B {
    static int a = 3;
  }

  public static void main(String args[]) {
    C c = new C();
    System.out.println(A.a);
    System.out.println(B.a);
    System.out.println(c.a);
    System.out.println(C.b);
  }
}