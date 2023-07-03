using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody;
    private string BARIER_TAG = "Barier";

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // FixedUpdate is called after every Fixed Timestemp interval, which can be changed in project settings
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(BARIER_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(BARIER_TAG))
            Destroy(gameObject);
    }
}
