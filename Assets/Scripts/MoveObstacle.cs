using UnityEngine;
public class MovableObstacle : MonoBehaviour
{
    public Transform PosA, PosB;    
    public float speed;
    Vector2 TargetPos;
    void Start()
    {
        TargetPos = PosB.position;
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, PosA.position) < .1f)
        {
            TargetPos = PosB.position;
        }
        if (Vector2.Distance(transform.position, PosB.position) < .1f)
        {
            TargetPos = PosA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
    }
}