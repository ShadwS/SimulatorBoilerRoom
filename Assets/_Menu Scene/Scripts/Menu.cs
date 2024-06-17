using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject[] _panels;
    //0StartPanel
    //1LevelsPanel
    //2PanelComplexsity
    //3ResultPanel
    //4OptionsPanel
    //5QuitPanel

    private void Start()
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            if(i < Settings.instance.Lvl)
            {
                _buttons[i].interactable = true;
            }
            else
            {
                _buttons[i].interactable = false;
            }
        }
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
            if (i == 0)
            {
                _panels[i].SetActive(true);
            }
        }  
    }
    public void ButtonLevels()
    {
        _panels[0].SetActive(false);
        _panels[1].SetActive(true);
    }
    public void ButtonResult()
    {
        _panels[3].SetActive(true);
    }
    public void ButtonOptions()
    {
        _panels[4].SetActive(true);
    }
    public void ButtonLvl(int lvl)
    {
        Settings.instance.Lvl = lvl;
        _panels[2].SetActive(true);
    }
    public void ButtonComplexsity(int value)
    {
        SceneManager.LoadScene("Loading Game");
        _panels[0].SetActive(false);
    }
    public void BeakLevels() 
    {
        _panels[2].SetActive(false);
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
    public void ButtonQuit()
    {
        _panels[5].SetActive(true);
    }
    public void ButtonYes()
    {
        Application.Quit();
    }
}
