let a = 0 |> char  |> string
let s = ("aaa" + a + "aa a").Replace(a, "b")
printfn "%s" s