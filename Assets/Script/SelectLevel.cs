using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{


    public Button intro;
    public Button level1;
    public Button level2;
    public Button level3;
    void Start()
    {
        bool isLevel1Unlocked = PlayerPrefs.GetInt("IntroCompleted", 0) == 1;

        if(isLevel1Unlocked)
        {
            level1.interactable = true;
        }
        else
        {
            level1.interactable = false;
        }

        bool isLevel2Unlocked = PlayerPrefs.GetInt("Level1Completed", 0) == 1;
        
        if(isLevel2Unlocked)
        {
            level2.interactable = true;
        }
        else
        {
            level2.interactable = false;
        }

        bool isLevel3Unlocked = PlayerPrefs.GetInt("Level2Completed", 0) == 1;
        
        if(isLevel3Unlocked)
        {
            level3.interactable = true;
        }
        else
        {
            level3.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Level1()
    {
        SceneManager.LoadScene("level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("level3");
    }
    public void Intro()
    {
        SceneManager.LoadScene("intro");
    }
    
}
