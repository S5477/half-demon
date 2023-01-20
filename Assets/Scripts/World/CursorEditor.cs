using UnityEngine;

public class CursorEditor : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;
   
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, _hotSpot, _cursorMode);
    }

    void OnMouseEnter() {
        Cursor.SetCursor(cursorTexture, _hotSpot, _cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, _cursorMode);
    }
}