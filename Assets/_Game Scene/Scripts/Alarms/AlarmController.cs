using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private AlarmSelection _alarmSelection;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _textsButtons;
    [SerializeField] private TMP_Text _alarmText;
    [SerializeField] private TMP_Text _alarmTask;
    [SerializeField] private TMP_Text _objectState;
    [SerializeField] private TMP_Text _objectAction;
    private Alarm _alarm;
    private GameCanvas _gameCanvas;
    private InteractionInformation _interactionInfoSelect;
    private bool[] _executionOrder;
    private int _sequenceElements = 0;
    private int _executionOrderIndex = 0;
    private bool _conditionsForTheSequenceOfActions = false;

    private void Start()
    {
        _gameCanvas = gameObject.GetComponent<GameCanvas>();
        _gameCanvas.UpdateInteractionInformation += UpdateButtons;
        _gameCanvas.BackGame += VictoryCheck;
        _alarm = _alarmSelection.GetAlarm();
        _executionOrder = new bool[_alarm.Tasks.Length];
        _alarmText.text = _alarm.Name;
        int index = 1;
        foreach(var task in _alarm.Tasks)
        {
            _alarmTask.text = $"{index}. {task}\n";
            index++;
        }
        StartCoroutine(FlashingText());
    }

    private void OnDestroy()
    {
        _gameCanvas.UpdateInteractionInformation -= UpdateButtons;
        _gameCanvas.BackGame -= VictoryCheck;
    }

    public void ButtonChecksTheAnswer(int nomer)
    {
        if (nomer == _interactionInfoSelect.CorrectButtonNumber)
        {
            _objectState.text = _interactionInfoSelect.ObjectState;
            if(_interactionInfoSelect.ActionObject != "")
            {
                _objectAction.text = _interactionInfoSelect.ActionObject;
            }
            _executionOrder[_executionOrderIndex] = true;
            _executionOrderIndex++;
        }
        else
        {
            print("Поражение");
        }
        _buttons[nomer - 1].interactable = false;
    }

    private void VictoryCheck()
    {
        if(!_conditionsForTheSequenceOfActions)
        {
            return;
        }
        int rightAnswers = 0;
        for (int i = 0; i < _executionOrder.Length; i++)
        {
            if(_executionOrder[i])
            {
                rightAnswers++;
            }
        }
        if (rightAnswers == _executionOrder.Length)
        {
            print("WINNNNNNN!!!!!");
        }
    }

    private void UpdateButtons(InteractionInformation interactionInfo)
    {
        if (_alarm.Sequencing[_sequenceElements].name == interactionInfo.name)
        {
            _sequenceElements++;
            if(_sequenceElements >= _alarm.Tasks.Length)
            {
                _conditionsForTheSequenceOfActions = true;
            }
        }
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
        while (_alarmText.alpha > 0)
        {
            _alarmText.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        _alarmText.alpha = 0;
        while (_alarmText.alpha < 1)
        {
            _alarmText.alpha += 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
        _alarmText.alpha = 1;
        yield return new WaitForSeconds(1);
        StartCoroutine(FlashingText());
    }
}
