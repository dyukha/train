open System.IO

let src = File.ReadAllText ("in.txt", System.Text.Encoding.UTF8)
let a = Array.create 100000 (0,' ')

//printfn "%s" src

src |> String.iter (fun c ->
    a.[int c] <- (fst a.[int c] + 1, c)
)

let out = System.IO.File.CreateText("out.txt")

a
|> Array.sort
|> Array.rev
|> (fun a -> a.[0..40])
|> Array.iter (fun (cnt, ch) -> fprintfn out "%c: %d" ch cnt)

out.Close()