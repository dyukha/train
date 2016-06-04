(*type Token =
    | A of int*int
    | B of int*int
    | ``L *`` of int 
    | ``L +`` of int *)

let ``L +`` = 2

type A =
    | B of int
    | ``L +`` of double
    | ``L -`` of double

(*
let f x : 'a -> A =
    match x with
    | "+" -> ``L +``
    | "-" -> ``L -``
    | _ -> failwith "Incorrect string"*)