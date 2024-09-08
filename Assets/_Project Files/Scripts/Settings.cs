using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public event Action<float> UpdateSensitivity;
    public event Action<float> UpdateVolume;

    public int AlarmNumber { get => _alarmNumber; 
        set => _alarmNumber = value; }
    public ComplexityGame Complexity { get => _currentComplexity; 
        set => _currentComplexity = value;}
    public float Sensitivity { get => _sensitivity; 
        set { UpdateSensitivity?.Invoke(value); _sensitivity = value; } }
    public float VolumeSounds { get => _volumeSounds; 
        set { UpdateVolume?.Invoke(value); _volumeSounds = value; } }
    public bool MusicState { get => _musicState; 
        set => _musicState = value; }
    public GameObject AlarmSelected { get => _alarmSelected; 
        set => _alarmSelected = value; }
    public List<Result> Results { get { return _results; } }

    private List<Result> _results;
    private GameObject _alarmSelected;
    private bool _musicState = true;
    private int _alarmNumber;

    [Header("Settings")]

    [SerializeField] private ComplexityGame _currentComplexity;
    [SerializeField, Range(1, 500)] private float _sensitivity;
    [SerializeField, Range(0, 100)] private float _volumeSounds;

    [Header("Save Config")]

    [SerializeField] private string _savedFileName = "Save.json";
    [SerializeField] private readonly string _keyPlayerPrefs = "SaveGameInfo";
    private string _saveInfo;

    private void Awake()
    {
        AlarmNumber = 1;
        if (Instance == null)
        {
            _results = new List<Result>();
            Instance = this;
        }
        else if(Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
#if !UNITY_EDITOR
        if (Time.realtimeSinceStartup < 30 && SceneManager.GetActiveScene().name == "Menu")
        {
            LoadFromFile();
        }
#endif
    }

    public void QuitGame()
    {
#if !UNITY_EDITOR
         SaveToFile();
#endif
    }

    private void SaveToFile()
    {
        GameCoreStruct gameCore = new()
        {
            Sensivity = _sensitivity,
            Volume = _volumeSounds,
            MysicState = _musicState,
            NumberAlarm = _alarmNumber,
            Results = _results.ToArray()
        };

        PlayerPrefs.SetString(_keyPlayerPrefs, JsonUtility.ToJson(gameCore));
        PlayerPrefs.SetFloat("Sens", _sensitivity);
        Application.Quit();
    }

    private void LoadFromFile()
    {
        if (!PlayerPrefs.HasKey(_keyPlayerPrefs) && !PlayerPrefs.HasKey("Sens")) { return; }
        else
        {
            GameCoreStruct gameCoreStructFromJson = JsonUtility.FromJson<GameCoreStruct>(PlayerPrefs.GetString(_keyPlayerPrefs));

            _musicState = gameCoreStructFromJson.MysicState;
            _volumeSounds = gameCoreStructFromJson.Volume;
            _sensitivity = gameCoreStructFromJson.Sensivity;
            _alarmNumber = gameCoreStructFromJson.NumberAlarm;
            _results = gameCoreStructFromJson.Results.ToList();

            _sensitivity = PlayerPrefs.GetFloat("Sens");
        }
    }
}
