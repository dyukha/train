module Mod = begin
    type T () =
        member this.X arg1 = 1
        member this.Y arg1 arg2 = 2
    let f x =
        let g y = y * 2
        g x, g
end

let s a = printf "%d" <| fst (Mod.f a)
s 3