using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    private readonly float _distance = 1.5f;
    private readonly int _maxAngle = 65;
    private readonly int _speedOpenClose = 60;
    private Transform _player;

    private void Awake() => _pivot.rotation = Quaternion.identity;

    private void Start()
    {
        _player = Player.Instance.gameObject.transform;
        StartCoroutine(DistanceLow());
    }

    private IEnumerator DistanceLow()
    {
        yield return new WaitUntil(() => Vector3.Distance(gameObject.transform.position,
            _player.position) < _distance);
        while(_pivot.rotation.eulerAngles.y < _maxAngle)
        {
            float y = _pivot.rotation.eulerAngles.y;
            y += _speedOpenClose * Time.deltaTime;
            _pivot.rotation = Quaternion.Euler(0, y, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.Euler(0, _maxAngle, 0);
        StartCoroutine(DistanceHight());
    }

    private IEnumerator DistanceHight()
    {
        yield return new WaitUntil(() => Vector3.Distance(gameObject.transform.position,
            _player.position) > _distance);
        while (_pivot.rotation.eulerAngles.y > 0 && !NextLap(_pivot.rotation.eulerAngles.y))
        {
            float y = _pivot.rotation.eulerAngles.y;
            y -= _speedOpenClose * Time.deltaTime;
            _pivot.rotation = Quaternion.Euler(0, y, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _pivot.rotation = Quaternion.identity;
        StartCoroutine(DistanceLow());
    }

    private bool NextLap(float y)
    {
        return y < 365 && y > 300;
    }
}