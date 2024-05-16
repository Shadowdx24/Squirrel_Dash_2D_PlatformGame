using UnityEngine;

public class BulletGenerater : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawnPos;
    [SerializeField] private Transform bulletGeneratorParent;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateBullet", 2f,5f);
    }
    private void generateBullet()
    {
           // Vector2 pos = new Vector2(540.45f, 3.805831f);
            //Quaternion rot = Quaternion.Euler(0, 0, 0);
            GameObject gun = Instantiate(bulletPrefab,bulletSpawnPos.transform.position,Quaternion.identity,bulletGeneratorParent);
            gun.SetActive(true);
    }
    
}
