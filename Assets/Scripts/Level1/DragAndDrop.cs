using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;
    int orderInLayer = 1;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.transform.CompareTag("PuzzlePiece"))
                {
                    if (!hit.transform.GetComponent<PieceScript>().inRightPosition)
                    {
                        SelectedPiece = hit.transform.gameObject;
                        SelectedPiece.GetComponent<PieceScript>().Selected = true;
                        SelectedPiece.GetComponent<SortingGroup>().sortingOrder = orderInLayer;
                        orderInLayer++;
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(SelectedPiece != null)
                SelectedPiece.GetComponent<PieceScript>().Selected = false;
            SelectedPiece = null;
        }

        if(SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }
    }
}
