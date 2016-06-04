public class Private {
  static class Base {
    private int a() {
      return 1;
    }
    public int print() {
      return a();
    }
  }

  static class Child extends Base {
    private int a() {
      return 2;
    }
  }

  public static void main(String[] args) {
    Base child = new Child();
    System.out.println(child.print());
  }
}
