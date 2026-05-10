using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //IF THE PlAYER HITS THE OBJECT THE END TARGET. IT GOES TO WIN SCREEN
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("win");
        }
    }
}
