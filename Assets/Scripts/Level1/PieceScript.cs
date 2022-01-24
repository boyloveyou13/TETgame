using UnityEngine;
using UnityEngine.Rendering;

public class PieceScript : MonoBehaviour
{
    private Vector3 rightPosition;
    public bool inRightPosition;
    public bool Selected;
    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(3f, 7f), Random.Range(-3f, 3f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,rightPosition) < 0.5f)
        {
            if(!Selected)
            {
                if (!inRightPosition)
                {
                    GameObject.Find("BrickSound").GetComponent<AudioSource>().Play();
                    transform.position = rightPosition;
                    inRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    Camera.main.GetComponent<VictoryScript>().curCorrect++;
                }
            } 
        }
    }
}
