open System
open System.IO
open System.Net.Sockets

// conn is TcpClient.

/// StreamWriter initialization.
let private ircWriter = Lazy.Create(fun() -> 
    let conn = GetConnInstance()
    let sr = new StreamWriter( conn.GetStream() )
    sr.AutoFlush <- true
    sr)

/// StreamWriter instance. 
let GetWriterInstance() = ircWriter.Value