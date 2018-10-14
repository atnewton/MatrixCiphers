// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    Console.ForegroundColor <- ConsoleColor.Green
    printfn "Hello World from F#!"
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
