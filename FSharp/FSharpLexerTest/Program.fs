// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

// Examples:
// https://en.wikibooks.org/wiki/F_Sharp_Programming/Lexing_and_Parsing

// http://realfiction.net/2014/10/20/Lexing-and-parsing-in-F/

// CObol examples:
// https://github.com/jiuweigui/cobol

open System
open TheLexer
open TheParser
open Ast

open System.IO
open Microsoft.FSharp.Text.Lexing

[<EntryPoint>]
let main argv = 
    
    let parse (str:string) = 
        let lexbuf = LexBuffer<char>.FromString str
        let res = TheParser.start TheLexer.tokenize lexbuf
        res
    
    let x = """
	IDENTIFICATION DIVISION.
	AUTHOR. jiuweigui.
	PROGRAM-ID. if-example.
	DATA DIVISION.
	WORKING-STORAGE SECTION.
	01 UserInput PIC X(20).
	PROCEDURE DIVISION.
	DISPLAY "Please enter your name in upper-case: ".
	ACCEPT UserInput.
	IF UserInput IS ALPHABETIC-LOWER
		DISPLAY "Plz uppercase. Fixed it, ", UserInput
	END-IF
	STOP RUN."""   
  
    let myres = parse x

    //let lxm = lexbuf.Lexeme  // get the lexeme as an array of characters or bytes
    //let lxm2 = LexBuffer.LexemeString lexbuf // get the lexeme as a string, for Unicode lexing
  
    Console.WriteLine("(press any key)")   
    Console.ReadKey(true) |> ignore
    
    
    printfn "%A" argv
    0 // return an integer exit code
