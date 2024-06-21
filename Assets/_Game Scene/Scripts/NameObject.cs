using UnityEngine;

[RequireComponent(typeof(Outline))]
public class NameObject : MonoBehaviour
{
    [SerializeField] private string _nameObject;
    [SerializeField] private Outline _outline;

    private void Start() => OutlineOn(false);

    public string GetNameObject() => _nameObject;

    public void OutlineOn(bool value) => _outline.enabled = value;
}
