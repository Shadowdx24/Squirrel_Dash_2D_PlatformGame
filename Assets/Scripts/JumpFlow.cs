using UnityEngine;

public class JumpFlow : MonoBehaviour
{
    [SerializeField] private float JumpFroce = 5.0f;
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private Animator JumpAnimator;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //PlayerRb.velocity=new Vector2(PlayerRb.velocity.x,JumpFroce); 
            PlayerRb.AddForce(Vector2.up * JumpFroce,ForceMode2D.Impulse);
            JumpAnimator.SetTrigger("jump");
        }
    }
}
