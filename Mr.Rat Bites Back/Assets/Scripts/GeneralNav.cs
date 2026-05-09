using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralNav : MonoBehaviour
{
    public GameObject creditsNav;

    public void Game()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void CreditsON()
    {
        creditsNav.SetActive(true);

    }
    public void CreditsOFF()
    {
        creditsNav.SetActive(false);

    }
    public void Exit()
    {
        Application.Quit();

    }

}
