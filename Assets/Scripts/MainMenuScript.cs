using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{   
    public GameObject mainmenu;
    public GameObject HowToPlay;
    public GameObject GameLevel;
    public bool Level2;
    void Start()
    {
        mainmenu.SetActive(true);
        HowToPlay.SetActive(false);
        GameLevel.SetActive(false);
        Level2 = false;
    }
    public void StartBtnClicked()
    {
        Level2 = false;
        LevelHandler.Deactive();
        SceneManager.LoadScene("SampleScene");
    }
    public void Level2BtnClicked()
    {
        Level2 = true;
        LevelHandler.Active();
        SceneManager.LoadScene("SampleScene");
    }
    public void HowToPlayBtnClicked()
    {
        HowToPlay.SetActive(true);
        mainmenu.SetActive(false);
    }
    public void GameLevelsBtnClicked()
    {
        GameLevel.SetActive(true);
        mainmenu.SetActive(false);
    }
    public void BackBtnClicked()
    {
        mainmenu.SetActive(true);
        HowToPlay.SetActive(false);
        GameLevel.SetActive(false);
    }
    public void QuitGameBtnClicked()
    {
        Application.Quit();
    }
}