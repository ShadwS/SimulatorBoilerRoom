using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;
    public int Lvl { get { return _lvl; }  set { _lvl = value; } }
    private int _lvl;
    private void Awake()
    {
        Lvl = 1;
        if (instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
