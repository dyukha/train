class For {
  public static void main(String[] args) {
    final int n = 10;
    int[] a = new int[n];
    for (int i = 0; i < n; i++)
      a[i] = i;
    for (int i = 0, j = n-1; j >= i; i++, j--) {
      System.out.println(a[i] + a[j]);
    }
    /*for (int i = 0, double j = 1; i < n; i++, j *= 2;) {
      System.out.println(a[i] * j);
    }*/
    for (int x : a) {
      System.out.println(x);
      a[2] = 10;
    }
    final int m = 3;
    int[][] b = new int[m][];
    for (int i = 0; i < m; i++) {
      b[i] = new int[m];
      for (int j = 0; j < m; j++) {
        b[i][j] = i + j;
      }
    }
    int limit = 3;
    System.out.println();
megaOuter:
    {
outer:
      for (int[] inner : b) {
        for (int x : inner) {
          if (x >= limit) {
            System.out.println(x);
            break megaOuter;
          }
        }
      }
outer:
      for (int[] inner : b) {
        for (int x : inner) {
          if (x >= limit) {
            System.out.println(x);
            break outer;
          }
        }
      }
    }
  }
}