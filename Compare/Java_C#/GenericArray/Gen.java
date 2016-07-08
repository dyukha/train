import java.util.*;

class Gen {
  public static void main(String[] args) {
    List<String>[] list = new ArrayList[1];
    Object[] ol = (Object[]) list;
    ol[0] = new Object();//new List<Object>();
    ol[0].toString();
  }
}