using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public GameObject panel;
    public int curCorrect = 0;
    public bool isVictory;
    // Update is called once per frame
    void Update()
    {
        if(!isVictory && curCorrect >= 25)
        {
            panel.SetActive(true);
            GameObject.Find("VictorySound").GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("level1", 1);
            PlayerPrefs.SetInt("curLevel", 0);
            isVictory = true;
        }
    }


    public void Next()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }
}
