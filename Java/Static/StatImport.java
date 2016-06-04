package stat;

import static stat.StatImport.Inner.*;

public class StatImport {
  public static class Inner {
    public static int A() { return 0; }
  }

  public static void main(String[] args) {
    System.out.println(A());
  }
}