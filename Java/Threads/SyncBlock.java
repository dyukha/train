public class SyncBlock {
  static void run(int num) {
    System.out.println(num + " in");
    for (int i = 0; i < 10; i++) {
      try { Thread.sleep(100); } catch (Exception e) {}
      System.out.println(num);
    }
    System.out.println(num + " out");
  }

  static class Printer {
    synchronized void print1()  {
      run(1);
    }
    synchronized void print2()  {
      run(2);
    }

    Object lock = new Object();
    void print3()  {
      synchronized(lock) {
        run(3);
      }
    }
    void print4() {
      synchronized(lock) {
        run(4);
      }
    }
  }

  static void sync(Object object) {
    synchronized(object) {
      System.out.println("lock in");
      try { Thread.sleep(3000); } catch (Exception e) {}
      System.out.println("lock out");
    }
  }

  public static void main(String[] args)  throws InterruptedException {
    Printer printer = new Printer();
    new Thread(() -> sync(printer)).start();
    new Thread(() -> printer.print1()).start();
    new Thread(() -> printer.print2()).start();
    new Thread(() -> printer.print3()).start();
    new Thread(() -> printer.print4()).start();
  }
}