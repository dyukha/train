public class Interrupt {
  public static class Printer implements Runnable {
    @Override public void run() {
      try {
        for (int i = 0; i < 10; i++) {
          Thread.sleep(1000);
          System.out.println(i);
        }
      } catch (InterruptedException e) {
          System.out.println("Interrupted");
      }
      try {
        for (int i = 0; i < 10; i++) {
          Thread.sleep(100);
          System.out.println(i);
        }
      } catch (InterruptedException e) {
          System.out.println("Interrupted");
      }
    }
  }

  public static void main(String[] args) throws InterruptedException {
    Thread thread = new Thread(new Printer());
    thread.start();

    Thread.sleep(3000);
    thread.interrupt();
    thread.join();
    System.out.println("Joined");
  }
}