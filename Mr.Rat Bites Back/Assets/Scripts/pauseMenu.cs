using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public GameObject gamePause;
    public int counter = 0;
    public bool on = false;

    //ONLY BE ABLE TO ESCAPE IN WHEN AWAKE - IN GAME
    private void Awake()
    {
        on = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            //WHEN ESCAPE IS PRESSED OPEN PAUSE MENU
            if (counter == 0 && Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("Hello!?");

                gamePause.SetActive(true); // OPEN PAUSE
                Time.timeScale = 0; // STOP TIME
                StartCoroutine(back()); 
            }
            //WHEN ESCAPE IS PRESSED CLOSE PAUSE MENU
            if (counter == 1 && Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("Bye!!");
                gamePause.SetActive(false); //CLOSE PAUSE
                Time.timeScale = 1; // START TIME
                StartCoroutine(back());

            }
        }
    }

    // THIS OPERATION HAPPENS SO YOU CAN REPRESS ESC TO CLOSE THE PAUSE MENU
    IEnumerator back()
    {
        //Debug.Log(counter);
        yield return new WaitForSecondsRealtime(0.1f);// IN REALTIME SO IT CAN WORK WHEN TIME STOPS
        if (counter == 1)
            counter = 0;
        else if (counter==0)
            counter = 1;
        
    }

    //FOR BUTTON IN PAUSE MENU TO GO BACK TO GAME
    public void Pause()
    {
        gamePause.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(back());
    }

    //FOR BUTTON IN PAUSE TO GO TO TITLE SCREEN
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
