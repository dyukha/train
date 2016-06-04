let a<'a> = Array.zeroCreate 1
let rec fact = 
    (fun x ->
        if x = 1 then 1
        elif x > 4 then a.[0] (x-1) * x
        else fact (x-1) * x)
a.[0] <-
    (fun x ->
        if x = 1 then 1
        else fact (x-1) * x)

printfn "%A" <| fact 6
printfn "%A" <| a.[0].GetType()