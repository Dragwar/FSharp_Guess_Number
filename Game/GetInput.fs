module Game.GetInput

open System

let TryGetInt() = Console.ReadLine() |> Int32.TryParse

let rec GetInt msg =
    printfn "%s" msg
    Console.ResetColor()

    let isNumber, number = TryGetInt()

    if isNumber then
        number
    else
        Console.ForegroundColor <- ConsoleColor.Red
        GetInt msg


let rec GetIntWhere msg predicate =
    let num = GetInt msg
    if predicate num then
        num
    else
        Console.ForegroundColor <- ConsoleColor.Red
        GetIntWhere msg predicate

    
let rec YesOrNo msg =
    printf "%s" msg
    match Console.ReadLine() with
    | str when str.ToUpper() = "Y" || str.ToUpper() = "YES"-> true
    | str when str.ToUpper() = "N" || str.ToUpper() = "NO" -> false
    | str when String.IsNullOrWhiteSpace str -> YesOrNo msg
    | _ -> YesOrNo msg

    