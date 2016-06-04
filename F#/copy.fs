let c = [|1;2;3|]

let r (c : array<_>) x = 
  c.[1] <- x
  c

let a = r c 4
let b = r c 5
printfn "%A" a
printfn "%A" b
