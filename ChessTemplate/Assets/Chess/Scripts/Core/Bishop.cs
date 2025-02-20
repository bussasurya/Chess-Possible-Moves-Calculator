using UnityEngine;

public class Bishop : ChessPiece
{
    public override void HighlightMoves()
    {
        HighlightDirection(1, 1);   // Up-Right
        HighlightDirection(1, -1);  // Up-Left
        HighlightDirection(-1, 1);  // Down-Right
        HighlightDirection(-1, -1); // Down-Left
    }

    private void HighlightDirection(int rowStep, int colStep)
    {
        int r = row + rowStep;
        int c = column + colStep;

        while (IsValid(r, c))
        {
            if (IsOccupied(r, c)) break;
            ChessBoardPlacementHandler.Instance.Highlight(r, c);
            r += rowStep;
            c += colStep;
        }
    }

    private bool IsOccupied(int r, int c) => ChessBoardPlacementHandler.Instance.HasPiece(r, c);
    private bool IsValid(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;
}
