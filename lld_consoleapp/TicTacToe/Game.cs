
using System.Diagnostics.Contracts;
using lld_console_app.TicTacToe.Model;

class Game
{
    // Game logic goes here
    // Write logic to implement Tic Tac Toe game
    public Board Board { get; set; }
    public LinkedList<Player> Players { get; set; }
    public Game()
    {
        Players = new LinkedList<Player>();
        InitializeBoard();
    }
    public void InitializePlayers()
    {
        Console.WriteLine("Enter the number of players");
        int numPlayers = int.Parse(Console.ReadLine());
        for (int i = 0; i < numPlayers; i++)
        {
            Console.WriteLine("Enter the name of player " + (i + 1));
            string name = Console.ReadLine() ?? throw new InvalidOperationException("Name cannot be null");

            Console.WriteLine("Enter the piece of player " + (i + 1));
            string pieceInput = Console.ReadLine();
            if (string.IsNullOrEmpty(pieceInput))
            {
                throw new InvalidOperationException("Piece cannot be null or empty");
            }
            char piece = char.Parse(pieceInput);
            Player player = new Player(name, new PlayingPiece(piece));
            Players.AddLast(player);

        }
    }
    public void InitializeBoard()
    {
        Console.WriteLine("Enter the size of the board");   
        int size = int.Parse(Console.ReadLine());
        Board = new Board(size);
        InitializePlayers();
    
    }

    public void StartGame()
    {
        Console.WriteLine("Game Started");
        bool isGameOver = false;
        Player currentPlayer = Players.First.Value;
        while(isGameOver == false)
        {
            PrintBoard();
            Console.WriteLine("Enter the row and column to place the piece");
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            if (Board.Pieces[row, col] != null)
            {
                Console.WriteLine("Invalid move");
                continue;
            }
            
            Board.Pieces[row, col] = currentPlayer.PieceType;
            isGameOver = Board.CheckGameOver();
            
            if (isGameOver)
            {
                Console.WriteLine("Game Over");
                PrintBoard();
                bool isDraw = Board.CheckDraw();    
                if(isDraw)
                {
                    Console.WriteLine("Game is a draw");
                    break;
                }
                Console.WriteLine("Winner is " + currentPlayer.Name);
                break;
            }

             // Move current player to the end of the list and set the next player as current
            Players.RemoveFirst();
            Players.AddLast(currentPlayer);
            currentPlayer = Players.First.Value;

        }
    }

    public void PrintBoard()
    {
        for (int i = 0; i < Board.Pieces.GetLength(0); i++)
        {
            for (int j = 0; j < Board.Pieces.GetLength(1); j++)
            {
                if(Board.Pieces[i, j] == null)
                {
                    Console.Write("* ");
                }
                else   
                    Console.Write(Board.Pieces[i, j].Piece + " ");
            }
            Console.WriteLine();
        }
    }

    
}