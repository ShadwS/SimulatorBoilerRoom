using System;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string, bool> OnNameObject;

    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;
    private Camera _camera;
    private NameObject _nameObject;
    private bool OnRayCast = true;

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
                if (!OnRayCast) return;
                _nameObject = nameObject;
                OnNameObject?.Invoke(_nameObject.GetNameObject(), true);
                _nameObject.OutlineOn(true);
                OnRayCast = false;
            }
            else 
            {
                if (OnRayCast) return;
                _nameObject.OutlineOn(false);
                OnNameObject?.Invoke("", false);
                _nameObject = null;
                OnRayCast = true;
            }
        }
    }

}
