class If {
  public static void main(String[] args) {
    int b = 5;
    int a = 10;
    if (a == (b = 10))
      System.out.println(1);
    System.out.println(2);
    System.out.println((b = 20) + b);
  }
}