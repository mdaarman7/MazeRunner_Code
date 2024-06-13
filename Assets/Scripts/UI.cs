using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    PlayerMovementScript player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        player.Back.SetActive(true);
    }
    public void BackBtnClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartBtnClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGameBtnClicked()
    {
        Application.Quit();
    }
}
