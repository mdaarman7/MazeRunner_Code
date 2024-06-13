using UnityEngine;
public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private float coolDownTimer = Mathf.Infinity;
    private Animator anim;
    private PlayerMovementScript playerMovement;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovementScript>();
    }
    private void Update()
    {
        // Fire Ball
        if (Input.GetMouseButton(0) && coolDownTimer > attackCoolDown && playerMovement.canAttack())
        {
            Attack();   
        }
        coolDownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("fire");    //Fire Animation
        coolDownTimer = 0;
        //Activation Of Fireballs In Hierarchy Through User Mouse Button Click
        fireballs[FindFireBall()].transform.position = firepoint.position;
        fireballs[FindFireBall()].GetComponent<ProjectorScript>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    public int FindFireBall()
    {
        int i;
        for (i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}