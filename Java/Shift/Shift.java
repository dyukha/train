import java.io.*;
import java.util.*;

class Shift {
  public static void main(String[] args) {
    {
      short a = -1;
      short b = (short)(a >> 1);
      System.out.println(b);
      short c = (short)(a >>> 1);
      System.out.println(c);
    }
    {
      int a = 0xffff_ffff;
      int b = (a >> 2);
      System.out.println(b);
      int c = (a >>> 2);
      System.out.println(c);
    }
    {
      byte a = -1;
      System.out.println(a & (~255));
      System.out.println((a & 255) >> 1);
      a = (byte)((a & 255) >> 1);
      System.out.println(a);
    }
  }
}