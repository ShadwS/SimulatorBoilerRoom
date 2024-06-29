using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static event Action SynchronizationOptions;

    [SerializeField] private GameObject[] _panels;
    [SerializeField] private Complexity[] _difficultys;
    //0-PlayerInterface
    //1-TextObject
    //2-Loos
    //3-Options
    //4-Task
    //5-Interaction
    //6-FClick
    //7-Aim
    [SerializeField] private TMP_Text _objectText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _objectNameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _alarmText;
    [SerializeField] private Image _imageObject;
    private float _timer;
    [SerializeField] private Alarm _selectedAlarm;

    private void Start()
    {
        _panels[0].SetActive(true);
        for (int i = 1; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
        _panels[7].SetActive(true);
        DisplayObject.OnNameObject += TextUpdateOn;
        PlayerRayCast.OnInteractionObject += InteractionObject;
        PlayerRayCast.OnPanel += OnPanelClickF;
        Pause.OnPause += OnCanvas;
        foreach (var difficulty in _difficultys)
        {
            if (difficulty.ComplexityGame == Settings.Instance.Complexity)
            {
                _timer = difficulty.Time;
                _panels[4].SetActive(difficulty.DisplayingTask);
            }
        }
        OnTimer();
    }

    private void OnDestroy()
    {
        DisplayObject.OnNameObject -= TextUpdateOn;
        PlayerRayCast.OnInteractionObject -= InteractionObject;
        PlayerRayCast.OnPanel -= OnPanelClickF;
        Pause.OnPause -= OnCanvas;
    }

    public void ButtonANew()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonBackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading Menu");
    }

    public void ButtonBackGame()
    {
        Time.timeScale = 1;
        _panels[5].SetActive(false);
        _panels[7].SetActive(true);
        if(_panels[4].activeSelf) _panels[1].SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ButttonOptions(bool value) => _panels[3].SetActive(value);

    private IEnumerator TimerGame()
    {
        while (_timer > 0)
        {
            yield return new WaitForSeconds(0.1f);
            _timer -= 0.1f;
            _timerText.text = string.Format("{0:0}", _timer);
        }
        _panels[0].SetActive(false);
        _panels[2].SetActive(true);
        SynchronizationOptions?.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    private void TextUpdateOn(string text, bool value)
    {
        _objectText.text = text;
        if (Time.timeScale == 0) return;
        _panels[1].SetActive(value);
    }

    private void InteractionObject(string name, string description, Image imageObject)
    {
        _panels[7].SetActive(false);
        _panels[1].SetActive(false);
        _panels[5].SetActive(true);
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        _objectNameText.text = name;
        _descriptionText.text = description;
        _imageObject = imageObject;
        Time.timeScale = 0;
    }

    private void OnPanelClickF(bool value) => _panels[6].SetActive(value);

    private void OnCanvas(bool value) => _panels[0].SetActive(value);

    private void OnTimer() => StartCoroutine(TimerGame());
}
