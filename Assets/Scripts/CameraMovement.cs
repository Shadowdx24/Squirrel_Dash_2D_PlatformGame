using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position-cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (cameraTarget.position.x,cameraTarget.position.y,transform.position.z);
    }
}
