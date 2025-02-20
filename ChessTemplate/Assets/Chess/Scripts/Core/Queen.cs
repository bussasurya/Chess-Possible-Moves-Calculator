using UnityEngine;

public class Queen : ChessPiece
{
    public override void HighlightMoves()
    {
        // Queen moves like Rook + Bishop (all directions)
        HighlightDirection(1, 0);   // Up
        HighlightDirection(-1, 0);  // Down
        HighlightDirection(0, 1);   // Right
        HighlightDirection(0, -1);  // Left
        HighlightDirection(1, 1);   // Diagonal Up-Right
        HighlightDirection(1, -1);  // Diagonal Up-Left
        HighlightDirection(-1, 1);  // Diagonal Down-Right
        HighlightDirection(-1, -1); // Diagonal Down-Left
    }

    private void HighlightDirection(int rowStep, int colStep)
    {
        int r = row + rowStep;
        int c = column + colStep;

        while (IsValid(r, c))
        {
            // Check if a piece is in the way
            ChessPiece piece = GetPieceAt(r, c);

            if (piece != null)
            {
                // Log piece detection for debugging
                Debug.Log($"Piece detected at ({r}, {c}): {piece.name}");

                // If it's the same color, block the path and stop highlighting
                if (piece.isWhite == isWhite)
                {
                    break;
                }

                // Allow capturing enemy pieces but stop further highlights
                ChessBoardPlacementHandler.Instance.Highlight(r, c);
                break;
            }

            // Highlight empty tiles
            ChessBoardPlacementHandler.Instance.Highlight(r, c);

            r += rowStep;
            c += colStep;
        }
    }

    private ChessPiece GetPieceAt(int r, int c)
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(r, c);
        if (tile == null) return null;

        foreach (Transform child in tile.transform)
        {
            ChessPiece piece = child.GetComponent<ChessPiece>();
            if (piece != null) return piece;
        }
        return null;
    }

    private bool IsValid(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;
}
