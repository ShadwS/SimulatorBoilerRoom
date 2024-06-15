using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _sensetivity;
    [SerializeField] private Transform _camera;
    [SerializeField] private Slider _sliderSensetivity;
    public static event Action<float> ChangeOfSenses;

    private void Awake()
    {
        _sensetivity *= 100;
        _sliderSensetivity.minValue = 0;
        _sliderSensetivity.maxValue = _sensetivity;
        _sliderSensetivity.value = _sensetivity;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float angleY = gameObject.transform.rotation.eulerAngles.y;
        angleY += _sensetivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, angleY, 0);

        float angleX = _camera.rotation.eulerAngles.x;
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
        _camera.rotation = Quaternion.Euler(angleX,
            gameObject.transform.rotation.eulerAngles.y,
            _camera.rotation.eulerAngles.z);
    }
    public void SliderSensetivity(float value) 
    {
        _sensetivity = value;
        ChangeOfSenses?.Invoke(value);
    } 
}