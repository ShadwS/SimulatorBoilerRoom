using UnityEngine;

public class AlarmSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _alarms;
    //0-LowPressureGVS
    //1-HightTemperatureBoiler

    private void Awake()
    {
        if(Settings.Instance.AlarmSelected == null)
        {
            Instantiate(_alarms[Random.Range(0, _alarms.Length)]);
        }
        else
        {
            Instantiate(Settings.Instance.AlarmSelected);
        }
    }
}
