def fib(n):
    def inner(a, b):
        return b, a+b
    a, b = 1, 1
    res = []
    while a < n:
        res.append(a)
        a, b = inner(a, b)
    return res

print (fib(1000))
print (dir())