open System.Collections.Generic
let start = System.DateTime.Now
[<Struct>]
type SortArrayCell<'value> = 
   val key:int64
   val value:'value
   new (k, v) = { key = k; value = v }

let stableSortInPlaceBy (arr : 'a[]) getKey =
    if arr <> null && arr.Length > 1 then
        let tmp = Array.zeroCreate arr.Length
        let buf = Array.zeroCreate arr.Length
        let inline merge left mid right tmp buf =
            Collections.Array.blit (tmp : SortArrayCell<_>[]) left (buf : SortArrayCell<_>[]) left (right - left)                    
            let mutable j, k = mid, left
            for i = left to mid - 1 do                        
                while j < right && buf.[j].key < buf.[i].key do
                    tmp.[k] <- buf.[j]
                    k <- k + 1
                    j <- j + 1
                tmp.[k] <- buf.[i]
                k <- k + 1
        let make l r init = 
            let tmp : array<SortArrayCell<_>> = Array.zeroCreate (r - l)
            for i = 0 to r-l-1 do
                tmp.[i] <- new SortArrayCell<_>(getKey arr.[i+l], arr.[i+l])
            let buf = Array.zeroCreate (r - l)
            let inline swap i =
                let k = tmp.[i]
                tmp.[i] <- tmp.[i+1]
                tmp.[i+1] <- k
            let rec sort left right = 
                if right > left + 3 then 
                    let mid = (left + right) >>> 1
                    sort left mid
                    sort mid right
                    merge left mid right tmp buf
                elif right > left + 1 then
                    if tmp.[left].key > tmp.[left+1].key then
                        swap left
                    if right = left + 3 then
                        if tmp.[left+1].key > tmp.[left+2].key then
                            swap (left + 1)
                            if tmp.[left].key > tmp.[left+1].key then
                                swap left
            sort 0 (r-l)
            Array.blit tmp 0 init l (r - l)                    
        let procs = min (System.Environment.ProcessorCount - 1) (arr.Length >>> 12)
        if procs < 2 then
            make 0 arr.Length tmp
        else
            let h = (arr.Length + procs - 1) / procs
            let pieces =
                [|for i in 0..h..arr.Length-1 do
                    yield (i, min (i+h) arr.Length)|]
            pieces
            |> Array.map(fun (l,r) -> async{make l r tmp})
            |> Async.Parallel
            |> Async.RunSynchronously
            |> ignore
            let mutable count = 2
            while count < (pieces.Length <<< 1) do
                let step = count
                let rem = pieces.Length &&& (step - 1)
                let limit = pieces.Length - rem
                [for i in 0 .. step .. (limit - 1) do
                    yield (fst pieces.[i], fst pieces.[i + (step >>> 1)], snd pieces.[i + step - 1])
                 if rem > 1 then
                    yield (fst pieces.[limit], fst pieces.[limit + (step >>> 1)], snd pieces.[pieces.Length - 1])
                 ]
                |> Seq.map(fun (l,m,r) -> async{merge l m r tmp buf})
                |> Async.Parallel
                |> Async.RunSynchronously
                |> ignore
                count <- count <<< 1

        for i = 0 to arr.Length-1 do
            arr.[i] <- tmp.[i].value

let r = new System.Random(System.DateTime.Now.Millisecond)
let inline gen() = r.Next() |> int64
//let count = Int32.Parse(System.Environment.GetCommandLineArgs().[1])
let arr = Array.init 10000000 (fun i -> (gen() <<< 32) ||| gen())

stableSortInPlaceBy arr id

for i = 0 to arr.Length - 2 do
    if arr.[i] > arr.[i+1] then
        failwithf "Not sorted: %d" i

printfn "%A" (System.DateTime.Now - start)