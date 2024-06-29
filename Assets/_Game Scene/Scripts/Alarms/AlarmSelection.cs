using UnityEngine;

public class AlarmSelection : Alarm
{
    [SerializeField] Alarm[] _alarms;
    //0-LowPressureGVS
    //1-HightTemperatureBoiler
    private int _indexAlarmSelection;
    private int _selectedLevel;
    private void Awake()
    {
        _selectedLevel = Settings.Instance.Level;
        switch (_selectedLevel) 
        {
            case 1:
                _indexAlarmSelection = Random.Range(_selectedLevel - 1, _selectedLevel);
                _alarm = _alarms[_indexAlarmSelection];
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
}
