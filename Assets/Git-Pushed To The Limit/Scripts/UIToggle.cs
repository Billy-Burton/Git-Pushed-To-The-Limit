using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIToggle : MonoBehaviour
{
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
    }

    public void Play()
    {
        SceneManager.LoadScene("SCN_Level1");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
