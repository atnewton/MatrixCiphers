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




//module vigenere =
//    let keyschedule (key:string) =
//        let s = key.ToUpper().ToCharArray() |> Array.filter System.Char.IsLetter
//        let l = Array.length s
//        (fun n -> int s.[n % l])
 
//    let enc k c = ((c + k - 130) % 26) + 65
//    let dec k c = ((c - k + 130) % 26) + 65
//    let crypt f key = Array.mapi (fun n c -> f (key n) c |> char)
 
//    let encrypt key (plaintext:string) =
//        plaintext.ToUpper().ToCharArray()
//        |> Array.filter System.Char.IsLetter
//        |> Array.map int
//        |> crypt enc (keyschedule key)
//        |> (fun a -> new string(a))
 
//    let decrypt key (ciphertext:string) =
//        ciphertext.ToUpper().ToCharArray()
//        |> Array.map int
//        |> crypt dec (keyschedule key)
//        |> (fun a -> new string(a))
 
//let passwd = "Vigenere Cipher"
//let cipher = vigenere.encrypt passwd "Beware the Jabberwock, my son! The jaws that bite, the claws that catch!"
//let plain = vigenere.decrypt passwd cipher
//printfn "%s\n%s" cipher plain

//C:\src\fsharp>fsi vigenere.fsx
//WMCEEIKLGRPIFVMEUGXQPWQVIOIAVEYXUEKFKBTALVXTGAFXYEVKPAGY
//BEWARETHEJABBERWOCKMYSONTHEJAWSTHATBITETHECLAWSTHATCATCH