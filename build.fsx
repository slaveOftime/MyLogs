#r "nuget: Fake.IO.FileSystem"

open System.Diagnostics
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators


let formatAllFSharpFiles () =
    !!(__SOURCE_DIRECTORY__ </> "**/*.fs") ++ (__SOURCE_DIRECTORY__ </> "**/*.fsx")
    -- (__SOURCE_DIRECTORY__ </> "**/Fun.Blazor.Bindings/**/*.fs")
    -- (__SOURCE_DIRECTORY__ </> "**/obj/**/*.fs")
    -- (__SOURCE_DIRECTORY__ </> "**/bin/**/*.fs")
    |> Seq.iter (fun f ->
        printfn "%s" f
        Process.Start("fantomas", [ f ]).WaitForExit()
    )

formatAllFSharpFiles ()
