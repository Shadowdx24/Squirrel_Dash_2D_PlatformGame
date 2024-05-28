using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private SpriteRenderer PlayerSprite;
    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private BoxCollider2D PlayerCollider;

    [Header("Movement Parameters")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float JumpForce = 5.0f;
    [SerializeField] private LayerMask GroundLayer;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private GameObject gamePauseObj;
    [SerializeField] private GameObject playAgainObj;
    [SerializeField] private GameObject gameWarningObj;
    [SerializeField] private Button gainLife;
    
    private int currHeath = 3;
    private int score = 0;
    private int state = 0;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text ="" + score;

        currHeath = PlayerPrefs.GetInt("Health", 3);
        healthText.text = "" + currHeath;
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
        GamePause();
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
            PlayerPrefs.SetInt("Score",score);
            Destroy(collision.gameObject);
            scoreText.text = "" + score;
            AudioManager.instance.Play("Coin");
        }
        else if (collision.gameObject.CompareTag("FinishLine"))
        {
            LevelManager.Instance.UnlockNextLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            AudioManager.instance.Stop(SceneManager.GetActiveScene().name);
            AudioManager.instance.Play(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name);
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            // Die to A Enemy in Player
            collision.gameObject.GetComponent<EnemyMovement>().die();
        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            // Die to A Player with Fall
            currHeath--;
            PlayerPrefs.SetInt("Health", currHeath);
            collision.gameObject.GetComponent<Animator>().SetTrigger("explode");
            collision.gameObject.GetComponent<Animator>().SetTrigger("explode");
            PlayerAnimator.SetTrigger("Die");
            AudioManager.instance.Play("Hurt");
            Destroy(collision.gameObject,.5f);

            if (currHeath == 0)
            {
                GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Die to A Player with Traps
            Die();
        }
        else if (collision.gameObject.CompareTag("Fall"))
        {
            // Die to A Player with Fall
            Die();
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {

            // Die to A Player in Enemy
            Die();
        }

    }

    private void Die()
    {
        currHeath--;
        PlayerPrefs.SetInt("Health", currHeath);
        PlayerAnimator.SetTrigger("Die");
        AudioManager.instance.Play("Hurt");

        if (currHeath == 0)
        {
            GameOver();
        }
    }

    private void Restart()
    {
        //To Restart this Level 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePauseObj.SetActive(true);
            
            Time.timeScale = 0f;
            AudioManager.instance.Stop(SceneManager.GetActiveScene().name);
        }
    }
       
    private void GameOver()
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.instance.Stop(SceneManager.GetActiveScene().name);
        AudioManager.instance.Play("Game Over");
        gameOverScoreText.text = "Score: " + score;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        gameOverObj.SetActive(false);
        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Health", 3);
    }

    public void GameHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        gameOverObj.SetActive(false);
        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play("Home");
    }

    public void GameResume()
    {
        Time.timeScale = 1.0f;
        gamePauseObj.SetActive(false);
        AudioManager.instance.Play(SceneManager.GetActiveScene().name);
        
    }

    public void PlayAgain()
    {
       playAgainObj.SetActive(true);
       gameOverObj.SetActive(false);

        if (score < 3)
        {
            gainLife.interactable = false;
        }
        else
        {
            gainLife.interactable = true;
        }
    }
    
    public void PlayAgainYes()
    {
        playAgainObj.SetActive(false);
        gameWarningObj.SetActive(true);
    }

    public void WarningYes()
    {
        gameWarningObj.SetActive(false);
        LevelManager.Instance.LevelReset();
        Time.timeScale = 1.0f;
        
        score = 0;
        PlayerPrefs.SetInt("Score",score);
        currHeath = 3;
        PlayerPrefs.SetInt("Health", currHeath);

        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play(SceneManager.GetActiveScene().name);
        
        SceneManager.LoadScene(1);
    }

    public void WarningNo()
    {
        gameWarningObj.SetActive(false);
        playAgainObj.SetActive(true);
    }

    public void GameLife()
    {
        score -=3;
        PlayerPrefs.SetInt("Score", score);
        currHeath++;
        PlayerPrefs.SetInt("Health", currHeath);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverObj.SetActive(false);
        
        Time.timeScale = 1.0f;
        
        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play(SceneManager.GetActiveScene().name);
    }
}