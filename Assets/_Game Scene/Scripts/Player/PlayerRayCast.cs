using System;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string, bool> OnNameObject;

    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;
    private Camera _camera;
    private void Start()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
    }
    private void FixedUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hitTarget))
        {
            if (_hitTarget.transform.GetComponent<NameObject>() == null)
            {
                OnNameObject?.Invoke("", false);
            }
            else 
            {
                OnNameObject?.Invoke(_hitTarget.transform.GetComponent<NameObject>().GetNameObject(),true);
            } 
        }
    }
}
