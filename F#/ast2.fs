[<Struct>]
type UsualOne<'T> =
    val mutable first : 'T
    val mutable other : 'T[]
    new (f,o) = {first = f; other = o}

/// Non-terminal expansion: production, family of children
/// All nodes are stored in array, so there is a correspondence between integer and node.
type Children =
    val mutable pos : int
    val mutable families : UsualOne<Family>
    new (f) = {pos = -1; families = f}

/// Family of children - For one nonTerminal there can be a lot of dirivation trees.
and AST =
    | NonTerm of Children
    /// If positive, then number of token
    /// Else -(num of nonTerm)-1
    | SingleNode of int

and Family =
    struct
        val prod : int
        val nodes : AST[]
        new (p,n) = {prod = p; nodes = n}
    end

let arr = Array.init (1 * 1000 * 1000) (fun _ -> SingleNode -1)
printfn "%f" <| double (System.GC.GetTotalMemory true) / (double (1 <<< 20))
