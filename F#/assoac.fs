let (^<|) f x = f x
printfn "%d" <| ((*) 2) ^<| ((*) 2) ^<| 2