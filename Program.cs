// See https://aka.ms/new-console-template for more information
using Tic_Tac_Toe;

Console.WriteLine("Hello, welcome to Tic Tac Toe!");
Console.WriteLine("Please select a game mode:");

Player[] players = new Player[2];

while (true)
{
    Console.WriteLine("1. Single Player Game");
    Console.WriteLine("2. Hotseat Game");
    Console.WriteLine("3. Single Player Game with Rounds");
    Console.WriteLine("4. Hotseat Game with Rounds");
    Console.WriteLine("5. Exit");

    var input = Console.ReadKey(true);
    switch (input.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Starting Single Player Game");
            players[0] = Player.HandlePlayer(1);

            players[1] = new Player('X', "Computer");
            players[1].setIsBot(true);
            new Logic(players, new Gameboard(), false);

            break;
        case ConsoleKey.D2:
            Console.WriteLine("Starting Hotseat Game");
            players[0] = Player.HandlePlayer(1);
            Thread.Sleep(500);
            
            players[1] = Player.HandlePlayer(2);
            Thread.Sleep(500);

            new Logic(players, new Gameboard(), false);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Starting Single Player Game with Rounds");

            players[0] = Player.HandlePlayer(1);

            players[1] = new Player('X', "Computer");
            players[1].setIsBot(true);
            new Logic(players, new Gameboard(), true);

            break;
        case ConsoleKey.D4:
            Console.WriteLine("Starting Hotseat Game with Rounds");
            players[0] = Player.HandlePlayer(1);
            Thread.Sleep(500);
            players[1] = Player.HandlePlayer(2);
            Thread.Sleep(500);
            new Logic(players, new Gameboard(), true);
            break;
        case ConsoleKey.D5:
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid input, please try again");
            break;
    }
}

