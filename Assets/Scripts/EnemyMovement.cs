using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform LeftEdga;
    [SerializeField] private Transform RightEdga;
    [SerializeField] private float speed = 1f;
    private bool MovingLeft;
    [SerializeField] Animator EnemyAnimator;
    private Vector3 InitialScale;
    
    // Start is called before the first frame update
    void Start()
    {
        MovingLeft = true;
        InitialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingLeft)
        {
            if (transform.position.x >= LeftEdga.position.x)
            {
                move(-1);
            }
            else
            {
                MovingLeft=false;
            }
        }
        else
        {
            if (transform.position.x <= RightEdga.position.x)
            {
                move(1);
            }
            else
            {
                MovingLeft=true;
            }
        }
        
        
    }

    private void move(int dir)
    {
        EnemyAnimator.SetBool("moving",true);
        transform.position = new Vector3(transform.position.x + speed * dir * Time.deltaTime, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(InitialScale.x * -dir,InitialScale.y,InitialScale.z);
    }
}
