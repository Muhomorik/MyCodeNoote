open System
open System.IO

async {
    use sw = new StreamWriter(new FileStream(@"c:\work\f2.txt",  FileMode.Create, FileAccess.Write, FileShare.None, bufferSize= 4096, useAsync= true))
    for line in File.ReadLines @"c:\Work\f1.txt" do
        do! sw.WriteLineAsync(line) |>  Async.AwaitTask
}