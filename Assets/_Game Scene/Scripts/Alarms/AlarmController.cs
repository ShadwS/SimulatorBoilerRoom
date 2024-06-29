using System.Collections;
using TMPro;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private AlarmSelection _alarmSelection;
    [SerializeField] private TMP_Text _alarmText;
    [SerializeField] private TMP_Text _alarmTask;
    private GameObject _alarmGameObject;
    private Alarm _alarm;

    private void Start()
    {
        _alarmGameObject = _alarmSelection.GetAlarm();
        gameObject.AddComponent(_alarmGameObject.GetComponent<Alarm>().GetType());
        _alarm = _alarmGameObject.GetComponent<Alarm>();
        _alarmText.text = _alarm.GetNameAlarm();
        _alarmTask.text = _alarm.GetTaskAlarm();
        StartCoroutine(FlashingText());
    }

    private IEnumerator FlashingText()
    {
        float alpha = 0;
        _alarmText.color = new Color(_alarmText.color.r, _alarmText.color.g, _alarmText.color.b, alpha);
        bool onFlashing = true;
        while (true)
        {
            if (onFlashing)
            {
                if (alpha <= 1)
                {
                    alpha += 0.1f;
                    _alarmText.color = new Color(_alarmText.color.r, _alarmText.color.g, _alarmText.color.b, alpha);
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    onFlashing = false;
                    alpha = 1;
                    yield return new WaitForSeconds(0.3f);
                }

            }
            else
            {
                if (alpha >= 0)
                {
                    alpha -= 0.1f;
                    _alarmText.color = new Color(_alarmText.color.r, _alarmText.color.g, _alarmText.color.b, alpha);
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    onFlashing = true;
                    alpha = 0;
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
    }
}
