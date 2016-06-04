public class Outer {
  static interface Inner {
    void display();
  }
  public static void main(String[] args) {
    int n = 20;
    for (int i = 0; i < n; i++) {
      int i1 = i;
      new Inner() {
        public void display() {
          System.out.println(i1);
        }
      }.display();
      Inner inner = () -> System.out.println(i1);
      inner.display();
    }
  }
}