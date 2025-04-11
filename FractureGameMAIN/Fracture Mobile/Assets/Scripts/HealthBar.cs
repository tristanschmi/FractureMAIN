using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public IntData healthData; // Reference to the IntData ScriptableObject
    public Image fillImage; // Reference to the Fill Image of the slider
    public Gradient healthGradient; // Gradient for health colors

    private void Start()
    {
        // Initialize the health bar with the IntData values
        healthSlider.maxValue = healthData.initialValue;
        healthSlider.value = healthData.Value;

        // Set the initial color of the fill
        fillImage.color = healthGradient.Evaluate(1f);

        // Subscribe to the onValueChanged event
        healthData.onValueChanged.AddListener(UpdateHealthBar);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the onValueChanged event to avoid memory leaks
        healthData.onValueChanged.RemoveListener(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        // Update the health bar value when the health changes
        healthSlider.value = healthData.Value;

        // Calculate the health percentage and update the fill color
        float healthPercentage = healthSlider.value / healthSlider.maxValue;
        fillImage.color = healthGradient.Evaluate(healthPercentage);

        Debug.Log($"HealthBar updated: {healthSlider.value}, Color: {fillImage.color}");
    }
}