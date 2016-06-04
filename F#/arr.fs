let a = [|1;2;3|]
for i in a do
    printf "%d " i
printfn ""
a |> Array.iter (printf "%d ")
printfn ""
a |> Array.iter (fun x -> printf "%d " x)
