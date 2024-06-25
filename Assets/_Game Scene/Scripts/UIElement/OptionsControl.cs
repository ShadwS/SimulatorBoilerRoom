using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsControl : MonoBehaviour
{
    [SerializeField] private Slider _sliderSensetivity;
    [SerializeField] private Text _valueSensa;

    private void Start()
    {
        GameCanvas.SynchronizationOptions += Synchronization;
        _sliderSensetivity.value = Settings.Instance.Sensitivity;
        _sliderSensetivity.maxValue = 500;
        _sliderSensetivity.minValue = 500 / 10;
        TextSensUpdate(_sliderSensetivity.value);
    }

    private void OnDestroy() => GameCanvas.SynchronizationOptions -= Synchronization;

    public void SliderSensetivity(float value)
    {
        Settings.Instance.Sensitivity = value;
        TextSensUpdate(value);
    }

    private void TextSensUpdate(float value) => _valueSensa.text = String.Format("{0:0}", value / 50f);

    private void Synchronization() => _sliderSensetivity.value = Settings.Instance.Sensitivity;
}