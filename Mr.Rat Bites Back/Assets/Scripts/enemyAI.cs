using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform target; // RAT 1
    public Transform target1; // RAT 2
    public float speed = 5f;
    public Rigidbody2D rb;
    CapsuleCollider2D cd;

    private float rand;
    private void Awake()
    {
        rand = Random.Range(1,3);// PICK ONE OF THE TWO RATS
        //Debug.Log(rand);
    }
    
    private void FixedUpdate()
    {
        //LOGIC TO MOVE THE CHEESE TO THE CHOSEN MOUSE
        float step = speed * Time.deltaTime;
        if (rand == 1)
        {
            rb.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        if (rand == 2)
        {

            rb.position = Vector2.MoveTowards(transform.position, target1.position, step);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IF HIT PLAYER DIE
        if (collision.CompareTag("Player"))
        {
            cd = gameObject.GetComponent<CapsuleCollider2D>();
            cd.enabled = false;
            Destroy(gameObject, 0.1f);
        }

        //IF HIT ATTACK DIE
        else if (collision.CompareTag("Attack"))
        {
            cd = gameObject.GetComponent<CapsuleCollider2D>();
            cd.enabled = false;
            Destroy(gameObject, 0.1f);
        }
    }
}
