let permutation N =
    let genList = ref [[]]
    let addInList list =
        genList := list @ !genList
        list
    let startList = [for i in [1 .. N] -> [i]]
    genList := startList
    let rec iter listList =
        if List.length listList <> 1 then
            listList |> List.collect
                (fun i -> [List.max i + 1 .. N] |> List.collect (fun j -> [ i @ [j] ]))
            |> addInList
            |> iter
    iter startList
    !genList
printfn "%A" <| permutation 4
