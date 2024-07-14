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
            //int random = Random.Range(0, _alarms.Length);
            Settings.Instance.AlarmSelected = _alarms[/*random*/0];
            Instantiate(_alarms[/*random*/0]);
        }
        else
        {
            Instantiate(Settings.Instance.AlarmSelected);
        }
    }
}
