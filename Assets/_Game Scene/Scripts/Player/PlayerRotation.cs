using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _sensetivity;

    private void Awake()
    {
        _sensetivity *= 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start() => Pause.ChangeOfSenses += SensetivityUpdate;

    private void OnDestroy() => Pause.ChangeOfSenses -= SensetivityUpdate;

    private void Update()
    {
        float angleY = _player.gameObject.transform.rotation.eulerAngles.y;
        angleY += _sensetivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        _player.gameObject.transform.rotation = Quaternion.Euler(0, angleY, 0);

        float angleX = gameObject.transform.rotation.eulerAngles.x;
        angleX -= _sensetivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        //0-90 вниз
        //360-270 верх
        if (angleX < 180)
        {
            angleX = Mathf.Clamp(angleX, -1, 90);
        }
        else
        {
            angleX = Mathf.Clamp(angleX, 270, 360);
        }
        gameObject.transform.rotation = Quaternion.Euler(angleX,
            _player.gameObject.transform.rotation.eulerAngles.y,
            gameObject.transform.rotation.eulerAngles.z);
    }
    public void SensetivityUpdate(float value) => _sensetivity = value;
}