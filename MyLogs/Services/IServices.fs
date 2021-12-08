namespace rec MyLogs.Services

open System
open System.Threading.Tasks
open FSharp.Data.Adaptive
open Fun.Result
open MyLogs.Core


type IPlatformService =
    abstract DefaultDataDir: string
    abstract SelectFolder: unit -> string
    abstract Close: unit -> unit
    abstract SwitchBackgroundBlur: bool -> Task
    abstract SwitchAutoStart: bool -> Task
    abstract GetSize: unit -> float * float
    abstract ShowWindowController: unit -> unit
    abstract HideWindowController: unit -> unit

    [<CLIEvent>]
    abstract Activated: IEvent<System.EventHandler, System.EventArgs>
    [<CLIEvent>]
    abstract Deactivated: IEvent<System.EventHandler, System.EventArgs>


type ISettingsService =
    abstract Settings: aval<Settings>

    abstract GetSettings: unit -> Settings
    abstract SaveSettings: shouldNotify: bool * (Settings -> Settings) -> TaskResult<unit, string>


type ILogsService =
    abstract Logs: aval<Map<DateOnly, Logs>>
    abstract Tags: aval<Tags>

    abstract ClearLogsCache: unit -> unit

    abstract LoadLogs: DateOnly -> TaskResult<unit, string>
    abstract CreateLog: DateOnly * Log -> TaskResult<unit, WriteDataError>
    abstract ModifyLog: DateOnly * Log * isDelete: bool -> TaskResult<unit, WriteDataError>
    abstract MarkLogAsDone: DateOnly * Log -> TaskResult<unit, WriteDataError>
    abstract OrderLog: sourceDate: DateOnly * sourceLog: Log * targetDate: DateOnly * targetLog: Log -> TaskResult<unit, WriteDataError>

    abstract LoadLogTags: unit -> TaskResult<unit, string>
    abstract WriteLogTags: Tag list -> TaskResult<unit, WriteDataError>

    abstract ReadLogDetailCache: unit -> Task<Detail option>
    abstract WriteLogDetailCache: Detail option -> Task<unit>


// =======================================================


type WriteDataError =
    | FailedToRead of string
    | SettingsError of string
    | DataIsChanged
