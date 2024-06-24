using System;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string, bool> OnNameObject;

    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;
    private Camera _camera;
    private NameObject _nameObject;
    private bool _onRayCast = false;

    private void Start() => _camera = gameObject.GetComponent<Camera>();

    private void FixedUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hitTarget))
        {
            if (_onRayCast)
            {
                _nameObject.OutlineOn(false);
            }
            if (_hitTarget.transform.TryGetComponent(out NameObject nameObject))
            {
                _nameObject = nameObject;
                OnNameObject?.Invoke(_nameObject.GetNameObject(), true);
                _nameObject.OutlineOn(true);
                _onRayCast = true;
            }
            else
            {
                if (!_onRayCast)
                {
                    return;
                }
                _nameObject.OutlineOn(false);
                OnNameObject?.Invoke("", false);
                _nameObject = null;
                _onRayCast = false;
            }
        }
    }

}
