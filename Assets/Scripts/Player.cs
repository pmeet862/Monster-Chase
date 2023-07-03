using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movmentX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    //for moving player acording to keyboard input
    void PlayerMoveKeyboard()
    {
        movmentX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movmentX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    //for animating player during movment
    void AnimatePlayer()
    {
        //for going right side
        if (movmentX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        //for going left side
        else if (movmentX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        //for staying still
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    //for jump movment
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}
