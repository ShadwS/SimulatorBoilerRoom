using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static event Action SynchronizationOptions;
    public static event Action<bool> On—ontrol;
    public event Action<InteractionInformation> UpdateInteractionInformation;
    public event Action BackGame;

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
    //8-Win
    [SerializeField] private TMP_Text _objectText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _objectNameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private Image _imageObject;
    private float _timer;
    private Complexity _complexitySelect;

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
                _complexitySelect = difficulty;
            }
        }
        _timer = _complexitySelect.Time;
        _panels[4].SetActive(_complexitySelect.DisplayingTask);
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
        _panels[5].SetActive(false);
        _panels[7].SetActive(true);
        if (_panels[4].activeSelf) _panels[1].SetActive(true);
        On—ontrol?.Invoke(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        BackGame?.Invoke();
    }

    public void OnPanelLoos()
    {
        _panels[0].SetActive(false);
        _panels[2].SetActive(true);
        SynchronizationOptions?.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void OnPanelWin()
    {
        _panels[0].SetActive(false);
        _panels[8].SetActive(true);
        SynchronizationOptions?.Invoke();
        _timeText.text = string.Format("¬‡¯Â ‚ÂÏˇ ÔÓıÓÊ‰ÂÌËˇ - " + "{0:0}" + "Ò", _complexitySelect.Time - _timer);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
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
        OnPanelLoos();
    }

    private void TextUpdateOn(string text, bool value)
    {
        _objectText.text = text;
        if (Time.timeScale == 0) return;
        _panels[1].SetActive(value);
    }

    private void InteractionObject(string name, string description, Image imageObject, InteractionInformation interactionInfoSelection)
    {
        UpdateInteractionInformation?.Invoke(interactionInfoSelection);
        On—ontrol?.Invoke(false);
        _panels[1].SetActive(false);
        _panels[7].SetActive(false);
        _panels[5].SetActive(true);
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        _objectNameText.text = name;
        _descriptionText.text = description;
        _imageObject = imageObject;
    }

    private void OnPanelClickF(bool value) => _panels[6].SetActive(value);

    private void OnCanvas(bool value) => _panels[0].SetActive(value);

    private void OnTimer() => StartCoroutine(TimerGame());
}
