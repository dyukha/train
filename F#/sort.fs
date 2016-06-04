open System.Collections.Generic
let start = System.DateTime.Now
[<Struct>]
type SortArrayCell<'value> = 
   val key:int64
   val value:'value
   new (k, v) = { key = k; value = v }

let stableSortInPlaceBy (arr : 'a[]) getKey =
    if arr <> null && arr.Length > 1 then
        let make l r = 
            let tmp : array<SortArrayCell<_>> = Array.zeroCreate (r - l)
            for i = 0 to r-l-1 do
                tmp.[i] <- new SortArrayCell<_>(getKey arr.[i+l], arr.[i+l])
            let buf = Array.zeroCreate (r - l)
            let inline merge left mid right =
                Collections.Array.blit (tmp : SortArrayCell<_>[]) left (buf : SortArrayCell<_>[]) left (right - left)                    
                let mutable j, k = mid, left
                for i = left to mid - 1 do                        
                    while j < right && buf.[j].key < buf.[i].key do
                        tmp.[k] <- buf.[j]
                        k <- k + 1
                        j <- j + 1
                    tmp.[k] <- buf.[i]
                    k <- k + 1
            let inline swap i =
                let k = tmp.[i]
                tmp.[i] <- tmp.[i+1]
                tmp.[i+1] <- k
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
            sort 0 (r-l)
            tmp
        let procs = min (System.Environment.ProcessorCount) (arr.Length >>> 12)
        if procs < 2 then
            let res = make 0 arr.Length
            for i = 0 to arr.Length-1 do
                arr.[i] <- res.[i].value
        else
            let h = (arr.Length + procs - 1) / procs
            let result = Array.zeroCreate procs
            [|for i in 0..h..arr.Length-1 do
                yield (i, min (i+h) arr.Length)|]
            |> Array.mapi(fun i (l,r) -> async{result.[i] <- make l r})
            |> Async.Parallel
            |> Async.RunSynchronously
            |> ignore
            let index = Array.create procs 0
            let mutable minv = Unchecked.defaultof<SortArrayCell<_>>
            let mutable mini = -1
            printfn "%A" (System.DateTime.Now - start)
            for k = 0 to arr.Length-1 do
                mini <- -1
                for i = 0 to result.Length-1 do
                    if index.[i] < result.[i].Length && (mini = -1 || result.[i].[index.[i]].key < minv.key) then
                        mini <- i
                        minv <- result.[i].[index.[i]]
                arr.[k] <- minv.value
                index.[mini] <- index.[mini] + 1


let r = new System.Random(System.DateTime.Now.Millisecond)
let inline gen() = r.Next() |> int64
//let count = Int32.Parse(System.Environment.GetCommandLineArgs().[1])
let arr = Array.init 30000000 (fun i -> (gen() <<< 32) ||| gen())

stableSortInPlaceBy arr id

for i = 0 to arr.Length - 2 do
    if arr.[i] > arr.[i+1] then
        failwithf "Not sorted: %d" i

printfn "%A" (System.DateTime.Now - start)