using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI healthText;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetMaxHealth(int maxPoint)
    {
        slider.maxValue = maxPoint;
    }

    public void SetHealth(int healthPoint)
    {
        healthText.SetText(healthPoint.ToString());
        slider.value = healthPoint;
    }
}
