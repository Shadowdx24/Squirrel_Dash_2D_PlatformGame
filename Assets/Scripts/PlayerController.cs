using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float JumpForce = 5.0f;
    [SerializeField] private SpriteRenderer PlayerSprite;
    [SerializeField] private Animator PlayerAnimator;
    private int state = 0;
    [SerializeField] private BoxCollider2D PlayerCollider;
    [SerializeField] private LayerMask GroundLayer;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // To Move a Player
        float dirX = Input.GetAxis("Horizontal");
        
        playerRb.velocity = new Vector2(dirX*speed, playerRb.velocity.y);
        

        // The flip a Player in Move
        if (dirX < 0)
        {
            state = 1;
            PlayerSprite.flipX = true;
        }
        else if (dirX > 0) 
        {
            state = 1;
            PlayerSprite.flipX = false;
        }
        else
        {
            state = 0;
        }

        // To Jump a Player
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x,JumpForce);
        }

        if (playerRb.velocity.y > 0 )
        {
            state = 2;
        }
        else if (playerRb.velocity.y < 0)
        {
            state = 3;
        }

        PlayerAnimator.SetInteger("State",state);
    }

    private bool isGrounded()
    {
       return Physics2D.BoxCast(PlayerCollider.bounds.center,PlayerCollider.bounds.size,0f,Vector2.down,0.1f,GroundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            Debug.Log(score);
            Destroy(collision.gameObject);
           
        }
    }
}
