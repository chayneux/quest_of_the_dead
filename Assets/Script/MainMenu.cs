using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public GameObject settingWindows;

    public string introScene;
    public string mainLevel;

    public void StartGame()
    {
        //PlayerPrefs.SetInt("IntroCompleted", 0);
        bool introCompleted = PlayerPrefs.GetInt("IntroCompleted", 0) == 1;

        if (introCompleted)
        {
            SceneManager.LoadScene(mainLevel); // Charger le niveau principal
        }
        else
        {
            SceneManager.LoadScene(introScene); // Charger l'intro
        }
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
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
