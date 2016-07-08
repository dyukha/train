using System.Collections.Generic;
using System;

class Gen2 {
  public static void Main(String[] args) {
    List<String>[] list = new List<String>[1];
    Object[] ol = (Object[]) list;
    ol[0] = new List<Object>();
    ol[0].ToString();
  }
}