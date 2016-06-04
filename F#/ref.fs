let a = ref 0
while !a < 100 do
    incr a
    a := !a + 1

let mutable b = 0
while b < 100 do
    b <- b + 1