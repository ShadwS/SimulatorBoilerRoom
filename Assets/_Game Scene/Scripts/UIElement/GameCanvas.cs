using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvas : MonoBehaviour
{
    public static event Action SynchronizationOptions;

    [SerializeField] private GameObject[] _panels;
    [SerializeField] private Complexity[] _currentDifficulty;
    //0-PlayerInterface
    //1-TextObject
    //2-Loos
    //3-Options
    //4-Task
    [SerializeField] private TMP_Text _objectText;
    [SerializeField] private TMP_Text _timerText;
    private float _timer;

    private void Start()
    {
        _panels[0].SetActive(true);
        for (int i = 1; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
        PlayerRayCast.OnNameObject += TextUpdateOn;
        Pause.OnPause += OnCanvas;
        foreach (var difficulty in _currentDifficulty)
        {
            if (difficulty.ComplexityGame == Settings.Instance.Complexity)
            {
                _timer = difficulty.Time;
                _panels[4].SetActive(difficulty.DisplayingObject);
            }
        }
        OnTimer();
    }

    private void OnDestroy()
    {
        PlayerRayCast.OnNameObject -= TextUpdateOn;
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
        _panels[1].SetActive(value);
    }

    private void OnCanvas(bool value) => _panels[0].SetActive(value);

    private void OnTimer() => StartCoroutine(TimerGame());
}
