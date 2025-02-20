using UnityEngine;

public class Rook : ChessPiece
{
    public override void HighlightMoves()
    {
        HighlightDirection(1, 0);  // Move Up
        HighlightDirection(-1, 0); // Move Down
        HighlightDirection(0, 1);  // Move Right
        HighlightDirection(0, -1); // Move Left
    }

    private void HighlightDirection(int rowStep, int colStep)
    {
        int r = row + rowStep;
        int c = column + colStep;

        while (IsValid(r, c))
        {
            // Use HasPiece to check occupancy
            if (ChessBoardPlacementHandler.Instance.HasPiece(r, c))
            {
                Debug.Log($"Blocked by piece at ({r}, {c})");
                break; // Stop if a piece blocks the way
            }

            ChessBoardPlacementHandler.Instance.Highlight(r, c);
            r += rowStep;
            c += colStep;
        }
    }

    private bool IsValid(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;
}
