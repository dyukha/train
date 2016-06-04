let maxE (a : _[]) =
  let mutable res = a.[0]
  for i = 0 to a.Length - 1 do
    if a.[i] > res then
      res <- a.[i]
  res