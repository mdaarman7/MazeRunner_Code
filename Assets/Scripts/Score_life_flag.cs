using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text _score;
    public int scoreNum;
    Health playerHealth;
    Animator FlagAnim;
    PlayerMovementScript player;
    void Start()
    {
        scoreNum = 0;
        _score.text = "Score: " + scoreNum;
        playerHealth = GetComponent<Health>();
        player = GetComponent<PlayerMovementScript>();
        FlagAnim = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D Collide)
    {
        //  Score
        if (Collide.tag == "Coin")
        {
            scoreNum++;
            _score.text = "Score: " + scoreNum;
            Destroy(Collide.gameObject);
        }
        //  Life
        if (Collide.tag == "Life")
        {
            if (playerHealth.health3.fillAmount == 1 && playerHealth.health2.fillAmount == 1 && playerHealth.health1.fillAmount == 1)
            {
                Destroy(Collide.gameObject);
            }
            else
            {
                if (player._hurt == 0)
                {
                    playerHealth.health3.fillAmount = 1;
                    playerHealth.currenthealth++;
                    player._hurt = 1;

                }
                else if (player._hurt == 1)
                {
                    playerHealth.health2.fillAmount = 1;
                    playerHealth.currenthealth++;
                    player._hurt = 0;
                }
                Destroy(Collide.gameObject);
            }
        }
        if(Collide.tag == "CheckPoint")
        {
            FlagAnim.SetTrigger("check");
        }
    }
}