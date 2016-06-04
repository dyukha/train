let a1 = [|2|]
let b1 = [|2|]
printfn "%A" (a1 = b1)

[<Struct>]
type OneOrMore<'V> =
    val mutable first : 'V
    val mutable other: 'V[]
    new (f,o) = {first = f; other = o}

(*[<Struct>]
type OneOrMore2 = {
    first : int
    other : int[]
}*)

let printMem () =
    printfn "%d" <| (System.GC.GetTotalMemory(true) >>> 20)
printMem ()
//let init _ = new ResizeArray<int64>(1)
//let init _ : int[] = Array.zeroCreate 1 
let init _ : int[] = null
//let init _ = new OneOrMore<_>(next(),null)
//let init _ = 1
//let init _ = {first = next(); other = null}

let a = Array.init (1 <<< 20) init
printMem ()
