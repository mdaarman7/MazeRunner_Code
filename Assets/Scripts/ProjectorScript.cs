using UnityEngine;
public class ProjectorScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    public Animator anim;
    private float direction;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        // Fire 
        if (hit)
        {
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Fireball Collision
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            hit = true;
            anim.SetTrigger("explode");     //Explode Animation
        }
    }
    //Fireball Direction
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}