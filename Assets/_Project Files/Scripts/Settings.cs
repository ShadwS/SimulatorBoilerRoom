using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    public int Level { get => _level; set => _level = value; }
    public ComplexityGame Complexity { get => _currentComplexity; set => _currentComplexity = value; }

    [SerializeField] private ComplexityGame _currentComplexity;

    private int _level;

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
