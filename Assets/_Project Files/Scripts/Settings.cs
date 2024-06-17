using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;
    public int Level { get { return _level; }  set { _level = value; } }
    private int _level;
    private void Awake()
    {
        Level = 1;
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
