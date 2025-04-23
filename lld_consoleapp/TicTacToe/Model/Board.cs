

// Board has Players
using lld_console_app.TicTacToe.Model;

public class Board
{
    public PlayingPiece[,] Pieces { get; set; }

    public Board(int size)
    {
        this.Pieces = new PlayingPiece[size, size];
        // for(int i = 0; i < size; i++)
        // {
        //     for(int j = 0; j < size; j++)
        //     {
        //         Pieces[i, j] = new PlayingPiece(' ');
        //     }
        // }
    }

    public bool CheckGameOver()
    {
        // Check if the game is over
        // Check rows  
        for(int i = 0; i < Pieces.GetLength(0); i++)
        {
            if (Pieces[i, 0] != null && Pieces[i, 0] == Pieces[i, 1] && Pieces[i, 1] == Pieces[i, 2])
            {
                return true;
            }
        }

        // Check columns
        for(int i = 0; i < Pieces.GetLength(1); i++)
        {
            if (Pieces[0, i] != null && Pieces[0, i] == Pieces[1, i] && Pieces[1, i] == Pieces[2, i])
            {
                return true;
            }
        }
        // Check diagonals
        for(int i = 0; i < Pieces.GetLength(0); i++)
        {
            if (Pieces[0, 0] != null && Pieces[0, 0] == Pieces[1, 1] && Pieces[1, 1] == Pieces[2, 2])
            {
                return true;
            }
            if (Pieces[0, 2] != null && Pieces[0, 2] == Pieces[1, 1] && Pieces[1, 1] == Pieces[2, 0])
            {
                return true;
            }
        }
        // check draw


        return false;
    }

    public bool CheckDraw()
    {
        for(int i = 0; i < Pieces.GetLength(0); i++)
        {
            for(int j = 0; j < Pieces.GetLength(1); j++)
            {
                if (Pieces[i, j] == null)
                {
                    return false;
                }
            }
        }
        return true;
    }
}