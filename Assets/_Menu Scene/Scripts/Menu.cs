using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject panelMenu;
    [SerializeField] GameObject panelLevels;

    private void Start()
    {
        panelMenu.SetActive(true);
        panelLevels.SetActive(false);
    }
    public void ButtonPlay()
    {
        SceneManager.LoadScene(3);
    }
    public void ButtonLevels()
    {
        panelMenu.SetActive(false);
        panelLevels.SetActive(true);
    }
    public void ButtonLoadLvl(int lvl)
    {
        SceneManager.LoadScene(lvl + 2);
    }
    public void ButtonBeak()
    {
        panelLevels.SetActive(false);
        panelMenu.SetActive(true);
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
