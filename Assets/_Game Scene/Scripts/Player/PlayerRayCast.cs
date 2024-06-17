using System;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string> OnNameObject;
    public static event Action OfNameObject;

    [SerializeField] private Camera _camera;
    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;

    private void LateUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hitTarget))
        {
            if (_hitTarget.transform.GetComponent<NameObject>() == null)
            {
                OfNameObject?.Invoke();
            }
            else 
            {
                OnNameObject?.Invoke(_hitTarget.transform.GetComponent<NameObject>().GetNameObject());
            } 
        }
    }
}
