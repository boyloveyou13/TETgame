
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 correctPosition;

    public int number;
    public bool inRightPlace;

    void Awake()
    {
        correctPosition = new Vector3 (transform.position.x, transform.position.y,0);
        targetPosition = new Vector3(transform.position.x, transform.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        if (targetPosition == correctPosition)
            inRightPlace = true;
        else
            inRightPlace = false;
    }
}
