using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsLevel;
    [SerializeField] private Button[] _buttonsAlarm;
    [SerializeField] private Button[] _buttonsComplexity;
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject[] _alarms;
    //0-StartPanel
    //1-LevelsPanel
    //2-PanelComplexsity
    //3-ResultPanel
    //4-OptionsPanel
    //5-QuitPanel
    //6-AlarmPanel 

    private void Start()
    {
        for (int i = 1; i < _buttonsLevel.Length; i++)
        {
            _buttonsLevel[i].interactable = i < Settings.Instance.Level ? true : false;
        }
        for (int i = 0;  i < _buttonsAlarm.Length; i++)
        {
            if (i < _alarms.Length)
            {
                _buttonsAlarm[i].GetComponentInChildren<TMP_Text>().text = _alarms[i].GetComponent<Alarm>().Name;
            }
            else
            {
                _buttonsAlarm[i].gameObject.SetActive(false);
            }
        }
        _panels[0].SetActive(true);
        for (int i = 1; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }  
    }

    public void ButtonAlarm(int index)
    {
        Settings.Instance.AlarmSelected = _alarms[index];
        StartGame();
    }

    public void ButtonLevels()
    {
        _panels[0].SetActive(false);
        _panels[1].SetActive(true);
    }

    public void ButtonLvl(int lvl)
    {
        Settings.Instance.Level = lvl;
        Complexitiesbuttons(lvl);
        _panels[2].SetActive(true);
    }

    public void ButtonComplexsity(int value)
    { 
        Settings.Instance.Complexity = (ComplexityGame)value;
        if (value == ((int)ComplexityGame.Difficult))
        {
            Settings.Instance.AlarmSelected = null;
            StartGame();
        }
        else
        {
            _panels[6].SetActive(true);
        }
        
    }

    public void ButtonBeakMenu()
    {
        _panels[0].SetActive(true);
        for (int i = 1; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
    }

    public void BeakAlarms() => _panels[6].SetActive(false);

    public void ButtonOptions() => _panels[4].SetActive(true);

    public void ButtonResult() => _panels[3].SetActive(true);

    public void BeakLevels() => _panels[2].SetActive(false);

    public void ButtonQuit() => _panels[5].SetActive(true);

    public void ButtonYes() => Application.Quit();

    private void StartGame()
    {
        SceneManager.LoadScene("Loading Game");
        _panels[0].SetActive(false);
    }

    private void Complexitiesbuttons(int correctLevel)
    {
        for (int i = 1; i < _buttonsComplexity.Length; i++)
        {
            TextButtonComplexity(i, false);
        }
        if (Settings.Instance.Results == null) { return; }
        for(int i = 0; i < Settings.Instance.Results.Count; i++)
        {
            if (Settings.Instance.Results[i].Level == correctLevel)
            {
                if(Settings.Instance.Results[i].Complexity == ComplexityGame.Difficult){ break; }
                TextButtonComplexity((int)Settings.Instance.Results[i].Complexity + 1, true);
            }
        }
    }

    private void TextButtonComplexity(int i,bool OnOf)
    {
        _buttonsComplexity[i].interactable = OnOf;
        switch (OnOf)
        {
            case true:
                _buttonsComplexity[i].GetComponentInChildren<TMP_Text>().alpha = 1f;
                break;
            case false:
                _buttonsComplexity[i].GetComponentInChildren<TMP_Text>().alpha = 0.5f;
                break;
        }
    }
}