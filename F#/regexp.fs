let replace s1 s2 s3 = System.Text.RegularExpressions.Regex.Replace((s1:string), (s2:string), (s3:string), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
let input = replace "dfghISNULLfghjk" "isnull" "NVL"
printfn "%A" input