using System;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public static event Action<float> UpdateSensitivity;

    public int Level { get => _level; set => _level = value; }
    public ComplexityGame Complexity { get => _currentComplexity; set => _currentComplexity = value;}
    public float Sensitivity { get => _sensitivity; set{ UpdateSensitivity?.Invoke(value); _sensitivity = value; } }

    [SerializeField] private ComplexityGame _currentComplexity;

    private int _level;

    [SerializeField] private float _sensitivity;

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
