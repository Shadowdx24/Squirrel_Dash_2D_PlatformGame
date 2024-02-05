using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float JumpForce = 5.0f;
    [SerializeField] private SpriteRenderer PlayerSprite;

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

        // To Jump a Player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x,JumpForce);
        }

        // The flip a Player in Move
        if (dirX < 0)
        {
            PlayerSprite.flipX = true;
        }
        else
        {
            PlayerSprite.flipX = false;
        }
    }
}
