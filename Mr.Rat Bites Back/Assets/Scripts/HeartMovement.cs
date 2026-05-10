using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HeartMovement : MonoBehaviour
{
    public float speed = 2f;    // How fast it moves
    public float height = 0.5f; // How far up and down it goes
    private float startY;

    private void Start()
    {
        startY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
