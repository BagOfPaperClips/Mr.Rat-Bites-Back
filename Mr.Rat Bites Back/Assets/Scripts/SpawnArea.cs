using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    //ENEMIES
    public GameObject cheese1;
    public GameObject cheese2;
    public GameObject cheese3;
    public GameObject cheese4;
    public GameObject cheese5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //WHEN THE PLAYER GOES WITHIN REALEASE THE CHEESE
        if (collision.CompareTag("Player"))
        {
                cheese1.SetActive(true);
                cheese2.SetActive(true);
                cheese3.SetActive(true);
                cheese4.SetActive(true);
                cheese5.SetActive(true);
            gameObject.SetActive(false);
          

        }
    }
}
