using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public GameObject settingWindows;

    public string introScene;
    public string mainLevel;

    public void StartGame()
    {
        bool introCompleted = PlayerPrefs.GetInt("IntroCompleted", 0) == 1;
        bool level1Completed = PlayerPrefs.GetInt("Level1Completed", 0) == 1;
        bool level2Completed = PlayerPrefs.GetInt("Level2Completed", 0) == 1;
        bool level3Completed = PlayerPrefs.GetInt("Level3Completed", 0) == 1;

        if (level2Completed)
        {
            SceneManager.LoadScene("level3"); // Charger le niveau principal
        }
        else if (level1Completed)
        {
            SceneManager.LoadScene("level2"); // Charger le niveau principal
        }
        else if (introCompleted)
        {
            SceneManager.LoadScene("level1"); // Charger le niveau principal
        }
        else
        {
            SceneManager.LoadScene("Intro"); // Charger le niveau principal
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
