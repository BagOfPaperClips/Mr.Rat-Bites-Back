using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    //HEALTH UI
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;

    public int health = 3;

    public GameObject attackgame;
    public CircleCollider2D attackgame1;
    public static int deathtype = 1;

    public AudioSource att;
    public AudioSource hurt;


    // Update is called once per frame
    void Update()
    {
        //MOVEMENT
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(movement.x, movement.y, 0 );

        // float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        // rb.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ATTACK
            StartCoroutine(attack());

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        attackgame.transform.position = transform.position; // LINK THE RAT MOVEMENT TO THE ATTACK CIRCLE
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //DEPLETE HEART FOR EACH CHEESE THEN DEATH WHEN NO MORE HEARTS
        if (collision.CompareTag("Cheese"))
        {
            hurt.Play();
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
                StaticData.deathtype = 1;// CHANGE DEATH STAGE TO CHEESE EAT
                SceneManager.LoadScene("Death");
            }
        }
        if (collision.CompareTag("Player"))// IF PLAYERS HIT EACHOTHER DEATH
        {
            Debug.Log("attackDeath");
            StaticData.deathtype = 2;// CHANGE DEATH STAGE TO REG MOUSE
            SceneManager.LoadScene("Death");
        }
        }
    IEnumerator attack()// SHOW ATTACK
    {
        att.Play();
        attackgame.SetActive(true);
        
        yield return new WaitForSeconds(0.25f);
        attackgame.SetActive(false);
    }
}
