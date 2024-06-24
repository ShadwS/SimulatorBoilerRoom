using System;
using System.Collections;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string, bool> OnNameObject;

    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;
    private Camera _camera;
    private NameObject _nameObjectOld;
    private bool _onRayCast = false;

    private void Start() 
    {
        _camera = gameObject.GetComponent<Camera>();
        //StartCoroutine(RayCast());
    }
    private void FixedUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hitTarget))
        {
            if (_onRayCast)
            {
                _nameObjectOld.OutlineOn(false);
            }
            if (_hitTarget.transform.TryGetComponent(out NameObject nameObject))
            {
                _nameObjectOld = nameObject;
                OnNameObject?.Invoke(_nameObjectOld.GetNameObject(), true);
                _nameObjectOld.OutlineOn(true);
                _onRayCast = true;
            }
            else
            {
                if (!_onRayCast)
                {
                    return;
                }
                _nameObjectOld.OutlineOn(false);
                OnNameObject?.Invoke("", false);
                _nameObjectOld = null;
                _onRayCast = false;
            }
        }
    }
    //private IEnumerator RayCast()
    //{
    //    while (true)
    //    {
    //        _ray = _camera.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(_ray, out _hitTarget))
    //        {
    //            if (_hitTarget.transform.TryGetComponent(out NameObject nameObject))
    //            {
    //                if (nameObject != _nameObjectOld)
    //                {
    //                    OnNameAndOutline(nameObject,true);
    //                    if (_onRayCast)
    //                    {
    //                        OnNameAndOutline(_nameObjectOld, false);
    //                    }
    //                    _onRayCast = true;
    //                    _nameObjectOld = nameObject;

    //                }
    //                else
    //                {
    //                    OnNameAndOutline(_nameObjectOld, false);
    //                }
    //            }
    //        }
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}
    //private void OnNameAndOutline(NameObject Object, bool value)
    //{
    //    OnNameObject?.Invoke(Object.GetNameObject(), value);
    //    Object.OutlineOn(value);
    //}


}
