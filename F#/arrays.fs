let start = System.DateTime.Now
printfn "%A" System.DateTime.Now
type AST<'TokenType> =
    /// Non-terminal expansion: production, family of children
    /// All nodes are stored in array, so there is a correspondence between integer and node.
    | NonTerm of int[][]//(ResizeArray<int []>)
    | Term of 'TokenType

let nodes = Array.zeroCreate (10 * 1000 * 1000 + 1)//new ResizeArray<_> ()
for i = 0 to nodes.Length-1 do
    nodes.[i] <- NonTerm (Array.create 20 null)//(new ResizeArray<_>(20))
//    nodes.Add <| new ResizeArray<int>(1) //NonTerm (new ResizeArray<_>(1))
//nodes.Add <| Term (0,((0,0),0),0,0)
nodes.[0] <- Term (0,((0,0),0),0,0)
printfn "%A" System.DateTime.Now
printfn "%A" (System.DateTime.Now - start)
