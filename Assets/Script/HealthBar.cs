using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient; 
    public RawImage fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        if(health >= 0f)
            slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public float GetHealth()
    {
        return slider.value;
    }

}
