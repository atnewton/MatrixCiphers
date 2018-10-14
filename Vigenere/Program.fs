// Learn more about F# at http://fsharp.org

open System

let encrypted = "atacwfgiztwcpifzhovdtvwam".ToUpper()

let key = "IAMNDO"

let dec k c = ((c - k + 130) % 26) + 65
let crypt f key = Array.mapi (fun n c -> f (key n) c |> char)

let keyschedule (key:string) =
    let k = key.ToCharArray()
    let l = Array.length k
    (fun n -> int k.[n % l])

let decrypt (ciphertext:string) key =
    ciphertext.ToCharArray()
    |> Array.map int
    |> crypt dec (keyschedule key)
    |> String.Concat

[<EntryPoint>]
let main argv =
    Console.ForegroundColor <- ConsoleColor.Green
    Console.WriteLine(encrypted)
    let decrypted = decrypt encrypted key
    Console.WriteLine(decrypted)
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
