let fact n = [1 .. n] |> List.map double |> List.fold (*) 1.0 //*)

let n = 100000

[n / 2 + 1 .. n]
|> List.map (fun len -> 1.0 / double len)
|> List.sum
|> fun x -> printf "%f" (1.0 - x)