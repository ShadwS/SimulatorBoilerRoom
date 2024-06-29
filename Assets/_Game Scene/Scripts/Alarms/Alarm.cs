using UnityEngine;

public abstract class Alarm : MonoBehaviour
{
    public string NameAlarm { get { return _nameAlarm; } }

    [SerializeField] protected string _nameAlarm;
}
