import java.util.Iterator;

class MyIter {
  static class InfIterator implements Iterator<Integer> {
    int cur = 0;
    public Integer next() {
      return cur++;
    }
    public boolean hasNext() {
      return true;
    }
  }

  public static void main(String[] args) {
    InfIterator it = new InfIterator();
    while (it.hasNext()) {
      System.out.print(it.next() + " ");
    }
  }
}