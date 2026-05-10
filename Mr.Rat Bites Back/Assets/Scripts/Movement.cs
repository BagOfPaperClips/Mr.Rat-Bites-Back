using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.LightingExplorerTableColumn;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    public GameObject health3;
    public GameObject health2;
    public GameObject health1;

    public int health = 3;

    public GameObject attackgame;
    public CircleCollider2D attackgame1;
    public static int deathtype = 1;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Attack
            StartCoroutine(attack());

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cheese") && !collision.gameObject.CompareTag("Attack"))
        {
            Debug.Log("hit");
            health = health - 1;
            if (health == 2)
            {
                health3.SetActive(false);

            }
            if (health == 1)
            {
                health2.SetActive(false);
            }
            if (health == 0)
            {
                health1.SetActive(false);

                //DEATH SCREEN
                StaticData.deathtype = 1;
                SceneManager.LoadScene("Death");
            }
        }/*
        if (collision.CompareTag("Player") && collision.gameObject.name != "attack1")
        {
            Debug.Log("attackDeath");
            StaticData.deathtype = 2;
            SceneManager.LoadScene("Death");
        }*/
        }
    IEnumerator attack()
    {
        attackgame.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        attackgame.SetActive(false);
    }
}
