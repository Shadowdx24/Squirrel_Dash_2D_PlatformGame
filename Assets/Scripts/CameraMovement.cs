using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    private Vector2 offset;

    void Start()
    {
        offset = transform.position-cameraTarget.position;
    }

    void Update()
    {
        //The Camera Move with a Player
        transform.position = new Vector3 (cameraTarget.position.x,cameraTarget.position.y,transform.position.z);
    }
}
