using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIToggle : MonoBehaviour
{

    public bool IsPaused = false;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        IsPaused = !IsPaused;

        if (IsPaused == true)
        {
            Time.timeScale = 0f;
        }
        else if (IsPaused == false)
        {
            Time.timeScale = 1f;
        }


    }
    public void Play()
    {
        SceneManager.LoadScene("SCN_Tutorial");   
    }

    public void Menu()
    {
        SceneManager.LoadScene("SCN_MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
