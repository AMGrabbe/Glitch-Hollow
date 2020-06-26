using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SetHealthBarValue(float health)
    {
            slider.value = health;
    }
    public void SetUpHealthBar(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
