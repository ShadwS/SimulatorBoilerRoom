using UnityEngine;

public class Result : MonoBehaviour
{
    public bool Paseed { get => _passed; set => _passed = value; }
    public int Level { get => _level; set => _level = value; }
    public string AlarmName {get => _alarmName; set => _alarmName = value;}
    public ComplexityGame Complexity { get => _complexity; set => _complexity = value; }
    public float PassageTime { get => _passageTime; set => _passageTime = value; }
    public int Point { get => _point; set => _point = value; }

    private bool _passed = false;
    private int _level;
    private string _alarmName;
    private ComplexityGame _complexity;
    private float _passageTime;
    private int _point;
}
