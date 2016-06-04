public class Enums {
  enum Num {
    ONE(1),
    TWO(2);

    int num;
    Num(int num) {
      this.num = num;
    }

    int getNum() {
      return num;
    }

    void setNum(int v) {
      num = v;
    }
  }
  public static void main(String[] args) {
    System.out.println(Num.ONE.getNum());
    System.out.println(Num.TWO.getNum());
    Num.ONE.setNum(3);
    Num.TWO.setNum(4);
    System.out.println(Num.ONE.getNum());
    System.out.println(Num.TWO.getNum());
  }
}