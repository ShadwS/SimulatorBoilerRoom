using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    private Player _player;
    private readonly int _maxAngle = 65;
    private readonly int _speedOpenClose = 150;
    private readonly float _distance = 1.5f;

    private void Awake() => _pivot.rotation = Quaternion.identity;

    private void Start()
    {
        _player = Player.Instance;
        StartCoroutine(DistanceForPlayer());
    }

    private IEnumerator OpenDoorStreet()
    {
        while (_pivot.rotation.eulerAngles.y < _maxAngle)
        {
            _pivot.Rotate(Vector3.up * _speedOpenClose * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.Euler(0, _maxAngle, 0);
        yield return new WaitForSeconds(2);
        StartCoroutine(CloseDoorStreet());
    }

    private IEnumerator OpenDoorRoom()
    {
        _pivot.rotation = Quaternion.Euler(0, 359, 0);
        while (_pivot.rotation.eulerAngles.y > 360 - _maxAngle)
        {
            _pivot.Rotate(Vector3.up * -_speedOpenClose * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.Euler(0, 360 - _maxAngle, 0);
        yield return new WaitForSeconds(2);
        StartCoroutine(CloseDoorRoom());
    }

    private IEnumerator CloseDoorStreet()
    {
        while (_pivot.rotation.eulerAngles.y > 0 && NextLap(_pivot.rotation.eulerAngles.y) == false)
        {
            _pivot.Rotate(Vector3.up * -_speedOpenClose * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.identity;
        yield return new WaitForSeconds(2);
        StartCoroutine(DistanceForPlayer());
    }

    private IEnumerator CloseDoorRoom()
    {
        _pivot.rotation = Quaternion.Euler(0, 360 - _maxAngle, 0);
        while (_pivot.rotation.eulerAngles.y < 360 && NextLap(_pivot.rotation.eulerAngles.y))
        {
            _pivot.Rotate(Vector3.up * _speedOpenClose * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.identity;
        yield return new WaitForSeconds(2);
        StartCoroutine(DistanceForPlayer());
    }

    private bool NextLap(float y) => y < 360 && y > 360 - _maxAngle - 1;

    private IEnumerator DistanceForPlayer()
    {
        yield return new WaitUntil(() => Vector3.Distance(gameObject.transform.position,
            _player.gameObject.transform.position) < _distance);
        if (gameObject.transform.position.z < _player.gameObject.transform.position.z)
        {
            StartCoroutine(OpenDoorStreet());
        }
        else
        {
            StartCoroutine(OpenDoorRoom());
        }
    }
}