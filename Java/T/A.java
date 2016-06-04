import java.io.*;
import java.util.*;

public class A {
  StringTokenizer st;
  BufferedReader reader;
  final PrintStream out = System.out;

  void run() {
    st = new StringTokenizer("");
    try (BufferedReader br = new BufferedReader(new InputStreamReader(System.in))) {
      reader = br;
    } catch (IOException e) {
    }
  }

  String next() {
    try {
      while (!st.hasMoreTokens())
        st = new StringTokenizer(reader.readLine());
    } catch (IOException e) {
    }
    return st.nextToken();
  }

  int nextInt() {
    return Integer.parseInt(next());
  }

  public static void main(String[] args) {
    new A().run();

  }
}