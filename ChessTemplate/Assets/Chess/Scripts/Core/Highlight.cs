using UnityEngine;

public class Highlight : MonoBehaviour
{
    private ChessPiece selectedPiece;
    private int targetRow;
    private int targetColumn;

    public void SetTarget(ChessPiece piece, int row, int column)
    {
        selectedPiece = piece; // Store the selected piece
        targetRow = row;       // Target position on the board
        targetColumn = column;
    }

    private void OnMouseDown()
    {
        if (selectedPiece != null)
        {
            Debug.Log($"Moving {selectedPiece.GetType().Name} to ({targetRow}, {targetColumn})");

            // Move the piece using ChessBoardPlacementHandler
            ChessBoardPlacementHandler.Instance.MovePiece(selectedPiece, targetRow, targetColumn);

            // Clear all highlights after the move
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            // Reset the selected piece
            selectedPiece = null;
        }
    }
}
