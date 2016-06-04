type A()=
    let a = 2

type B()=
    inherit A()

let (a : A) = new B() :> A