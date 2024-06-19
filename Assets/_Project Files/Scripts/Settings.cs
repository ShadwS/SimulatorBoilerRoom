using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public int Level { get => _level; set => _level = value; }
    public string Complexity { get => _complexity; set => _complexity = value; }

    private int _level;
    private string _complexity;

    private void Awake()
    {
        Level = 1;
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
