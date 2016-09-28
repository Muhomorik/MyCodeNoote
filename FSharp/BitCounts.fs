module BitCountingAlgorithms =
    let inline fastGetBitsCount (i:uint32) =
         let mutable i = i - ((i >>> 1) &&& 0x55555555u)
         i <- (i &&& 0x33333333u) + ((i >>> 2) &&& 0x33333333u)
         (((i + (i >>> 4)) &&& 0x0F0F0F0Fu) * 0x01010101u) >>> 24
 
    let safeGetBits (i:uint32) =
        let mutable count = 0u
        let mutable n = i
        while n <> 0u do
            if (n &&& 1u) = 1u then
                count <- count + 1u
            n <- n >>> 1
        count
 
    let private arrayBasedGetBitsData =
        Array.init 0x10000 (uint32 >> safeGetBits)
 
    let arrayBasedGetBits (i:uint32) =
        let lower =  i &&& 0x0000FFFFu
        let upper = (i &&& 0xFFFF0000u) >>> 16
        arrayBasedGetBitsData.[int lower] + arrayBasedGetBitsData.[int upper]
 
    let internal validate () =
        let sw = System.Diagnostics.Stopwatch.StartNew ()
 
        let mutable count = 0L
        let mutable i = int64 System.UInt32.MinValue
        while i <= int64 System.UInt32.MaxValue do
            let viaFast = fastGetBitsCount (uint32 i)
            let viaArray = arrayBasedGetBits (uint32 i)
            if viaFast <> viaArray then failwith <| sprintf "Failed on %d" i
            i <- i + 1L
            count <- count + 1L
 
        System.Console.WriteLine ("All good. Check completed in {0}ms (#{1} items checked)", sw.ElapsedMilliseconds, count)