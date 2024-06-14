using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject panelMenu;
    [SerializeField] GameObject panelLevels;
    [SerializeField] GameObject panelComplexsity;
    [SerializeField] GameObject panelResult;
    [SerializeField] GameObject panelOptions;
    [SerializeField] GameObject panelQuit;
    [SerializeField] GameObject[] panels;
    int complexsity;
    int selectedLevel;

    private void Start()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        panelLevels.SetActive(false);
    }
    public void ButtonLevels()
    {
        panelMenu.SetActive(false);
        panelLevels.SetActive(true);
    }
    public void ButtonResult()
    {
        panelResult.SetActive(true);
    }
    public void ButtonOptions()
    {
        panelOptions.SetActive(true);
    }
    public void ButtonLvl(int lvl)
    {
        selectedLevel = lvl;
        panelComplexsity.SetActive(true);
    }
    public void ButtonComplexsity(int value)
    {
        complexsity = value;
        SceneManager.LoadScene(selectedLevel + 2);
    }
    public void BeakLevels() 
    {
        panelComplexsity.SetActive(false);
    }
    public void ButtonBeakMenu()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        panelMenu.SetActive(true);
    }
    public void ButtonQuit()
    {
        panelQuit.SetActive(true);
    }
    public void ButtonYes()
    {
        Application.Quit();
    }
}
