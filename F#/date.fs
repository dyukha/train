open System
open System.Globalization

let dateString = "Sun 15 Jun 2008 8:30 AM -06:00"
let format = "ddd dd MMM yyyy h:mm tt zzz"
let result = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture)
let d2 = DateTime.ParseExact("01:02:03", "hh:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None)
let date1 = new DateTime(1550, 11, 7)
let correct, dateTime = DateTime.TryParseExact ("13.11.1991", "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)
printfn "%A" correct
printfn "%s" <| date1.ToString("ddd dd MM yyyy h:mm tt zzz")
printfn "%s" <| d2.ToString("ddd dd MM yyyy h:mm tt zzz")
printfn "%s" <| result.ToString("ddd dd MM yyyy h:mm tt zzz")
