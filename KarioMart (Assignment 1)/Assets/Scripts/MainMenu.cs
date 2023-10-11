using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject MainMenuHolder;
    public GameObject creditsHolder;
    
    public void LevelMenu()
    {
        levelMenu.SetActive(true);
        MainMenuHolder.SetActive(false);
        creditsHolder.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void BackMenu()
    {
        levelMenu.SetActive(false);
        creditsHolder.SetActive(false);
        MainMenuHolder.SetActive(true);
    }

    public void LoadScene1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void LoadScene2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void LoadScene3()
    {
        SceneManager.LoadSceneAsync("Level3");
    }

    public void Credits()
    {
     creditsHolder.SetActive(true);   
     MainMenuHolder.SetActive(false);
     levelMenu.SetActive(false);
    }
    //Very simple main menu, deactivating and activating gameobjects and loading scenes from string.
    //Maybe not the most resource effective solution but it works for such a small project.
}
