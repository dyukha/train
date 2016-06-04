let a = "aaaa"
printfn "%A" <| a.Replace("aa", "a")
printfn "%A" <| a . Length
printfn "%A" (not true || true)

let dd = new System.Collections.Generic.Dictionary<_,_>()
dd.[2] <- 3
printfn "%A" dd.[2]
printfn "%A" dd.[1]
