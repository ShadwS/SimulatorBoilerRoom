using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string,string, Image> OnInteractionObject;
    public static event Action<bool> OnPanel;

    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;
    protected bool _raycasting = true;
    protected Camera _camera;
    protected NameObject _nameObject;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        GameCanvas.OnRotation += RayCastProhibition;
    }
    private void OnDestroy()
    {
        GameCanvas.OnRotation -= RayCastProhibition;
    }
    protected virtual void FixedUpdate()
    {
        if(!_raycasting) return;
        _nameObject = RayCast();
        if (_nameObject != null)
        {
            OnPanel?.Invoke(true);
            if (Input.GetKey(KeyCode.F))
            {
                OnInteractionObject?.Invoke(_nameObject.GetNameObject(), _nameObject.GetDescription(), _nameObject.GetImage());
            }
        }
        else
        {
            OnPanel?.Invoke(false);
        }
    }
    private NameObject RayCast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hitTarget))
        {
            if (_hitTarget.transform.TryGetComponent(out NameObject nameObject))
            {
               return nameObject;
            }
        }
        return null;
    }

    private void RayCastProhibition(bool value) => _raycasting = value;
}
