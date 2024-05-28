using UnityEngine;

public class HorizontalEnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1f;
    
    void Start()
    {
        Invoke("ShootBullet",5f);
    }

    private void FixedUpdate()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        float movement = bulletSpeed * Time.deltaTime;
        transform.Translate(movement,0,0);
        Destroy(gameObject,2.5f);

       // transform.position=new Vector2(transform.position.x - (1 * bulletSpeed * Time.deltaTime), transform.position.y);
       // transform.position = new Vector2(transform.position.x + (1 * bulletSpeed * Time.deltaTime), transform.position.y);
    }
}
