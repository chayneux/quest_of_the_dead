using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class FirstPlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Animator animator;

    public bool isInvicible = false;
    public HealthBar healthBar;
    public SpriteRenderer graphics;

    public float invincibilitySpeed = 0.2f;
    public TextMeshProUGUI myTextMeshPro;


    private int numberLife = 0;

    public GameObject fadeEffect;
    public AudioClip sound;
    public AudioClip soundHit;
    public AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    
    }

    public void TakeDamage(int damage)
    {
        if(!isInvicible)
        {
            currentHealth -= damage;
            audioSource.PlayOneShot(soundHit);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            healthBar.SetHealth(currentHealth);
            isInvicible = true;
            StartCoroutine(Invincibility());
            StartCoroutine(HandleInvicibility());
    
            if(healthBar.GetHealth() == 0f)
            {
                audioSource.PlayOneShot(sound);
                animator.SetTrigger("Death");
                fadeEffect.SetActive(true);
                StartCoroutine(ExampleCoroutine());
          }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        PlayerPrefs.SetInt("IntroCompleted", 1);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("level1");
    }

    public void AddHealth(int health)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += health;
            healthBar.SetHealth(currentHealth);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void AddLife()
    {
        numberLife += 1; 
        string currentText = myTextMeshPro.text;
        int number;

        if (int.TryParse(currentText, out number)) {
            number++;
            myTextMeshPro.text = number.ToString();
        } else {
            Debug.LogError("Le texte n'est pas un nombre valide.");
        }
    }


    public IEnumerator Invincibility()
    {
        while(isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(invincibilitySpeed);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilitySpeed);
        }
    }
    
    public IEnumerator HandleInvicibility()
    {
        yield return new WaitForSeconds(3f);
        isInvicible = false;
    }
}
