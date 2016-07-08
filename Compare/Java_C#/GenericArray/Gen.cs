using System.Collections.Generic;
using System;

class Gen {
  public static void Main(String[] args) {
    List<String>[] list = new List<String>[1];
    Object[] ol = (Object[]) list;
    ol[0] = new Object();
    ol[0].ToString();
  }
}