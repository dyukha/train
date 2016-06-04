let printMem () =
    printfn "%d" <| (System.GC.GetTotalMemory(true) >>> 20)
printMem ()
let x = 10
let s = string x
let init x = s//(s,10,11)

let a = Array.init (1 <<< 20) init
printMem ()
