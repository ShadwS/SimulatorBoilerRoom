using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    private int _maxAngle = 65;
    private int _speedOpenClose = 60;
    private bool _onStreet = false;

    private void Awake() => _pivot.rotation = Quaternion.identity;

    protected IEnumerator OpenDoorStreet()
    {
        while (_pivot.rotation.eulerAngles.y < _maxAngle)
        {
            float y = _pivot.rotation.eulerAngles.y;
            y += _speedOpenClose * Time.deltaTime;
            _pivot.rotation = Quaternion.Euler(0, y, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.Euler(0, _maxAngle, 0);

    }

    protected IEnumerator ClosetDoor()
    {
        while (_pivot.rotation.eulerAngles.y > 0 && NextLap(_pivot.rotation.eulerAngles.y) == false)
        {
            float y = _pivot.rotation.eulerAngles.y;
            y -= _speedOpenClose * Time.deltaTime;
            _pivot.rotation = Quaternion.Euler(0, y, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.identity;
    }

    private bool NextLap(float y) => y < 365 && y > 300;
}