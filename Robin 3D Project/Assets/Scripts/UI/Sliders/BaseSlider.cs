using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class BaseSlider : MonoBehaviour
{
    [SerializeField] private Image damageBar;
    [SerializeField] private Image bar;

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
        else
            StartCoroutine(FillDamage());
    }

    private IEnumerator FillDamage()
    {
        yield return new WaitForSeconds(1.5f);

        while(damageBar.fillAmount > bar.fillAmount)
        {
            damageBar.fillAmount -= 0.01f;

            yield return null;

            if (damageBar.fillAmount <= bar.fillAmount)
                yield break;
        }
    }
}
