# F#. Serialization of Option type for RavenDB #

## Problem ##

F# [Option type](http://fsharpforfunandprofit.com/posts/the-option-type/) is not serialized right for Some(). Example: 

	Some("Västerås")
to

	"Plats": {},

None is serialized to *null* (right):

	"Plats": null,

## Solution ##

Only things I could find.

- [F# and Raven DB](http://www.colinbull.net/2013/04/29/FSharp-and-raven-db/) by Colin Bull.
	
  Halfway down the page. Source code for converter at GitHub, *colinbull/FSharpEnt /src/FSharp.Enterprise/[Json.fs](https://github.com/colinbull/FSharpEnt/blob/develop/src/FSharp.Enterprise/Json.fs)*

	
	let customisedStore =
		let customiseSerialiser (s : Raven.Imports.Newtonsoft.Json.JsonSerializer) =
		s.Converters.Add(new Json.MapTypeConverter())
		s.Converters.Add(new Json.UnionTypeConverter())

		let store = new DocumentStore(Url="http://localhost:8080")
		store.Conventions.CustomizeJsonSerializer <- (fun s -> (customiseSerialiser s))
		store.Initialize()

- Json.NET Type Converters for the F# Option, List and Tuple Types by Lev Gorodinski. Description [here](http://gorodinski.com/blog/2013/01/05/json-dot-net-type-converters-for-f-option-list-tuple/). Sources on [GitHub](https://github.com/eulerfx/JsonNet.FSharp).

- For me, using the source causes an error:
> The type 'Imports.Newtonsoft.Json.JsonSerializer' is not compatible with the type 'JsonSerializer'

To fix it, change your custom converter signature from:

	inherit JsonConverter()
to:

	inherit Raven.Imports.Newtonsoft.Json.JsonConverter()