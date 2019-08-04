open Game
open Game.GetInput

[<EntryPoint>]
let main args =

    let answer = YesOrNo "Play guessing game? (Y or N): "

    if answer then
        let gm = GameManager.Init()
        gm.Start() |> ignore
    else
        printfn "Ok then consider playing a match next time."
    
    printfn "Exiting Application...\n\n"
    0