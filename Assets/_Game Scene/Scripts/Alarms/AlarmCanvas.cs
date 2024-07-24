using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmCanvas : MonoBehaviour
{
    public static AlarmCanvas Instance;
    public event Action<int> OnButtonClick;
    public event Action OnInteraction;
    public event Action OnButtonClickActionObject;

    [SerializeField] private AlarmSelection _alarmSelection;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _textsButtons;
    [SerializeField] public TMP_Text[] Texts;
    [SerializeField] private GameObject _panelInterface;
    //0- alarmText
    //1- objectState
    //2- objectAction
    //3- Interaction
    [SerializeField] public List<TMP_Text> TextsTask;
    private InteractionInformation _interactionInfoSelect;
    private GameCanvas _gameCanvas;
    private float _timer = 5.2f;

    private void Awake() => Instance = this;

    private void Start()
    {
        _gameCanvas = gameObject.GetComponent<GameCanvas>();
        GameCanvas.UpdateInteractionInformation += UpdateButtons;
        StartCoroutine(FlashingText());
    }

    private void OnDestroy() => GameCanvas.UpdateInteractionInformation -= UpdateButtons;

    public void OnButton(int buttonNomer)
    {
        OnInteraction?.Invoke();
        _panelInterface.SetActive(false);
        Texts[3].gameObject.SetActive(true);
        StartCoroutine(TextInteraction());
        OnButtonClick?.Invoke(buttonNomer);
    }

    public void ActionButtonClick() => OnButtonClickActionObject?.Invoke();

    public void Victori(float pointAttitude) => _gameCanvas.OnPanelWin(pointAttitude);

    public void Defeat(string conclusion) => _gameCanvas.OnPanelLoos(conclusion);

    private void UpdateButtons(InteractionInformation interactionInfo)
    {
        _interactionInfoSelect = interactionInfo;
        int index = 1;
        for (int i = 0; i < _buttons.Length; i++)
        {
            if(i < _interactionInfoSelect.NameButtons.Length)
            {
                _buttons[i].interactable = true;
                _textsButtons[i].text = $"{index}: {_interactionInfoSelect.NameButtons[i]}";
                index++;
            }
            else
            {
                _buttons[i].interactable = false;
                _textsButtons[i].text = "";
            }
        }
    }

    private IEnumerator FlashingText()
    {
        while (Texts[0].alpha > 0)
        {
            Texts[0].alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Texts[0].alpha = 0;
        while (Texts[0].alpha < 1)
        {
            Texts[0].alpha += 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
        Texts[0].alpha = 1;
        yield return new WaitForSeconds(1);
        StartCoroutine(FlashingText());
    }

    private IEnumerator TextInteraction()
    {
        string text = "...";
        int index = 0;
        while (_timer > 0)
        {
            if (index >= text.Length)
            {
                index = 0;
                Texts[3].text = "Взаимодействие";
            }
            else
            {
                Texts[3].text += text[index];
                yield return new WaitForSeconds(0.5f);
                index++;
            }
            _timer -= 0.5f;
        }
        _timer = 5.2f;
        _panelInterface.SetActive(true);
        Texts[3].gameObject.SetActive(false);
    }
}
