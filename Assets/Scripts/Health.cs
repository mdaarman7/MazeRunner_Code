using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float currenthealth;
    [SerializeField] private float startingHealth;
    [SerializeField] public Image health1;
    [SerializeField] public Image health2;
    [SerializeField] public Image health3;
    private void Start()
    {
        currenthealth = startingHealth;
        health1.fillAmount = 1;
        health2.fillAmount = 1;
        health3.fillAmount = 1;
    }
}