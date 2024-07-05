using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmCanvas : MonoBehaviour
{
    public static AlarmCanvas Instance;
    public event Action<int> OnButtonClick;
    public event Action OnButtonClickActionObject;

    [SerializeField] private AlarmSelection _alarmSelection;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _textsButtons;
    [SerializeField] public TMP_Text[] Text;
    //0- alarmText
    //1- alarmTask
    //2- objectState
    //3- objectAction
    private InteractionInformation _interactionInfoSelect;
    private GameCanvas _gameCanvas;

    private void Awake() => Instance = this;

    private void Start()
    {
        _gameCanvas = gameObject.GetComponent<GameCanvas>();
        GameCanvas.UpdateInteractionInformation += UpdateButtons;
        StartCoroutine(FlashingText());
    }

    private void OnDestroy() => GameCanvas.UpdateInteractionInformation -= UpdateButtons;

    public void OnButton(int buttonNomer) => OnButtonClick?.Invoke(buttonNomer);

    public void ActionButtonClick() => OnButtonClickActionObject?.Invoke();

    public void Victori() => _gameCanvas.OnPanelWin();

    public void Defeat(int numberOfIncorrectAnswers)
    {
        _gameCanvas.OnPanelLoos(numberOfIncorrectAnswers != 0 ? $"Вы не правильно ответили на {numberOfIncorrectAnswers} вопросов" : 
            $"Вы сбились с последовательности");
    }

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
        while (Text[0].alpha > 0)
        {
            Text[0].alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Text[0].alpha = 0;
        while (Text[0].alpha < 1)
        {
            Text[0].alpha += 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
        Text[0].alpha = 1;
        yield return new WaitForSeconds(1);
        StartCoroutine(FlashingText());
    }
}
