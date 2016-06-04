import java.util.*;
import java.io.*;
import java.text.*;

class MyDouble {
  public static void main(String[] args) {
    System.out.println(Double.parseDouble("0.8"));
    //System.out.println(Double.parseDouble("0,8"));
    NumberFormat format = NumberFormat.getInstance(Locale.FRANCE);
    try {
      Number number = format.parse("0,8");
      System.out.println(number);
    } catch (Exception e) {
      System.out.println("NaN!");
    }
    {
      double d = Double.NaN;
      System.out.println(Long.toBinaryString(Double.doubleToLongBits(d)));
      System.out.println(Long.toBinaryString(Double.doubleToRawLongBits(d)));
    }
  }
}