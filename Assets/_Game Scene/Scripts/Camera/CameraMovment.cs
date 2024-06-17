using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private Transform _eye;

    private void LateUpdate()
    {
        transform.position = _eye.position;
    }
}
