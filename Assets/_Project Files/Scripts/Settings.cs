using System;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public event Action<float> UpdateSensitivity;
    public event Action<float> UpdateVolume;

    public int Level { get => _level; set => _level = value; }
    public ComplexityGame Complexity { get => _currentComplexity; set => _currentComplexity = value;}
    public float Sensitivity { get => _sensitivity; set { UpdateSensitivity?.Invoke(value); _sensitivity = value; } }
    public float VolumeSounds { get => _volumeSounds; set { UpdateVolume?.Invoke(value); _volumeSounds = value; } }
    public GameObject AlarmSelected { get => _alarmSelected; set => _alarmSelected = value; }


    [SerializeField] private ComplexityGame _currentComplexity;

    [SerializeField, Range(1, 500)] private float _sensitivity;

    [SerializeField, Range(10, 100)] private float _volumeSounds;
    
    private GameObject _alarmSelected;

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
