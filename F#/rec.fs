type A = B of int | C of string
let inline eee x = match x with | B x -> string x | C d -> d
eee (B 5) |> printfn "%s"

let a = Array.zeroCreate 2
a.[0] <-
    (fun x ->
        if x = 1 then 1
        else a.[1] (x-1) * x)
a.[1] <-
    (fun x ->
        if x = 1 then 1
        else a.[0] (x-1) * x)

printfn "%A" <| a.[0] 5

let b = None
printfn "%A" (b = None)