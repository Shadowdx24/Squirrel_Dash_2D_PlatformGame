using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreText1;
    private int currHeath = 3;
    //[SerializeField] private int maxHealth = 3;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverObj;

    void Start()
    {
       // currHeath = maxHealth;
       //healthText.text = "" + currHeath;
        currHeath= PlayerPrefs.GetInt("Health", 3);
        healthText.text = "" + currHeath;
        Debug.Log(currHeath);
    }
    
    void Update()
    {
        // To Move a Player
        float dirX = Input.GetAxis("Horizontal");
        
        playerRb.velocity = new Vector2(dirX * speed, playerRb.velocity.y);
        
        // The flip a Player in Move
        if (dirX < 0)
        {
            state = 1;
            PlayerSprite.flipX = true;
            //AudioManager.instance.Play("Run");
        }
        else if (dirX > 0) 
        {
            state = 1;
            PlayerSprite.flipX = false;
            //AudioManager.instance.Play("Run");
        }
        else
        {
            state = 0;
            Debug.Log("idle");
        }

        // To Jump a Player
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x,JumpForce);
        }

        if (playerRb.velocity.y > 0.1f)
        {
            state = 2;
        }
        else if (playerRb.velocity.y < -0.1f)
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
            //To collect a Gem and Grind a Score
            score++;
            Debug.Log(score);
            Destroy(collision.gameObject);
            scoreText.text = "" + score;
            AudioManager.instance.Play("Coin");

        }
        else if (collision.gameObject.CompareTag("FinishLine"))
        {
            // To Win this Level
            Debug.Log("Level1 Complete");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.instance.Stop(SceneManager.GetActiveScene().name);
            AudioManager.instance.Play(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name);
            //AudioManager.instance.Play("Level2 Bg");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Die to A Player with Traps
            currHeath --;
            //healthText.text = "" + currHeath;
            PlayerPrefs.SetInt("Health", currHeath);
            Debug.Log(currHeath);
            Debug.Log("Game Over");
            PlayerAnimator.SetTrigger("Die");
            AudioManager.instance.Play("Hurt");

            if (currHeath == 0)
            {
                Debug.Log("Game Over");
                PlayerAnimator.SetTrigger("Die");
                AudioManager.instance.Play("Hurt");
                GameOver();
            }
        }
        else if (collision.gameObject.CompareTag("Fall"))
        {
            // Die to A Player with Fall
            currHeath--;
            PlayerPrefs.SetInt("Health", currHeath);
            Debug.Log(currHeath);
            PlayerAnimator.SetTrigger("Die");
            AudioManager.instance.Play("Hurt");

            if (currHeath == 0)
            {
                Debug.Log("Game Over");
                PlayerAnimator.SetTrigger("Die");
                AudioManager.instance.Play("Hurt");
                GameOver();
            }
        }
    }

    private void Restart()
    {
        //To Restart this Level 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
       
    private void GameOver()
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.instance.Stop(SceneManager.GetActiveScene().name);
        AudioManager.instance.Play("Game Over");
        scoreText1.text = "Score: " + score;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        gameOverObj.SetActive(false);
        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Health", 3);
        score = 0;
    }

    public void GameHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        gameOverObj.SetActive(false);
        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play("Home");
    }
}
