using UnityEngine;

public abstract class Alarm : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string[] _tasks;
    [SerializeField] private InteractionInformation[] _sequencing;
    private InteractionInformation _interactionInfoSelect;
    private int _subsequenceInteraction = 0;
    private bool[] _rightAnswers;
    private bool _correctObject = false;
    private bool _buttonActionOn = false;
    private int _checkClicks = 0;
    private AlarmCanvas _alarmCanvas;

    protected virtual void Start()
    {
        _alarmCanvas = AlarmCanvas.Instance;
        GameCanvas.UpdateInteractionInformation += UpdateInteractionSelect;
        GameCanvas.BackGame += ViktoryChek;
        _alarmCanvas.OnButtonClick += ButtonClick;
        _alarmCanvas.OnButtonClickActionObject += ButtonActionClick;
        _alarmCanvas.Text[0].text = _name;
        Task();
        _rightAnswers = new bool[_tasks.Length];
        for (int i = 0; i < _rightAnswers.Length; i++)
        {
            _rightAnswers[i] = false;
        }
        _alarmCanvas.Text[3].gameObject.SetActive(false);
        _alarmCanvas.Text[2].gameObject.SetActive(false);
    }

    protected virtual void OnDestroy()
    {
        GameCanvas.UpdateInteractionInformation -= UpdateInteractionSelect;
        GameCanvas.BackGame -= ViktoryChek;
        _alarmCanvas.OnButtonClick -= ButtonClick;
        _alarmCanvas.OnButtonClickActionObject += ButtonActionClick;
    }

    protected virtual void UpdateInteractionSelect(InteractionInformation interactionSelect)
    {
        _interactionInfoSelect = interactionSelect;
        CorrectObject();
    }

    protected virtual void CorrectObject() => _correctObject = _interactionInfoSelect.name == _sequencing[_subsequenceInteraction].name ? true : false;

    protected virtual void ButtonClick(int nomerButton)
    {
        _alarmCanvas.Text[2].gameObject.SetActive(true);
        _alarmCanvas.Text[2].text = _interactionInfoSelect.ObjectState[nomerButton];
        switch (_correctObject)
        {
            case true:
                CehekingCorrectButton(nomerButton);
                break;
            case false:
                _alarmCanvas.Defeat(0);
                break;

        }
    }

    protected virtual void ButtonActionClick()
    {
        _buttonActionOn = true;
        _alarmCanvas.Text[3].gameObject.SetActive(false);
        _alarmCanvas.Text[2].text = _interactionInfoSelect.Changestate;
    }

    protected virtual void ViktoryChek()
    {
        _checkClicks = 0;
        _alarmCanvas.Text[3].gameObject.SetActive(false);
        _alarmCanvas.Text[2].gameObject.SetActive(false);
        if (_subsequenceInteraction != _rightAnswers.Length) { return; }
        int numberOfCorrectAnswers = 0;
        int numberOfIncorrectAnswers = 0;
        for (int i = 0; i < _rightAnswers.Length; i++)
        {
            if (_rightAnswers[i])
            {
                numberOfCorrectAnswers++;
            }
            else
            {
                numberOfIncorrectAnswers++;
            }
        }
        if (numberOfCorrectAnswers == _rightAnswers.Length && _buttonActionOn) 
        {
            _alarmCanvas.Victori();
        }
        else
        {
            _alarmCanvas.Defeat(numberOfIncorrectAnswers);
        }
    }

    private void CehekingCorrectButton(int nomerButton)
    {
        if (nomerButton == _interactionInfoSelect.CorrectButtonNumber)
        {
            if (_interactionInfoSelect.ActionObject != null)
            {
                _alarmCanvas.Text[3].gameObject.SetActive(true);
                _alarmCanvas.Text[3].text = _interactionInfoSelect.ActionObject;
            }
            _checkClicks++;
            _alarmCanvas.Text[2].text = _interactionInfoSelect.ObjectState[nomerButton];
            if (_checkClicks == 1)
            {
                _rightAnswers[_subsequenceInteraction] = true;
                _subsequenceInteraction++;
            }
        }
        else
        {
            _checkClicks++;
            if (_checkClicks == 1)
            {
                _rightAnswers[_subsequenceInteraction] = false;
                _subsequenceInteraction++;
            }
        }
    }

    private void Task()
    {
        int index = 1;
        foreach (var task in _tasks)
        {
            _alarmCanvas.Text[1].text += $"{index}. {task}\n";
            index++;
        }
    }
}
