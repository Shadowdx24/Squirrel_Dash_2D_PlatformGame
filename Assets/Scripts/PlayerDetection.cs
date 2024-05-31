using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private BulletGenerater bulletGenerater;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bulletGenerater.generateBullet();
        }
    }
}
