using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGame : MonoBehaviour
{
    public Transform biker;
    public Image Background;
    public AudioSource buttonSound;
    private bool isNext = false;
    private bool isPrevious = false;

    public Button nextBtn;
    public Button previousBtn;

    private float curTime;
    private float timeOfTravel = 2f;
    private float normalizedValue;

    public int curLevel = 0;
    public int levelAvailable;


    public GameObject[] goBtns;

    public GameObject[] victories;

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt("curLevel");
        goBtns[curLevel].SetActive(true);
        Background.GetComponent<RectTransform>().anchoredPosition = new Vector3(1290f - 500f*curLevel, 350f, 0);

        if (curLevel + 1 >= levelAvailable)
        {
            nextBtn.gameObject.SetActive(false);
        }
        else
        {
            nextBtn.gameObject.SetActive(true);
        }
        if (curLevel <= 0)
        {
            previousBtn.gameObject.SetActive(false);
        }
        else
        {
            previousBtn.gameObject.SetActive(true);
        }

        buttonSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("level1") != 0)
        {
            victories[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("level2") != 0)
        {
            victories[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("level3") != 0)
        {
            victories[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("level4") != 0)
        {
            victories[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("level5") != 0)
        {
            victories[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("level6") != 0)
        {
            victories[5].SetActive(true);
        }
    }
    public void Next()
    {
        buttonSound.Play();
        isNext = true;
        goBtns[curLevel].SetActive(false);
        biker.GetComponent<Animator>().SetBool("isBack", false);
        biker.GetComponent<RectTransform>().anchoredPosition = new Vector3(-300f, -360f, 0);
        nextBtn.gameObject.SetActive(false);
        previousBtn.gameObject.SetActive(false);
    }

    public void Previous()
    {
        buttonSound.Play();
        isPrevious = true;
        goBtns[curLevel].SetActive(false);
        biker.GetComponent<Animator>().SetBool("isBack", true);
        biker.GetComponent<RectTransform>().anchoredPosition = new Vector3(-300f, -210f, 0);
        nextBtn.gameObject.SetActive(false);
        previousBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isNext)
        {
            curTime += Time.deltaTime;
            normalizedValue = curTime / timeOfTravel;
            Background.GetComponent<RectTransform>().anchoredPosition = 
            Vector3.Lerp(new Vector3(1290f - 500f*curLevel, 350f, 0), new Vector3(1290f - 500f*(curLevel+1), 350f, 0), normalizedValue);           
        }

        if (isNext && curTime >= timeOfTravel)
        {
            curTime = 0;
            isNext = false;
            curLevel++;
            if (!previousBtn.gameObject.activeSelf)
            {
                previousBtn.gameObject.SetActive(true);
            }
            if (curLevel + 1 >= levelAvailable)
            {
                nextBtn.gameObject.SetActive(false);
            }else
            {
                nextBtn.gameObject.SetActive(true);
            }
            for (int i = 0; i < goBtns.Length; i++)
            {
                if (i == curLevel)
                {
                    goBtns[i].SetActive(true);
                }
                else
                {
                    goBtns[i].SetActive(false);
                }
            }
        }

        if (isPrevious)
        {
            curTime += Time.deltaTime;
            normalizedValue = curTime / timeOfTravel;
            Background.GetComponent<RectTransform>().anchoredPosition =
            Vector3.Lerp(new Vector3(1290f - 500f*curLevel, 350f, 0), new Vector3(1290f - 500f*(curLevel - 1), 350f, 0), normalizedValue);         
        }
        if (isPrevious && curTime >= timeOfTravel)
        {
            curTime = 0;
            isPrevious = false;
            curLevel--;
            if (curLevel <= 0)
            {
                previousBtn.gameObject.SetActive(false);
            }else
            {
                previousBtn.gameObject.SetActive(true);
            }
            if (!nextBtn.gameObject.activeSelf)
            {
                nextBtn.gameObject.SetActive(true);
            }
            for(int i = 0;i<goBtns.Length;i++)
            {
                if(i == curLevel)
                {
                    goBtns[i].SetActive(true);
                }else
                {
                    goBtns[i].SetActive(false);
                }
            }
        }
    }

    public void Level1()
    {
        buttonSound.Play();
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        buttonSound.Play();
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        buttonSound.Play();
        SceneManager.LoadScene(4);
    }

    public void Level4()
    {
        buttonSound.Play();
        SceneManager.LoadScene(5);
    }

    public void Level5()
    {
        buttonSound.Play();
        SceneManager.LoadScene(6);
    }

    public void Level6()
    {
        buttonSound.Play();
        SceneManager.LoadScene(7);
    }
}
