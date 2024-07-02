using UnityEngine;

public class AlarmSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _alarmsName;
    //0-LowPressureGVS
    //1-HightTemperatureBoiler
    private Alarm _alarmSelection;

    private void Awake()
    {
        GameObject alarmSelection = Instantiate(_alarmsName[Random.Range(0, _alarmsName.Length)]);
        _alarmSelection = alarmSelection.GetComponent<Alarm>();
    }

    public Alarm GetAlarm() => _alarmSelection;
}
