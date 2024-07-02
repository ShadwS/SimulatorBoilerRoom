using System.Collections;
using TMPro;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private AlarmSelection _alarmSelection;
    [SerializeField] private TMP_Text _alarmText;
    [SerializeField] private TMP_Text _alarmTask;
    private Alarm _alarm;

    private void Start()
    {
        _alarm = _alarmSelection.GetAlarm();
        _alarmText.text = _alarm.Name;
        int index = 1;
        foreach(var task in _alarm.Tasks)
        {
            _alarmTask.text = $"{index}. {task}\n";
            index++;
        }
        StartCoroutine(FlashingText());
    }

    private IEnumerator FlashingText()
    {
        float alpha = 0;
        _alarmText.color = new Color(_alarmText.color.r, _alarmText.color.g, _alarmText.color.b, alpha);
        while (true)
        {
           
        }
    }
}
