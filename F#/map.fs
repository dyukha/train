open Microsoft.FSharp.Collections
let s = seq {for i in 1..2000 -> printf "%d " i; i}
s |> PSeq.map id
|> Seq.head