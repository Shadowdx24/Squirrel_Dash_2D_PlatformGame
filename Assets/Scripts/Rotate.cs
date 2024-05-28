using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
   
    void Update()
    {
        //To rotate a any Traps
        transform.Rotate(0, 0, speed);
    }
}
