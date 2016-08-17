module Ast

open System

type slotDeclaration= {
  Index : int
  Name : string
  Size : int
}

type dataSection=
  | WorkStorage of slotDeclaration list

type configurationSectionParagraph()= class end

type configurationSection= {
  ConfigSections: configurationSectionParagraph list
}

type inputOutputSection()= class end

type environmentDivision= {
  Config: configurationSection
  InOut: inputOutputSection
}

type identificationDivision= {
  ProgramId : string
  Author: string option
  Installation: string option
  DateWritten: DateTime option
  DateCompiled: DateTime option
}

type op=
  | Is

type condition=
  | Comparison of (string * op * string)

type command= 
  | DisplayStatement of string
  | FormatDisplayStatement of (string * string)
  | AcceptStatement of string
  | IfStatement of ifStatement
and ifStatement= {
  Condition: condition
  IfBranch: command list
  ElseBranch: command list option
}

type cobolSourceProgram = {
  IdentDiv : identificationDivision
  EnvDiv : environmentDivision option
  DataDiv : dataSection list option
  ProcDiv : command list option
  NestedCobolProg : cobolSourceProgram option
}