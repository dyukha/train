import java.util.*;

class Gen2 {
  public static void main(String[] args) {
    List<String>[] list = new ArrayList[1];
    Object[] ol = (Object[]) list;
    ol[0] = new ArrayList<Object>();//new List<Object>();
    ((List<Object>)(Object)list[0]).add(new Object());
    list[0].get(0).toString();
  }
}