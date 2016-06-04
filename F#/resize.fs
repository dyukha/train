open Microsoft.FSharp.Collections
let a = new ResizeArray<_>()
a.Add 1
a.Add 2
printfn "%A" <| ResizeArray.fold (fun x y -> y) 0 a