namespace Game

open System
open Game.GetInput

type GameManager(min:int, max:int) =
    let rng = Random()
    member val private RandomNumberToGuess = rng.Next(min, max + 1)
    member val private GuessNumberMsg = sprintf "Guess a number between %i - %i" min max
    
    member val Max = max with get
    member val Min = min with get

    member private this.Start() =
        let number = GetIntWhere (this.GuessNumberMsg) (fun num -> num >= min && num <= max)

        if number = this.RandomNumberToGuess then
            Console.ForegroundColor <- ConsoleColor.Yellow
            printfn "You Won!!!"
            Console.ResetColor()
            this
        else
            printfn "Sorry wrong guess...\nTry again.\n"
            this.Start()

    static member Init() =
        printfn "Welcome to the guessing number game!"

        let min = GetInt "Input the min number to start guessing from"
        let max = GetIntWhere (sprintf "Input the max number to stop guessing at (has to be greater than %i)" min) (fun x -> x > min)

        let gm = GameManager(min, max)
        gm.Start()