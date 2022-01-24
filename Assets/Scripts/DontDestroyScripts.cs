using UnityEngine;

public class DontDestroyScripts : MonoBehaviour
{
    public Texture2D cursorArrow;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        
    }
}
