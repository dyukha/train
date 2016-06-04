type A = B of string | C of int

let getCtor arg = fst <| Microsoft.FSharp.Reflection.FSharpValue.GetUnionFields(arg, typeof<A>)

let a = getCtor (C 1)
let b = getCtor (B "")
printfn "%A" <| (a = b)