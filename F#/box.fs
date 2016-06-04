let b = 2.0

printfn "%A" <| b * b

let rec t = 2.0 : 'tta
and a = box (t: 'tta)
and s = unbox a : 'tta

printfn "%A" <| s * s
