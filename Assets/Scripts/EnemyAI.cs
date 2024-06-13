using UnityEngine;
public class EnemyAI : MonoBehaviour
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
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PosB")
        {
            transform.localScale = new Vector3(-1, 1, 1);
            TargetPos = PosA.position;

        }
        if (collision.gameObject.tag == "PosA")
        {
            transform.localScale = new Vector3(1, 1, 1);
            TargetPos = PosB.position;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fireball"))
        {
            Destroy(gameObject);
        }
    }
}