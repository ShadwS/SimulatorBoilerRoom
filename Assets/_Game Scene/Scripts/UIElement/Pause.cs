using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static event Action<float> ChangeOfSenses;
    public static event Action<bool> OnPause;

    [SerializeField] private GameObject[] _panels;
    //0-Pause
    //1-Options
    //2-Quit?
    [SerializeField] private Text _valueSensa;
    [SerializeField] private Slider _sliderSensetivity;
    private bool _ofPays = false;

    private void Start()
    {
        _sliderSensetivity.value = 500;
        _sliderSensetivity.maxValue = 500;
        _sliderSensetivity.minValue = 500 / 10;
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
        StartCoroutine(StartPause());
    }

    private IEnumerator StartPause()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        _panels[0].SetActive(true);
        OnPause?.Invoke(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Escape));
        StartCoroutine(Continue());
    }
    private IEnumerator Continue()
    {
        yield return new WaitUntil(() => _ofPays);
        Time.timeScale = 1;
        _panels[0].SetActive(false);
        OnPause?.Invoke(true);
        yield return new WaitUntil(() => _ofPays);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _ofPays = false;
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
    public void ButtonBeakMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading Menu");
    }
    public void ButtonContinue(bool value)
    {
        _ofPays = value;
    }
    public void ButtonsOptions(bool value)
    {
        _panels[1].SetActive(value);
    }
    public void ButtonsYesOrNot(bool value)
    {
        _panels[2].SetActive(value);
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
