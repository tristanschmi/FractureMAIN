using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject
{
    [SerializeField] private int value, minValue, maxValue;

    public UnityEvent<float> valueOutOfRange;
    public UnityEvent onValueChanged;

    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            Debug.Log($"Value set to: {this.value}");
            onValueChanged.Invoke();
            CheckValueRange();
        }
    }

    public void UpdateValue(int amount)
    {
        value += amount;
        Debug.Log($"Value updated by {amount}. New value: {value}");
        onValueChanged.Invoke();
        CheckValueRange();
    }

    public void SetValue(IntData data)
    {
        value = data.value;
    }
    
    public void SetValue(int data)
    {
        Value = data;
    }
    
    public void IncrementValue()
    {
        value++;
        Debug.Log($"Value incremented. New value: {value}");
        onValueChanged.Invoke();
    }

    private void CheckValueRange()
    {
        if (value >= minValue && value <= maxValue) return;
        Debug.Log($"Value out of range: {value}. Clamping to range [{minValue}, {maxValue}]");
        valueOutOfRange.Invoke(value);
        Value = Mathf.Clamp(Value, minValue, maxValue);
    }

    public void UpdateValueZeroCheck(int i)
    {
        if (value + i < 0) return;
        value += i;
    }
}