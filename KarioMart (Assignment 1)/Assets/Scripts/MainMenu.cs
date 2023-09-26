using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject MainMenuHolder;
    public void LevelMenu()
    {
        levelMenu.SetActive(true);
        MainMenuHolder.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void BackMenu()
    {
        levelMenu.SetActive(false);
        MainMenuHolder.SetActive(true);
    }
}
