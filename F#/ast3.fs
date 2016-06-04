/// Non-terminal expansion: production, family of children
/// All nodes are stored in array, so there is a correspondence between integer and node.
[<Struct>]
type UsualOne<'T> =
    val mutable first : 'T
    val mutable other : 'T[]
    new (f,o) = {first = f; other = o}

/// Non-terminal expansion: production, family of children
/// All nodes are stored in array, so there is a correspondence between integer and node.
type AST =
    val mutable pos : int
    val mutable families : UsualOne<Family>
    new (p, f) = {pos = p; families = f}

and Family =
    struct
        val prod : int
        val nodes : obj[]
        new (p,n) = {prod = p; nodes = n}
    end

let arr = Array.init (1 * 1000 * 1000) (fun _ -> new AST(-1, new UsualOne<_>(new Family(0,[||]), null)))
//let arr = Array.init (1 * 1000 * 1000) (fun _ -> new AST(false, -1, Unchecked.defaultof<_>))
//let arr = Array.init (1 * 1000 * 1000) (fun _ -> box 22)
//let arr = Array.init (1 * 1000 * 1000) (fun _ -> NonTerm <| new Children(new UsualOne<_>(new Family(0,[||]), null)))
printfn "%f" <| double (System.GC.GetTotalMemory true) / (double (1 <<< 20))
