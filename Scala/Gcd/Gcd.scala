object Gcd {
  def gcd(a : Int, b : Int) : Int = {
    if (a == 0)
      return b;
    return gcd (b % a, a);
  }

  def main(args : Array[String]) : Unit = {
    println(gcd(args(0).toInt, args(1).toInt));
  }
}