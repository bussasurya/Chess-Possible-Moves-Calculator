using UnityEngine;

public class Pawn : ChessPiece
{
    public override void HighlightMoves()
    {
        int direction = 1; // For black pawns, move downwards

        // Forward Move (One Step)
        if (IsValid(row + direction, column) && IsEmpty(row + direction, column))
        {
            ChessBoardPlacementHandler.Instance.Highlight(row + direction, column);

            // Initial Double Move (Only if pawn is on the starting row for black)
            if (row == 1 && IsEmpty(row + 2 * direction, column))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 2 * direction, column);
            }
        }

        // Capture Move (Diagonally Left and Right)
        TryCapture(row + direction, column + 1);
        TryCapture(row + direction, column - 1);
    }

    private void TryCapture(int r, int c)
    {
        if (IsValid(r, c) && IsEnemy(r, c))
        {
            ChessBoardPlacementHandler.Instance.Highlight(r, c);
        }
    }

    private bool IsValid(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;

    private bool IsEmpty(int r, int c) =>
        ChessBoardPlacementHandler.Instance.GetTile(r, c).transform.childCount == 0;

    private bool IsEnemy(int r, int c)
    {
        var piece = ChessBoardPlacementHandler.Instance.GetTile(r, c).GetComponent<ChessPiece>();
        return piece != null && piece.isWhite; // Only white is the enemy
    }
}
