class NotVolatile {
  static int a = 0;
  static int N = (int)1e5;
  static Object lock = new Object();

  static class Run implements Runnable {
    public void run() {
      for (int i = 0; i < N; i++) {
        synchronized (lock) {
          a++;
        }
      }
    }
  }

  public static void main(String[] args) {
    for (int i = 0; i < 20; i++) {
      new Thread(new Run()).start();
      new Thread(new Run()).start();
    }
    try {
      Thread.sleep(1000);
      System.out.println(a);
    } catch (Exception e) {
    }
  }
}