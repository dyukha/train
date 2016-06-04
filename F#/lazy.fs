let state = ref 1
let s  =
    [|0..100|]
    |> Seq.map(fun x -> state := !state + 1; x + !state)
    
s
|> Seq.fold (fun b x -> b + x) 2
|> printfn "%A"

s
|> Seq.fold (fun b x -> b + x) 2
|> printfn "%A"

(*let a = Array.zeroCreate 10000000
a.[0] <- lazy 0
for i = 1 to 9999999 do
    a.[i] <- lazy(a.[i-1].Force() + 1)
printfn "%d" <| a.[9999999].Force()
printfn "========================"
let x = ref(lazy(0))
for i = 0 to 10000000 do
    x := lazy(x.Value.Force() + 1)
printfn "%d" <| x.Value.Force()
*)

