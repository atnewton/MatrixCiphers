open System

let encrypted = "yzo cmg twzj htzh nj zoxwjimo htzhi htw imgox mv sowfshzaspshc".ToUpper()

let alphabetplusspace = List.append ['A'..'Z'] [' ']
//ooh, it's reversed but not quite. So sneaky.
let substitutionalphabetplusspace = ['B';'Z';'Y';'X';'W';'V';'U';'T';'S';'R';'Q';'P';'O';'M';'N';'L';'K';'J';'I';'H';'G';'F';'E';'D';'C';'A';' ']

let substitute = 
    List.zip alphabetplusspace (substitutionalphabetplusspace) |> Map.ofList

let substitutestring(str:string) =
    str.ToCharArray() 
    |> Array.map (fun c -> substitute.[c])
    |> String.Concat

[<EntryPoint>]
let main argv =
    Console.ForegroundColor <- ConsoleColor.Green
    Console.WriteLine(encrypted)
    let decrypted = substitutestring(encrypted)
    Console.WriteLine(decrypted)
    System.Console.ReadKey() |> ignore
    0
