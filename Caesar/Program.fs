// Learn more about F# at http://fsharp.org

open System

let encrypted = "ocz hvomds dn v ntnozh izj ocvo ntnozh dn jzm zizht".ToUpper()

let shift(c, shiftAmount) = 
    if c = 32 then
        char(int(' '))
    else
        let num = int(c) - int('A')
        let offsetNum = (num+shiftAmount)%26
     
        if offsetNum < 0 then
            char(int('Z') + offsetNum + 1)
        else
            char(offsetNum + int('A'))

let shiftstring(str:string, shiftAmount) =
    str.ToCharArray() 
    |> Array.map (fun c -> shift(int(c), shiftAmount)) 
    |> String.Concat

[<EntryPoint>]
let main argv =
    Console.ForegroundColor <- ConsoleColor.Green
    Console.WriteLine(encrypted)
    let decrypted = shiftstring(encrypted, -21)
    Console.WriteLine(decrypted)
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
