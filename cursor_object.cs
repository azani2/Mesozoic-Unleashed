using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false; // Hide system cursor
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        rectTransform.position = mousePosition;
    }
}
