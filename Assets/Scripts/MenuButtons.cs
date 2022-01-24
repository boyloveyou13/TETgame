using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour
{
    public AudioSource buttonSound;
    public Image biker;
    public float curTime;
    public float timeOfTravel = 2f;
    public float timeOfExit = 3f;
    private float normalizedValue;
    private bool isPlayed = false;
    private bool isExited = false;
    public GameObject whiteScreen;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
    public void PlayGame()
    {
        buttonSound.Play();
        isPlayed = true;
    }

    private void Update()
    {
        if(isPlayed)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            curTime += Time.deltaTime;
            normalizedValue = curTime / timeOfTravel;
            biker.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(new Vector3(-600f,-360f,0), new Vector3(100f, -360f, 0), normalizedValue);
        }
        if (isPlayed && curTime >= timeOfTravel)
        {
            curTime = 0;
            isPlayed = false;
            whiteScreen.SetActive(true);
            StartCoroutine(waitforLoadScene());
            
        }
        if (isExited && curTime >= timeOfExit)
        {
            curTime = 0;
            isExited = false;
            Application.Quit();
        }
        if (isExited)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            curTime += Time.deltaTime;
            normalizedValue = curTime / timeOfExit;  
            biker.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(new Vector3(-600f, -360f, 0), new Vector3(550f, -360f, 0), normalizedValue);
        }
    }

    IEnumerator waitforLoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        buttonSound.Play();
        isExited = true;
    }
}
