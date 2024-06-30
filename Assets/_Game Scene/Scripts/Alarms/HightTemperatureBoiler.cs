using UnityEngine;

public class HightTemperatureBoiler : Alarm
{
    //проверить работоспособность циркуляционного насоса
    //проверить наличие перепада давления на насосе
    //проверить циркуляцию котла и котлового контура
    //проверить датчики температуры котла и котлового контура
    //проверить аварийный термостат котла на работоспособность и соответсвие уставок
    //private string _nameAlarm = "Высокая температура бойлера";
    [SerializeField] private string _name;
    [SerializeField] private string _task;

    private void Awake()
    {
        _alarm = gameObject.GetComponent<HightTemperatureBoiler>();
        _nameAlarm = _name;
        _taskAlarm = _task;
    }
}
