open System.IO

let s =
    File.ReadAllText("input.txt").Replace(" ", "")
File.WriteAllText("output.txt", s)

