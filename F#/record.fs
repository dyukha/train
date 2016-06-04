type R = {f1 : int; f2: string}

let f {f1 = v1; f2 = v2} = printfn "%A %A" v1 v2

f {f1 = 2; f2 = "3"}