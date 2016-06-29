open System
open System.IO


// Read N lines from Console.
// http://stackoverflow.com/questions/37910107/read-strings-from-console-without-for-loop

let readNLines n =  Array.init n (fun _ -> Console.ReadLine())

let getArrayOfIntFromConsole() = 
    let lines = Console.ReadLine() |> int |> readNLines
    let numArray = lines |> Array.map(int)
    numArray
    