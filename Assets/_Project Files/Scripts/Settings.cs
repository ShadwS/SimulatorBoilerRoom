using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public event Action<float> UpdateSensitivity;
    public event Action<float> UpdateVolume;

    public int Level { get => _level; set => _level = value; }
    public ComplexityGame Complexity { get => _currentComplexity; set => _currentComplexity = value;}
    public float Sensitivity { get => _sensitivity; set { UpdateSensitivity?.Invoke(value); _sensitivity = value; } }
    public float VolumeSounds { get => _volumeSounds; set { UpdateVolume?.Invoke(value); _volumeSounds = value; } }
    public bool MusicState { get => _musicState; set => _musicState = value; }
    public GameObject AlarmSelected { get => _alarmSelected; set => _alarmSelected = value; }
    public List<Result> Results { get { return _results; } }

    private List<Result> _results;
    private GameObject _alarmSelected;
    private bool _musicState = true;
    private int _level;

    [Header("Settings")]

    [SerializeField] private ComplexityGame _currentComplexity;
    [SerializeField, Range(1, 500)] private float _sensitivity;
    [SerializeField, Range(10, 100)] private float _volumeSounds;

    [Header("Save Config")]

    [SerializeField] private string _savePath;
    [SerializeField] private string _savedFileName = "Save.json";

    private void Awake()
    {
        Level = 1;
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
#if UNITY_ANDROID && !UNITY_EDITOR
        _savePath = Path.Combine(Application.persistentDataPath, _savedFileName);
#else
        _savePath = Path.Combine(Application.dataPath, _savedFileName);
#endif
        if(Time.realtimeSinceStartup < 10 && SceneManager.GetActiveScene().name == "Menu")
        {
            LoadFromFile();
        }
    }

    private void OnApplicationQuit() => SaveToFile();

    private void SaveToFile()
    {
        GameCoreStruct gameCore = new GameCoreStruct();

        gameCore.Sensivity = _sensitivity;
        gameCore.Volume = _volumeSounds;
        gameCore.MysicState = _musicState;
        gameCore.Results = _results.ToArray();

        string json = JsonUtility.ToJson(gameCore, true);

        try
        {
            File.WriteAllText(_savePath, json);
        }
        catch (Exception e)
        {
            Debug.Log("{GameLog} => [Settings] - (<color = red>Error</color>) - SaveToFile -> " + e.Message);
        }
    }

    private void LoadFromFile()
    {
        if (!File.Exists(_savePath))
        {
            Debug.LogError("{GameLog} => [Settings] - LoadFromFile -> File Not Found!");
            return;
        }

        try
        {
            string json = File.ReadAllText(_savePath);
            GameCoreStruct gameCoreStructFromJson = JsonUtility.FromJson<GameCoreStruct>(json);

            _musicState = gameCoreStructFromJson.MysicState;
            _volumeSounds = gameCoreStructFromJson.Volume;
            _sensitivity = gameCoreStructFromJson.Sensivity;
            _results = gameCoreStructFromJson.Results.ToList();

        }
        catch (Exception e)
        {
            Debug.Log("{GameLog} => [Settings] - (<color = red>Error</color>) - SaveToFile -> " + e.Message);
        }
    }
}
