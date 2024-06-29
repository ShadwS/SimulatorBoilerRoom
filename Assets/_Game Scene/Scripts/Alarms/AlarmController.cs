using System;
using TMPro;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private AlarmSelection _alarmSelection;
    [SerializeField] private TMP_Text _alarmText;
    private Alarm _alarm;

    private void Start()
    {
        gameObject.AddComponent(Type.GetType(_alarmSelection.GetAlarmName()));
        _alarm = gameObject.GetComponent<Alarm>();
        _alarmText.text = _alarm.GetNameAlarm();
    }
}
