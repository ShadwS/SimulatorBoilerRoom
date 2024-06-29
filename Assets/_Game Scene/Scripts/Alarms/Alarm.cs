using UnityEngine;

public abstract class Alarm : MonoBehaviour
{
    [SerializeField] protected Alarm _alarm;
    protected string _nameAlarm;
    protected string _taskAlarm;

    public string GetNameAlarm() => _nameAlarm;

    public string GetTaskAlarm() => _taskAlarm;
}
