using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private Transform _eye;

    private void LateUpdate()
    {
        transform.position = _eye.position;
    }
}
