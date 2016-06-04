type A = B of int | ``L,;1`` of string

let f = function
    | B x -> string x
    | ``L,;1`` x -> x

printfn "%s" <| f (B 1)
printfn "%s" <| f (``L,;1`` "asdasd")