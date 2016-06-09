/*
  list<e><T> = {[return mutableListOf()]} | list=list<e><T> elem=e {[list.add(elem); return list]}
  calc =
      left=calc '+' left=calc {[return left + right]}
    | left=calc '*' left=calc {[return left * right]}
    | num=NUM {[return num.value]}
    | list=list<calc> {}

  calcList = {[return mutableListOf()]} | list=calcList elem=e {[list.add(elem); return list]}
*/

import java.util.*;

interface Node

class Token(val value : Int) : Node
class NonTerm(val prod : Int, val children : Array<Node>) : Node

fun<T> calcList(node : Node, calculator : (Node) -> T) : MutableList<T> {
  if (node is NonTerm) {
    if (node.prod == -3) {
      return mutableListOf()
    }
    if (node.prod == -2) {
      val list = calcList<T>(node.children[0], calculator)
      val elem = calculator(node.children[1])
      list.add(elem)
      return list
    }
  }
  assert (false);
  return mutableListOf()
}

fun calc(node : Node) : Int {
  if (node is Token)
    return node.value
  if (node is NonTerm) {
    if (node.prod == -1) {
      val list = calcList(node.children[0], ::calc)
      return list.sum()
    }
    val left = calc(node.children[0])
    val right = calc(node.children[1])
    if (node.prod == 0) {
      return left + right
    }
    if (node.prod == 1) {
      return left * right
    }
    assert(false);
  }
  assert(false);
  return -10000;
}

fun main(args : Array<String>) {
  println(
    calc(
      NonTerm(0, arrayOf(
        Token(2),
        NonTerm(1, arrayOf(
          Token(3),
          Token(5)
        ))
      ))
    )
  );

  println(
    calc(
      NonTerm(-1, arrayOf(
        NonTerm(-2, arrayOf(
          NonTerm(-2, arrayOf(
            NonTerm(-2, arrayOf(
              NonTerm(-2, arrayOf(
                NonTerm(-3, arrayOf()),
                Token(1)
              )),
              Token(2)
            )),
            Token(3)
          )),
          Token(4)
        ))
      ))
    )
  );
}