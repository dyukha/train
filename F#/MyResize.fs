open System.Collections.Generic

type MyResize<'T> () =
    let initArraysCount = 1
    let mutable count = 0
    let shift = 15
    let smallPart = (1 <<< shift) - 1
    let mutable arrays = Array.zeroCreate initArraysCount
    let mutable cap = (1 <<< shift) * arrays.Length
    let _ =
        for i = 0 to initArraysCount-1 do
            arrays.[i] <- Array.zeroCreate (1 <<< shift)
    member this.Add (x : 'T) =
        if count = cap then
            let oldArrays = arrays
            arrays <- Array.zeroCreate (arrays.Length * 2)
            for i = 0 to oldArrays.Length-1 do
                arrays.[i] <- oldArrays.[i]
            for i = oldArrays.Length to arrays.Length-1 do
                arrays.[i] <- Array.zeroCreate (1 <<< shift)
            cap <- (1 <<< shift) * arrays.Length
            //printfn "%A %A" count cap
        arrays.[count >>> shift].[count &&& smallPart] <- x
        count <- count + 1
    member this.Item i =
        if i >= count then raise <| System.ArgumentOutOfRangeException()
        else arrays.[i >>> shift].[i &&& smallPart]

let makeUsual = false
let makeMy = true

let usual = new List<_>()
let my = new MyResize<_>()

let n = 1000*1000*250

let profile f =
    let start = System.DateTime.Now
    f ()
    printfn "%A" <| System.DateTime.Now - start

if makeUsual then
    fun () ->
        for i = 0 to n do
            usual.Add(i)
    |> profile

    fun () ->
        let mutable x = 0
        for j = 0 to 10 do
            for i = 0 to n do
                x <- usual.[i]
    |> profile

if makeMy then
    fun () ->
        for i = 0 to n do
            my.Add(i)
    |> profile

    fun () ->
        let mutable x = 0
        for j = 0 to 10 do
            for i = 0 to n do
                x <- my.[i]
    |> profile

