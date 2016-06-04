type a = 
    member this.fst () = box (2 : 'a)
    member this.snd x = unbox x : 'a