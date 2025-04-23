// Player has Playing Piece

namespace lld_console_app.TicTacToe.Model
{
    public class Player
    {
        public string Name { get; set; }
        public PlayingPiece PieceType { get; set; }

        public Player(string name, PlayingPiece playingPiece)
        {
            this.Name = name;   
            this.PieceType = playingPiece;
        }
    }
}
