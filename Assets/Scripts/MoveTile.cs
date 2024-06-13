using UnityEngine;
public class MoveTile : MonoBehaviour
{
    public Transform PosA, PosB;
    public int speed;
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
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            collider2D.transform.SetParent(this.transform);
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            collider2D.transform.SetParent(null);
        }
    }
}