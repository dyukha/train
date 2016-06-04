open System.Collections.Generic
let start = System.DateTime.Now
[<Struct>]
type SortArrayCell<'value> = 
   val key:int64
   val value:'value
   new (k, v) = { key = k; value = v }

let stableSortInPlaceBy (arr : 'a[]) getKey =
    if arr <> null && arr.Length > 1 then
        let buf = Array.zeroCreate arr.Length
        let tmp = arr |> Array.map (fun x -> new SortArrayCell<_>(getKey x, x))
        let inline swap i =
            let k = tmp.[i]
            tmp.[i] <- tmp.[i+1]
            tmp.[i+1] <- k
        let inline merge left mid right =
            Collections.Array.blit tmp left buf left (right - left)                    
            let mutable j, k = mid, left
            for i = left to mid - 1 do                        
                while j < right && buf.[j].key < buf.[i].key do
                    tmp.[k] <- buf.[j]
                    k <- k + 1
                    j <- j + 1
                tmp.[k] <- buf.[i]
                k <- k + 1
        let rec sort left right =
            if right > left + 3 then 
                let mid = (left + right) >>> 1
                sort left mid
                sort mid right
                merge left mid right
            elif right > left + 1 then
                if tmp.[left].key > tmp.[left+1].key then
                    swap left
                if right = left + 3 then
                    if tmp.[left+1].key > tmp.[left+2].key then
                        swap (left + 1)
                        if tmp.[left].key > tmp.[left+1].key then
                            swap left
        let procs = min (System.Environment.ProcessorCount) (arr.Length >>> 12)
        if procs < 2 then
            sort 0 arr.Length
        else
            let h = (arr.Length + procs - 1) / procs
            let pieces =
                [|for i in 0..h..arr.Length-1 do
                    yield (i, min (i+h) arr.Length)|]
            pieces
            |> Array.map(fun (l,r) -> async{sort l r})
            |> Async.Parallel
            |> Async.RunSynchronously
            |> ignore
            let mutable count = 2
            printfn "%A" (System.DateTime.Now - start)
            while count < (pieces.Length <<< 1) do
                let step = count
                let rem = pieces.Length &&& (step - 1)
                let limit = pieces.Length - rem
                [for i in 0 .. step .. (limit - 1) do
                    yield (fst pieces.[i], fst pieces.[i + (step >>> 1)], snd pieces.[i + step - 1])
                 if rem > (step >>> 1) then
                    yield (fst pieces.[limit], fst pieces.[limit + (step >>> 1)], snd pieces.[pieces.Length - 1])
                 ]
                |> Seq.map(fun (l,m,r) -> async{merge l m r})
                |> Async.Parallel
                |> Async.RunSynchronously
                |> ignore
                count <- count <<< 1

        for i = 0 to arr.Length-1 do
            arr.[i] <- tmp.[i].value

let r = new System.Random(System.DateTime.Now.Millisecond)
let inline gen() = r.Next() |> int64
//let count = Int32.Parse(System.Environment.GetCommandLineArgs().[1])
let arr = Array.init 30000000 (fun i -> (gen() <<< 32) ||| gen())

stableSortInPlaceBy arr id

for i = 0 to arr.Length - 2 do
    if arr.[i] > arr.[i+1] then
        failwithf "Not sorted: %d" i

printfn "%A" (System.DateTime.Now - start)