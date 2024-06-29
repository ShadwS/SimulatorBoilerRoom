using UnityEngine;

public abstract class Alarm : MonoBehaviour
{
    public Alarm NameAlarm { get { return _alarm; } }

    [SerializeField] protected Alarm _alarm;
}
