[<AllowNullLiteral>]
type MyList<'a> (_head : 'a, _tail : MyList<'a>) =
    member this.head = _head
    member this.tail = _tail

printfn "%A" System.DateTime.Now

let b = ref null
for i = 0 to 1000*1000*50 do
    b := new MyList<_>(i, !b)

printfn "%A" System.DateTime.Now

let a = ref []
for i = 0 to 1000*1000*50 do
    a := i::!a

printfn "%A" System.DateTime.Now
