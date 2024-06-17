using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static event Action<float> ChangeOfSenses;

    [SerializeField] private GameObject _paysPanel;
    [SerializeField] private Text _valueSensa;
    [SerializeField] private Slider _sliderSensetivity;
    private void Start()
    {
        _sliderSensetivity.value = 500;
        _sliderSensetivity.maxValue = 500;
        _sliderSensetivity.minValue = 500 / 10;
        _paysPanel.SetActive(false);
        StartCoroutine(StartPause());
    }
    private IEnumerator StartPause()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        _paysPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Escape));
        StartCoroutine(Continue());
    }
    private IEnumerator Continue()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        Time.timeScale = 1;
        _paysPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Escape));
        StartCoroutine(StartPause());
    }
    public void SliderSensetivity(float value)
    {
        TextSensUpdate(value);
        ChangeOfSenses?.Invoke(value);
    }
    public void TextSensUpdate(float value)
    {
        _valueSensa.text = String.Format("{0:0}", value / 50f);
    }
    public void ButtonBeakMenu() => SceneManager.LoadScene("Loading Menu");
}
