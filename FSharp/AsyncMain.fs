[<EntryPoint>]
let main argv = 
    async{
    printfn "Main is on: %d" Thread.CurrentThread.ManagedThreadId

    return 0
    } |> Async.RunSynchronously // return an integer exit code