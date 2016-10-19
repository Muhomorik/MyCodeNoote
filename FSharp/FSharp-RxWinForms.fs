#I "packages/Rx-Linq/lib/net45"
#I "packages/Rx-Interfaces/lib/net45"
#I "packages/Rx-Core/lib/net45"
#I "packages/FSharp.Control.Reactive/lib/net40"
 
#r "FSharp.Control.Reactive.dll"
#r "System.Reactive.Core.dll"
#r "System.Reactive.Interfaces.dll"
#r "System.Reactive.Linq.dll"
 
open System
open System.Windows.Forms
open System.Drawing
open FSharp.Control.Reactive
 
type Action =
  | Increment
  | Decrement
 
 
let form = new Form(Width= 400, Height = 300, Visible = true, Text = "Hello World")
form.TopMost <- true
 
let panel = new FlowLayoutPanel()
panel.Dock <- DockStyle.Fill
panel.WrapContents <- false
 
let incBtn = new Button()
let decBtn = new Button()
let label = new Label()
 
 
incBtn.Text <- "+"
decBtn.Text <- "-"
 
incBtn.AutoSize <- true
decBtn.AutoSize <- true
 
panel.Controls.Add(decBtn)
panel.Controls.Add(label)
panel.Controls.Add(incBtn)
 
let model = 0
 
let view model =
  label.Text <- sprintf "%d" model
 
 
let update (model : int32) (action : Action) =
  match action with
    | Increment -> model + 1
    | Decrement -> model - 1
 
 
let increment = Observable.map (fun _ -> Increment) incBtn.Click
let decrement = Observable.map (fun _ -> Decrement) decBtn.Click
 
let stateObservable =
  Observable.merge increment decrement
  |> Observable.scanInit model update
 
Observable.subscribe view stateObservable
 
form.Controls.Add(panel)
 
form.Show()