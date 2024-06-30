
using UnityEngine;

public class LowPressureGVS : Alarm
{
    //Проверить уровень воды в баке запаса воды
    //Проверить работоспособность насосов подпитки
    //Проверить(при необходимости прокачать) расширительный бак
    //Проверить на утечку, систему отопления
    //Проверить показания датчика давления
    //private string _nameAlarm = "Низкий давление в GVS";
    [SerializeField] private string _name;
    [SerializeField] private string _task;
    private void Awake()
    {
        _alarm = gameObject.GetComponent<LowPressureGVS>();
        _nameAlarm = _name;
        _taskAlarm = _task;
    }
}
