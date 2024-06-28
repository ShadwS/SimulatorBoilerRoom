using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class NameObject : MonoBehaviour
{
    [SerializeField] private string _nameObject;
    [SerializeField] private string _descriptionObject;
    [SerializeField] private Image _imageObject;
    private Outline _outline;

    private void Awake()
    {
        _outline = gameObject.GetComponent<Outline>();
        _outline.OutlineWidth = 5;
    }

    private void Start() => OutlineOn(false);

    public string GetNameObject() => _nameObject;

    public string GetDescription() => _descriptionObject;

    public Image GetImage() => _imageObject;

    public void OutlineOn(bool value) => _outline.enabled = value;
}