using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;
    [SerializeField] private float speed = 1f;
    private bool MovingLeft;
    [SerializeField] private Animator EnemyAnimator;
    private Vector3 InitialScale;
    [SerializeField] private BoxCollider2D headCollider;
    [SerializeField] private BoxCollider2D bodyCollider;
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private bool RangedEnemy = false;
    [SerializeField] private bool HasMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        
        MovingLeft = true;
        InitialScale = transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        // To Enemy Move 
        if (MovingLeft)
        {
            if (transform.position.x >= LeftEdge.position.x)
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
            if (transform.position.x <= RightEdge.position.x)
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
        if (HasMovement)
        {
            EnemyAnimator.SetBool("moving",true);
        }
        transform.position = new Vector3(transform.position.x + speed * dir * Time.deltaTime, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(InitialScale.x * -dir, InitialScale.y, InitialScale.z);

        if (RangedEnemy)
        {
            bulletsParent.localScale = new Vector3(-transform.localScale.x, bulletsParent.localScale.y, bulletsParent.localScale.z);
        }
    }

    public void die()
    {
        EnemyAnimator.SetTrigger("die");
        this.enabled = false;
        headCollider.enabled = false;
        bodyCollider.enabled = false;
        Destroy(gameObject, 1f);
    }
}
