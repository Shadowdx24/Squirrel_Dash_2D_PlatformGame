using UnityEngine;

public class JumperPlatform : MonoBehaviour
{
    [SerializeField] private float JumpFroce = 5.0f;
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private Animator JumpAnimator;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerRb.AddForce(Vector2.up * JumpFroce,ForceMode2D.Impulse);
            JumpAnimator.SetTrigger("jump");

            //PlayerRb.velocity=new Vector2(PlayerRb.velocity.x,JumpFroce);
        }
    }
}
