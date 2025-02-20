using UnityEngine;

public class King : ChessPiece
{
    public override void HighlightMoves()
    {
        HighlightSingleStep(1, 0);    // Up
        HighlightSingleStep(-1, 0);   // Down
        HighlightSingleStep(0, 1);    // Right
        HighlightSingleStep(0, -1);   // Left
        HighlightSingleStep(1, 1);    // Up-Right
        HighlightSingleStep(1, -1);   // Up-Left
        HighlightSingleStep(-1, 1);   // Down-Right
        HighlightSingleStep(-1, -1);  // Down-Left
    }

    private void HighlightSingleStep(int rowStep, int colStep)
    {
        int r = row + rowStep;
        int c = column + colStep;

        if (IsValid(r, c) && !IsOccupied(r, c))
        {
            ChessBoardPlacementHandler.Instance.Highlight(r, c);
        }
    }

    private bool IsOccupied(int r, int c) => ChessBoardPlacementHandler.Instance.HasPiece(r, c);
    private bool IsValid(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;
}
