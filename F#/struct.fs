type SampleClass = struct
    [<DefaultValue>] val mutable i : int
    new (aaa : int) = { }
end

type SampleClass2 = class
    let mutable i = 0
    new () = {}

end