using UnityEngine;

public abstract class Alarm : MonoBehaviour
{
    [SerializeField] protected Alarm _alarm;
    protected string _nameAlarm;

    public string GetNameAlarm() => _nameAlarm;
}
