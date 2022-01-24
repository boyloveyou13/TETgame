using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public GameObject PausePanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
            Time.timeScale = Mathf.Abs(Time.timeScale - 1);
        }
    }

    public void Resume()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Destroy(GameObject.Find("AudioPlayer"));
        SceneManager.LoadScene(0);
    }

}
