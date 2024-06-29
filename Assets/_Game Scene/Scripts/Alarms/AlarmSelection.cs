using UnityEngine;

public class AlarmSelection : MonoBehaviour
{
    public string AlarmNameSelection { get { return _alarmNameSelection; } }

    [SerializeField] private string[] _alarmsName;
    //0-LowPressureGVS
    //1-HightTemperatureBoiler
    private string _alarmNameSelection;
    private int _selectedLevel;
    private void Awake()
    {
        _selectedLevel = Settings.Instance.Level;
        switch (_selectedLevel) 
        {
            case 1:
                int indexAlarmSelection = Random.Range(_selectedLevel - 1, _selectedLevel);
                _alarmNameSelection = _alarmsName[indexAlarmSelection];
                print(_alarmNameSelection);
                break;
            case 2:
                print(2);
                break;
            case 3:
                print(3);
                break;
            case 4:
                print(4);
                break;
            case 5:
                print(5);
                break;
        }
    }
    public string GetAlarmName() => _alarmNameSelection;
}
