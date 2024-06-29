using UnityEngine;

public class AlarmSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _alarmsName;
    //0-LowPressureGVS
    //1-HightTemperatureBoiler
    private GameObject _alarmSelection;
    private int _selectedLevel;
    private void Awake()
    {
        _selectedLevel = Settings.Instance.Level;
        switch (_selectedLevel) 
        {
            case 1:
                int indexAlarmSelection = Random.Range(0, 100) > 50 ? 1 : 0;
                _alarmSelection = Instantiate(_alarmsName[indexAlarmSelection]);
                print(_alarmSelection);
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
    public GameObject GetAlarm() => _alarmSelection;
}
