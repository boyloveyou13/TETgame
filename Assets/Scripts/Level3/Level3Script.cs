using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level3Script : MonoBehaviour
{
    private Camera cam;

    public GameObject[] crosses;
    public Questions question;

    public TextMeshProUGUI questionText;
    public InputField inputField;
    private int currentCross;

    private GameObject squarehide;
    private int childs;
    private int Victory = 0;
    private bool isVictory;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                for(int i = 0;i<crosses.Length;i++)
                {
                    if(!question.questionsList[i].isTrue)
                    {
                        GameObject.Find("BrickSound").GetComponent<AudioSource>().Play();
                        squarehide = crosses[i].transform.GetChild(0).gameObject;
                        childs = squarehide.transform.childCount;
                        if (hit.transform.gameObject == crosses[i])
                        {
                            inputField.Select();
                            inputField.ActivateInputField();
                            currentCross = i;
                            questionText.text = question.questionsList[i].question;
                            for (int j = 0; j < childs; j++)
                            {
                                if (squarehide.transform.GetChild(j).GetComponent<SpriteRenderer>().color != new Color(0.4f, 0.8f, 1, 1))
                                    squarehide.transform.GetChild(j).GetComponent<SpriteRenderer>().color = new Color(1, 1, 0.3f, 1);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < childs; j++)
                            {
                                if (squarehide.transform.GetChild(j).GetComponent<SpriteRenderer>().color != new Color(0.4f, 0.8f, 1, 1))
                                    squarehide.transform.GetChild(j).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                            }
                        }
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckButton();
        }    
    }

    public void CheckButton()
    {
        if(!isVictory)
        {
            if (inputField.text.ToLower() == question.questionsList[currentCross].answer.ToLower())
            {
                inputField.text = string.Empty;
                GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
                crosses[currentCross].transform.GetChild(1).gameObject.SetActive(true);
                question.questionsList[currentCross].isTrue = true;
                CheckAllAnswer();
            }
            else
            {
                GameObject.Find("WrongSound").GetComponent<AudioSource>().Play();
                inputField.Select();
                inputField.ActivateInputField();
            }
        }   
    }    

    public void CheckAllAnswer()
    {
        Victory = 0;
        foreach(Questions.QuestionData quest in question.questionsList)
        {
            if(quest.isTrue)
            {
                Victory++;
            }
        }
        if(Victory >=12)
        {
            panel.SetActive(true);
            GameObject.Find("VictorySound").GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("level3", 1);
            PlayerPrefs.SetInt("curLevel", 2);
            isVictory = true;
        }
    }

    public void Next()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }
}
