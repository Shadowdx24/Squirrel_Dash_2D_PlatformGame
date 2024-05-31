using UnityEngine;

public class BulletGenerater : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawnPos;
    [SerializeField] private Transform bulletGeneratorParent;
    
    void Start()
    {
       // InvokeRepeating("generateBullet", 2f,5f);

    }

    public void generateBullet()
    {

        GameObject gun = Instantiate(bulletPrefab,bulletSpawnPos.transform.position,Quaternion.identity,bulletGeneratorParent);
        gun.SetActive(true);

        // Vector2 pos = new Vector2(540.45f, 3.805831f);
        //Quaternion rot = Quaternion.Euler(0, 0, 0);
    }
}
