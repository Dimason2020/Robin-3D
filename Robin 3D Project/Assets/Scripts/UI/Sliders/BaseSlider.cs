using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BaseSlider : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI healthText;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetMaxValue(int maxPoint)
    {
        slider.maxValue = maxPoint;
    }

    public void SetValue(int point)
    {
        healthText.SetText(point.ToString());
        slider.value = point;

        if (slider.value <= 0)
            gameObject.SetActive(false);
    }
}
