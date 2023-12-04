using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public string LevelLoad;
    public GameObject settingWindows;

    public void StartGame()
    {
        SceneManager.LoadScene(LevelLoad);
    }

    public void SettingsButton()
    {
        settingWindows.SetActive(true);
    }

    public void CloseSettingsWindWow()
    {
        settingWindows.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
