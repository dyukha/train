printfn "%s" <| (new System.Diagnostics.StackTrace()).ToString()
printfn "%s" <| (new System.Diagnostics.StackTrace()).GetFrames().[0].ToString()
printfn "%s" <| (new System.Diagnostics.StackTrace()).GetFrames().[1].ToString()
printfn "%s" <| (new System.Diagnostics.StackTrace()).GetFrames().[2].ToString()
