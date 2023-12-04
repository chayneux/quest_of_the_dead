
using UnityEngine;
using System.Collections; 
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{

    public static GameOverManager instance;
    
    public GameObject gameOverUI;
    public void OnPlayerDeath()
    {

        StartCoroutine(ShowMenuAfterDelay(2f)); 

    }
        IEnumerator ShowMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverUI.SetActive(true); 
        Time.timeScale = 0f; 

    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
