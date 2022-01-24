using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Script : MonoBehaviour
{
    [SerializeField]
    private Transform emptySpace;
    private Camera cam;
    [SerializeField] private TileScript[] tiles;
    private int emptySpaceIndex = 8;
    public bool isVictory = false;
    public GameObject panel;

    void Start()
    {
        cam = Camera.main;
        Shuffle();
    }


    void Update()
    {
        if (!isVictory)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if(hit)
                {
                    if(Vector2.Distance(emptySpace.position, hit.transform.position) <3f)
                    {
                        GameObject.Find("BrickSound").GetComponent<AudioSource>().Play();
                        Vector2 lastEmptySpacePosition = emptySpace.position;
                        TileScript thisTile = hit.transform.GetComponent<TileScript>();
                        emptySpace.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = findIndex(thisTile);
                        tiles[emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                        emptySpaceIndex = tileIndex;
                    }
                }
            }
            int correctTiles = 0;
            foreach (var t in tiles)
            {
                if (t != null)
                {
                    if (t.inRightPlace)
                        correctTiles++;
                }
            }
            if (correctTiles >= tiles.Length - 1)
            {
                panel.SetActive(true);
                GameObject.Find("VictorySound").GetComponent<AudioSource>().Play();
                PlayerPrefs.SetInt("level2", 1);
                PlayerPrefs.SetInt("curLevel", 1);
                isVictory = true;
            }

        }
        
    }


    public void Shuffle()
    {
        if(emptySpaceIndex != 8)
        {
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn8LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 8;
        }
        int invertion;
        do
        {
            for (int i = 0; i <= 7; i++)
            {
                if (tiles[i] != null)
                {
                    var lastPos = tiles[i].targetPosition;
                    int randomIndex = Random.Range(0, 7);
                    tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                    tiles[randomIndex].targetPosition = lastPos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
            }
            invertion = GetInversions();
        } while (invertion%2 != 0);
        
    }

    public int findIndex(TileScript ts)
    {
        for(int i = 0; i< tiles.Length;i++)
        {
            if(tiles[i] != null)
            {
                if(tiles[i] == ts)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for(int i = 0; i<tiles.Length; i ++)
        {
            int thisTileInvertion = 0;
            for(int j = i;j<tiles.Length;j++)
            {
                if (tiles[j] != null)
                {
                    if(tiles[i].number >tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

    public void Next()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }
}
