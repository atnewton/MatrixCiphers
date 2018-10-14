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

//open System
 
//let private cipher n s =
//    let shift c =
//        if Char.IsLetter c then
//            let a = (if Char.IsLower c then 'a' else 'A') |> int
//            (int c - a + n) % 26 + a |> char
//        else c
//    String.map shift s
 
//let encrypt n = cipher n
//let decrypt n = cipher (26 - n)

//> caesar.encrypt 2 "HI";;
//val it : string = "JK"
//> caesar.encrypt 20 "HI";;
//val it : string = "BC"
//> let c = caesar.encrypt 13 "The quick brown fox jumps over the lazy dog.";;
//val c : string = "Gur dhvpx oebja sbk whzcf bire gur ynml qbt."
//> caesar.decrypt 13 c;;
//val it : string = "The quick brown fox jumps over the lazy dog."