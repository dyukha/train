fun sum(a : Int, b : Int) = a + b
fun sumPrint(a : Int, b : Int) {
  val res = a + b
  println(res)
}

fun maxDbl(a : Int, b : Double) = if (a > b) a.toDouble() else b
fun sumDbl(a : Int, b : Double) = a + b
fun eqIntLong(a : Int, b : Long) = a.toLong() == b
fun eqIntLongRef(a : Int, b : Long) = a.toLong() === b
//fun eqIntLongOpt(a : Int?, b : Long?) = a == b

fun parseInt(str : String) : Int? {
   try {
      return Integer.parseInt(str);
   } catch (ex : NumberFormatException) {
      return null;
   }
}

fun main(args : Array<String>) {
  val a = args[0].toInt();
  val b = args[1].toInt();
  println(sum(a, b));
  sumPrint(a, b)
  println("sum is ${sum(a, b)}");
  println("sumDbl is ${sumDbl(a, b.toDouble())}");
  println("1 == 1 is ${eqIntLong(1, 1L)}");
  println("1 == 1 ref is ${eqIntLongRef(1, 1L)}");
  println("abacaba = " + parseInt("abacaba"));
  println("5 = " + parseInt("5"));
}