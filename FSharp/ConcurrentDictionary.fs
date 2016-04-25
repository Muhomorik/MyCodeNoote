open System.Collections.Concurrent
open NUnit.Framework
open FsUnit

let diggRecords = new ConcurrentDictionary<string, int>()

/// AddOrUpdate - replace existing value.
let diggRecInsert (dict :ConcurrentDictionary<string, int>) (what :string) (age :int) = 
    dict.AddOrUpdate(what, age, (fun _ _ -> age ))

/// TryAdd
let diggRecAdd (dict :ConcurrentDictionary<string, int>) (what :string) (age :int) = 
    let res = dict.TryAdd(what, age)
    match res with
    | true -> 
        //printfn "Add new %s size: %d" what dict.Count
        ()
    | false -> failwith "diggRecAdd failed"

/// TryUpdate
let diggRecUpdate (dict :ConcurrentDictionary<string, int>) (what :string) (age_new :int) (age_stored :int) = 
    let res = dict.TryUpdate(what, age_new, age_stored)
    match res with
    | true -> 
        //printfn "\nupdate %s from %d to %d\n" what age_stored age_new
        ()
    | false -> failwith "diggRecUpdate failed"
    

// Test

let diggRecords = new ConcurrentDictionary<string, int>()

[<Test>]
let``test Concurrent insert``()=

    let res = diggRecInsert diggRecords "abc" 1
    let res = diggRecInsert diggRecords "abc" 1
    
    let ok, stored= diggRecords.TryGetValue "abc"
    
    ok |> should be True
    stored |> should equal 1

    let res2 = diggRecInsert diggRecords "abc" 2    
    
    let ok2, stored2 = diggRecords.TryGetValue "abc"
    
    ok2 |> should be True
    stored2 |> should equal 2