using UnityEngine;

public class Knight : ChessPiece
{
    public override void HighlightMoves()
    {
        // Knight moves in "L" shape
        HighlightJump(2, 1);  // Up 2, Right 1
        HighlightJump(2, -1); // Up 2, Left 1
        HighlightJump(-2, 1); // Down 2, Right 1
        HighlightJump(-2, -1); // Down 2, Left 1

        HighlightJump(1, 2);  // Right 2, Up 1
        HighlightJump(1, -2); // Left 2, Up 1
        HighlightJump(-1, 2); // Right 2, Down 1
        HighlightJump(-1, -2); // Left 2, Down 1
    }

    private void HighlightJump(int rowStep, int colStep)
    {
        int r = row + rowStep;
        int c = column + colStep;

        if (IsValid(r, c) && !IsOccupied(r, c))
        {
            ChessBoardPlacementHandler.Instance.Highlight(r, c);
        }
    }

    private bool IsOccupied(int r, int c)
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(r, c);
        foreach (Transform child in tile.transform)
        {
            if (child.CompareTag("ChessPiece"))
            {
                // Ensure it's not the same color (black pieces block black knight)
                if (child.GetComponent<ChessPiece>().isWhite == isWhite)
                {
                    Debug.Log($"Blocked by own piece at ({r}, {c}): {child.name}");
                    return true; // Blocked by own piece
                }
                Debug.Log($"Opponent piece detected at ({r}, {c}): {child.name}");
                return true; // Opponent piece found (if applicable)
            }
        }
        return false; // No piece found
    }

    private bool IsValid(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;
}
