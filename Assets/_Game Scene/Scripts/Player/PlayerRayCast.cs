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
        _camera = gameObject.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hitTarget))
        {
            if (_hitTarget.transform.TryGetComponent(out NameObject nameObject))
            { 
                OnNameObject?.Invoke(nameObject.GetNameObject(), true);
            }
            else 
            {
                OnNameObject?.Invoke("", false);
            } 
        }
    }

}
