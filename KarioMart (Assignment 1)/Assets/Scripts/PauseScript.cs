using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    
    //really simple script just activating and deactivating different gameobjects that contain different parts of the pause menu.
    //Is not modular, adding more features to the pause script would require adding more code here but since there wont be any more features. Thats not a big deal.
}
