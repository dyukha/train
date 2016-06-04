let a = Array.zeroCreate 2
let b = Array.zeroCreate 2
let ra, rb = (
    (fun x ->
        if x = 1 then 1.0 : 'b
        else (double)((int)(unbox (b.[0] (x-1)): 'a) * x) : 'b
        |> box)
    ,(fun x ->
        if x = 1 then 1.0 : 'a
        else (unbox (a.[0] (x-1)): 'b) * (double)x : 'a
        |> box)
   )
    
a.[0] <- ra
b.[0] <- rb

printfn "%A" <| a.[0] 5

let bs = None
printfn "%A" (bs = None)