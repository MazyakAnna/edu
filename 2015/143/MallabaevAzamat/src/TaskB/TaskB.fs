﻿module TaskB

let (>*>) (a:int array array) (b:int array array) =
  [|[|a.[0].[0] * b.[0].[0] + a.[1].[0] * b.[0].[1];
      a.[0].[0] * b.[1].[0] + a.[1].[0] * b.[1].[1]|];
    [|a.[0].[1] * b.[0].[0] + a.[1].[1] * b.[0].[1];
      a.[0].[1] * b.[1].[0] + a.[1].[1] * b.[1].[1]|]|]

let rec (>^>) (a:int array array) n =
  if n = 1 then a
  else a >*> (a >^> (n - 1))

let main n =
  if n = 0 then 0
  else if n > 0 then ([|[|1; 1|];
                        [|1; 0|]|] >^> n).[0].[1]
  else if (-n) % 2 = 1 then ([|[|1; 1|];
                               [|1; 0|]|] >^> -n).[0].[1]
  else -([|[|1; 1|];
           [|1; 0|]|] >^> -n).[0].[1]

[<EntryPoint>]
let entry args =
  printfn "%i" (main (int (System.Console.ReadLine())))
  ignore <| System.Console.ReadKey()
  0