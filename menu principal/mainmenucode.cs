using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject optionsmenu;
    public GameObject MainMenu;
    public void OpenOptionsPanel()
    {
        MainMenu.SetActive(false);
        optionsmenu.SetActive(true);
    }
    public void Openmainmenupanel()
    {
        MainMenu.SetActive(true);
        optionsmenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void playgame()
    {
        SceneManager.LoadScene("level1");
    }

}
