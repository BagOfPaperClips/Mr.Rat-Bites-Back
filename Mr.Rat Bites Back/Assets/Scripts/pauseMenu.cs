using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public GameObject gamePause;
    public int counter = 0;
    public bool on = false;
    private void Awake()
    {
        on = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (counter == 0 && Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("Hello!?");

                gamePause.SetActive(true);
                Time.timeScale = 0;
                StartCoroutine(back());
            }
            if (counter == 1 && Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("Bye!!");
                gamePause.SetActive(false);
                Time.timeScale = 1;
                StartCoroutine(back());

            }
        }
    }
    IEnumerator back()
    {
        //Debug.Log(counter);
        yield return new WaitForSecondsRealtime(0.1f);
        if (counter == 1)
            counter = 0;
        else if (counter==0)
            counter = 1;
        
    }

    public void Pause()
    {
        gamePause.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(back());
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
