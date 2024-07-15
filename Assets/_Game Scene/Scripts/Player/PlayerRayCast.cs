using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCast : MonoBehaviour
{
    public static event Action<string,string, Image, InteractionInformation> OnInteractionObject;
    public static event Action<bool> OnPanel;

    [SerializeField] private RaycastHit _hitTarget;
    [SerializeField] private Ray _ray;
    protected bool _raycasting = true;
    protected Camera _camera;
    protected DescriptionObject _descriptionObject;
    private readonly int _distanceObjectDescription = 2;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        GameCanvas.On—ontrol += RayCastProhibition;
    }

    private void OnDestroy() => GameCanvas.On—ontrol -= RayCastProhibition;

    protected virtual void FixedUpdate()
    {
        if(!_raycasting) return;
        _descriptionObject = RayCast();
        if (_descriptionObject != null && Vector3.Distance(gameObject.transform.position, _descriptionObject.transform.position) < _distanceObjectDescription)
        {       
            OnPanel?.Invoke(true);
            if (Input.GetKey(KeyCode.F))
            {
                OnInteractionObject?.Invoke(_descriptionObject.GetNameObject(), _descriptionObject.GetDescription(),
                        _descriptionObject.GetImage(), _descriptionObject.GetInteractionInfoSelection());
            }
        }
        else
        {
            OnPanel?.Invoke(false);
        }
    }

    private DescriptionObject RayCast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hitTarget))
        {
            if (_hitTarget.transform.TryGetComponent(out DescriptionObject descriptionObject))
            {
               return descriptionObject;
            }
        }
        return null;
    }

    private void RayCastProhibition(bool value) => _raycasting = value;
}
