using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject[] _panels;
    //0-StartPanel
    //1-LevelsPanel
    //2-PanelComplexsity
    //3-ResultPanel
    //4-OptionsPanel
    //5-QuitPanel

    private void Start()
    {
        for (int i = 1; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = i < Settings.Instance.Level ? true : false;
        }
        _panels[0].SetActive(true);
        for (int i = 1; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }  
    }

    public void ButtonLevels()
    {
        _panels[0].SetActive(false);
        _panels[1].SetActive(true);
    }

    public void ButtonLvl(int lvl)
    {
        Settings.Instance.Level = lvl;
        _panels[2].SetActive(true);
    }

    public void ButtonComplexsity(int value)
    { 
        Settings.Instance.Complexity = (ComplexityGame)value;
        SceneManager.LoadScene("Loading Game");
        _panels[0].SetActive(false);
    }

    public void ButtonBeakMenu()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
            if (i == 0)
            {
                _panels[i].SetActive(true);
            }
        }
    }

    public void ButtonOptions() => _panels[4].SetActive(true);

    public void ButtonResult() => _panels[3].SetActive(true);

    public void BeakLevels() => _panels[2].SetActive(false);

    public void ButtonQuit() => _panels[5].SetActive(true);

    public void ButtonYes() => Application.Quit();
}