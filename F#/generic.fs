type A (value : int) =
    member this.Val = value
    member this.Gen (x : 'a) = x

let a = new A(2)
printfn "%d" a.Val
printfn "%f" <| a.Gen 2.0
printfn "%d" <| a.Gen 2
