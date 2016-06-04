let _a = seq {yield 1}
_a |> Seq.iter (fun x -> printfn "%d" x)

let s = seq{for i = 0 to 5 do printf "%d " i; yield i}
let enum = s.GetEnumerator()
enum.MoveNext()
printfn "%A" enum.Current
printfn "%A" <| Seq.pairwise s
printfn "%A" s
printfn "%A" s
