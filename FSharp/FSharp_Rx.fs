open System
open System.IO
open System.Reactive.Linq
open System.Reactive.Concurrency

// Install from NuGet:
// open System.Reactive.Core
// open System.Reactive.Linq

// Actions:
// http://www.visualfsharp.com/delegates/action.htm

// Inspiration for methods:
// https://github.com/fsprojects/FSharp.Control.Reactive/blob/master/src/FSharp.Control.Reactive/Observable.fs

// Creating and Subscribing to Simple Observable Sequences
// https://msdn.microsoft.com/en-us/library/hh242977(v=vs.103).aspx

/// Read lines and yield result as seq<string>.
let ReadLines (reader:StreamReader) =
    seq {
        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

/// Convert seq to Observable, note Scheduler. 
let ObserveLines(inputStream:StreamReader ) = 
    ReadLines(inputStream).ToObservable(Scheduler.CurrentThread)

/// Print line with prefix 1.
let myPrint1 x = printfn "1 - %s" x

/// Print line with prefix 2.
let myPrint2 x = printfn "2 - %s" x

/// Function for onError action.
let myErr(ex:Exception) = printfn "ERROR %s" ex.Message

/// Function for onComplete action.
let myComplete() = printfn "COMPLETE"

/// onNext takes string in.
let onNext = new Action<string>(myPrint1)

/// onError must take Exception.
let onError = new Action<Exception>(myErr)

/// onCompleted is a void function.
let onCompleted = new Action(myComplete)

// Alt. you can use lambdas.
// let onCompleted = new Action(fun _ -> printfn "COMPLETE 2")

// https://msdn.microsoft.com/en-us/library/hh242977(v=vs.103).aspx
[<EntryPoint>]
let main argv = 
    use reader = new StreamReader ("LiText.txt")

    /// Observable.
    let smth = ObserveLines reader

    // Example with Actions (there check overloads).

    use xObsEvents = smth.Subscribe(onNext, onError, onCompleted)
    xObsEvents.Dispose()  // actually may not be needen in F#.
    
    // COLD
    
    use xObsCold = smth.Subscribe( myPrint1 )
    xObsCold.Dispose()
    
    // HOT with multi-subscribers.

    /// Convert the sequence into a hot sequence.
    let hot = Observable.Publish(smth) 

    use xObs = hot.Subscribe( myPrint1 )
    use xObs2 = hot.Subscribe( myPrint2)
    
    /// Must connect before everything triggers.
    hot.Connect() |> ignore
    
    xObs.Dispose()
    xObs2.Dispose()
    
    Console.WriteLine("Press any key...")
    Console.ReadLine() |> ignore

    0 // return an integer exit code
