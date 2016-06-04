let mutable res = 0.0

let mutable cur = 1.0

for i = 1 to 1000 do
  cur <- cur * 2.0
  res <- res + (double i) / cur

printf "%f" res