open Game
open Game.GetInput

[<EntryPoint>]
let main argv =

    let answer = YesOrNo "Play guessing game? (Y or N): "

    if answer then
        let gm = GameManager.Init()
        gm |> ignore
    
    printfn "Exiting Application...\n\n"
    0