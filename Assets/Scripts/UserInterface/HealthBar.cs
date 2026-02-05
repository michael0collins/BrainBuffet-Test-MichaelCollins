using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public float fillSpeed = 1;

    private float currentPlayerHealth;

    void Update()
    {
        if (healthBarImage.fillAmount != currentPlayerHealth)
            healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, currentPlayerHealth, fillSpeed * Time.deltaTime);
    }

    public void UpdateHealthBar(float current)
    {
        currentPlayerHealth = current;
    }
}
