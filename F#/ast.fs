
/// Non-terminal expansion: production, family of children
/// All nodes are stored in array, so there is a correspondence between integer and node.
type AST =
    val mutable first : Family
    val mutable other : Family[]
    val mutable pos : int
    new (p, f, o) = {pos = p; first = f; other = o}

and Family =
    //obj[]
    struct
        val nodes : int[]
        val prod : int
        new (p,n) = {prod = p; nodes = n}
    end

[<Struct>]
type intStr = 
    val a : int
    new (_a) = {a = _a}

let v = box <| new intStr(1)
let n = new AST(-1, new Family(1,[||]), null)
let arr = Array.init (1 <<< 20) (fun _ -> new AST(-1, new Family(0,null), null))
//let arr = Array.init (1 <<< 20) (fun _ -> box <| new AST(-1, [|v|], null))
//let arr = Array.init (1 * 1000 * 1000) (fun _ -> new AST(false, -1, Unchecked.defaultof<_>))
//let arr = Array.init (1 * 1000 * 1000) (fun _ -> box 22)
//let arr = Array.init (1 * 1000 * 1000) (fun _ -> NonTerm <| new Children(new UsualOne<_>(new Family(0,[||]), null)))
printfn "%f" <| double (System.GC.GetTotalMemory true) / (double (1 <<< 20))
