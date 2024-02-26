using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] wayPoints;
    private int currWayPoint;
    [SerializeField] private float clousingWaypoint=0.1f;

    // Update is called once per frame
    void Update()
    {
        //To Move a Distance in the Platform
        if (Vector2.Distance(transform.position, wayPoints[currWayPoint].position) < clousingWaypoint)
        {
            currWayPoint ++;

            if (currWayPoint >= wayPoints.Length - 0.1f)
            {
                currWayPoint = 0;
            }
        }
        //To Move a Platform
        transform.position = Vector3.MoveTowards(transform.position,wayPoints[currWayPoint].position,speed * Time.deltaTime);
    }
}
