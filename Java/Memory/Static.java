public class Static {
  
  final static int N = (int)1e6;
  final static Runtime runtime = Runtime.getRuntime();
  static long curMem = 0;
  int y;

  static class A { int x, z; A() { x = 0;} }
  public class B { int x, z; B() {x = y;} public void print() {System.out.println(y);}}

  static void reset() {
    curMem = 0;
  }

  static A[] a;
  static B[] b;

  static long mem() {
    long notFree = runtime.totalMemory() - runtime.freeMemory();
    long res = notFree - curMem;
    curMem = notFree;
    return res;
  }

  static void printMem(String msg) {
    System.out.println(msg + ": " + (mem() / (double)N));
  }

  void TestA() {
    mem();
    a = new A[N];
    printMem("After A created");
    for (int i = 0; i < N; i++) {
      a[i] = new A();
    }
    printMem("After A filled ");
  }

  void TestB() {
    mem();
    b = new B[N];
    printMem("After B created");
    for (int i = 0; i < N; i++) {
      b[i] = new B();
    }
    printMem("After B filled ");
  }

  void run() {
    reset();
    mem();
    TestA();
    TestB();
  }

  public static void main(String[] args) {
    new Static().run();
  }
}